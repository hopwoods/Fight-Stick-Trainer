import create from 'zustand'
import { ControllerButtons } from '../enums'
import { HubConnection, HubConnectionBuilder, HubConnectionState, LogLevel } from '@microsoft/signalr'
import { useAppStore } from '../store/appStore'
import { useCallback, useEffect } from 'react'

type SignalRStoreProps = {
    hub: HubConnection,
    hubStarted: boolean;
    statusDescription: string;
    statusText: string;
    setStarted: (value: boolean) => void;
    setStatusText: (text: string) => void;
    setStatusDescription: (description: string) => void;
}

export const useSignalRStore = create<SignalRStoreProps>((set, get) => ({
    hub: configureHubConnection(),
    hubStarted: false,
    statusText: "",
    statusDescription: "",
    setStarted(value: boolean) { set({ hubStarted: value }) },
    setStatusText(text: string) { set({ statusText: text }) },
    setStatusDescription(description: string) { set({ statusDescription: description }) },
}));

export const SignalR: React.FunctionComponent = ({ children, ...props }) => {

    const { setIsControllerConnected, addInputToHistory, setIsControllerWireless } = useAppStore();
    const { hub, setStatusText, setStatusDescription, setStarted, hubStarted } = useSignalRStore();

    const start = useCallback((connection: HubConnection) => {
        if (connection.state === HubConnectionState.Disconnected) {

            console.info(`Started: ${hubStarted}`);
            console.info(`Attempting to connect to hub`);

            connection.start().then(() => {
                if (connection.state === HubConnectionState.Connected) {
                    connection.send("JoinGroup");
                }
            }).catch(err => (console.error(err)))

        }
    }, [hubStarted]);

    const stop = useCallback((connection: HubConnection) => {
        if (connection.state === HubConnectionState.Disconnected) {
            connection.stop()
                .then(() => {
                    setStarted(false);
                })
                .catch(err => (console.error(err)));

        }
    }, [setStarted]);

    useEffect(() => {

        hub.onreconnecting(() => {
            setStatusText("Reconnecting")
            setStatusDescription("Attempting to reconnect to the server")
            setIsControllerConnected(false);
            setIsControllerWireless(false);

            console.info(`Started: ${hubStarted}`);
        })

        hub.onreconnected(() => {
            setStarted(true);
            setStatusText("")
            setStatusDescription("")
            setIsControllerConnected(false);
            setIsControllerWireless(false);

            console.info(`Started: ${hubStarted}`);
        })

        hub.onclose(() => {
            setStatusText("Disconnected")
            setStatusDescription("Unable to connect to the server")
            setIsControllerConnected(false);
            setIsControllerWireless(false);

            console.info(`Started: ${hubStarted}`);
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
    }, [addInputToHistory, hub, hubStarted, setIsControllerConnected, setIsControllerWireless, setStarted, setStatusDescription, setStatusText, start, stop])

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
