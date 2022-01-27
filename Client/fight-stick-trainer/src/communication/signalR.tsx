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

    const { setIsControllerConnected, addInputToHistory } = useAppStore();
    const { hub, setStatusText, setStatusDescription, setStarted } = useSignalRStore();

    const start = useCallback((connection: HubConnection) => {

        if (connection.state === HubConnectionState.Disconnected) {
            connection.start()
                .then(() => {
                    if (connection.state === HubConnectionState.Connected) {
                        connection.send("JoinGroup");
                        setStarted(true);
                    }
                })
                .catch(err => (console.error(err)))
        }
    }, [setStarted]);

    function stop(connection: HubConnection) {
        if (connection.state === HubConnectionState.Disconnected) {
            connection.stop().catch(err => (console.error(err)));
        }
    }

    useEffect(() => {

        hub.onreconnecting(() => {
            setStatusText("Reconnecting")
            setStatusDescription("Attempting to reconnect to the server")
            setIsControllerConnected(false);
        })

        hub.onreconnected(() => {
            setStarted(true);
            setStatusText("")
            setStatusDescription("")
            setIsControllerConnected(false);
        })

        hub.onclose(() => {
            setStatusText("Disconnected")
            setStatusDescription("Unable to connect to the server...Please check to see if you are online")
            setIsControllerConnected(false);
        })

        hub.on("ReceiveControllerConnectionState", (isConnected: boolean) => {
            setIsControllerConnected(isConnected)
        });

        hub.on("ReceiveButtonPress", (inputName: ControllerButtons) => {
            console.log(`Button Pressed: ${inputName}`)
            addInputToHistory(inputName);
        });

        start(hub);

        return function cleanup() {
            stop(hub);
        }
    }, [addInputToHistory, hub, setIsControllerConnected, setStarted, setStatusDescription, setStatusText, start])



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


