import create from 'zustand'
import { ControllerButtons } from '../enums'
import { HubConnection, HubConnectionBuilder, HubConnectionState, LogLevel } from '@microsoft/signalr'
import { useAppStore } from '../store/appStore'
import { useCallback, useEffect } from 'react'

type SignalRStoreProps = {
    hub: HubConnection,
    statusDescription: string;
    statusText: string;
    setStatusText: (text: string) => void;
    setStatusDescription: (description: string) => void;
}

export const useSignalRStore = create<SignalRStoreProps>((set, get) => ({
    hub: configureHubConnection(),
    statusText: "",
    statusDescription: "",
    setStatusText(text: string) { set({ statusText: text }) },
    setStatusDescription(description: string) { set({ statusDescription: description }) },
}));

export const SignalR: React.FunctionComponent = ({ children, ...props }) => {

    const { setIsControllerConnected, addInputToHistory, setIsControllerWireless } = useAppStore();
    const { hub, setStatusText, setStatusDescription } = useSignalRStore();

    const start = useCallback((connection: HubConnection) => {
        if (connection.state === HubConnectionState.Disconnected) {

            console.info(`Started: ${connection.state}`);
            console.info(`Attempting to connect to hub`);

            connection.start().then(() => {
                if (connection.state === HubConnectionState.Connected) {
                    console.info(`Started: ${connection.state}`);
                }
            }).catch(err => (console.error(err)))

        }
    }, []);

    const stop = useCallback((connection: HubConnection) => {
        if (connection.state === HubConnectionState.Disconnected) {
            connection.stop()
                .then(() => {
                    console.info(`Hub stopped`)
                    console.info(`Hub Connected: ${connection.state}`)
                })
                .catch(err => (console.error(err)));

        }
    }, []);

    useEffect(() => {

        hub.onreconnecting(() => {
            setStatusText("Reconnecting")
            setStatusDescription("Attempting to reconnect to the server");
            console.info(`Hub Connected: ${hub.state}`)
        })

        hub.onreconnected(() => {
            ;
            setStatusText("")
            setStatusDescription("")
            console.info(`Hub Connected: ${hub.state}`)
        })

        hub.onclose(() => {
            setStatusText("Disconnected")
            setStatusDescription("Unable to connect to the server")
            console.info(`Hub Connected: ${hub.state}`)
        })

        hub.on("ReceiveControllerConnectionState", (isConnected: boolean) => {
            setIsControllerConnected(isConnected)
        });

        hub.on("ReceiveControllerWirelessCapability", (isWireless: boolean) => {
            setIsControllerWireless(isWireless)
        });

        hub.on("ReceiveButtonPress", (inputName: ControllerButtons) => {
            console.log(`Button Pressed: ${inputName}`)
            addInputToHistory(inputName);
        });

        setInterval(() => start(hub), 1000)

        return function cleanup() {
            stop(hub);
        }
    }, [addInputToHistory, hub, setIsControllerConnected, setIsControllerWireless, setStatusDescription, setStatusText, start, stop])

    return <>
        {children}
    </>
}

function configureHubConnection() {
    const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:7064/hub")
        .configureLogging(LogLevel.Information)
        .withAutomaticReconnect()
        .build();

    return connection;
}

export default SignalR;
