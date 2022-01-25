import create from 'zustand'
import { ControllerButtons } from '../../enums'
import { HubConnection, HubConnectionBuilder, HubConnectionState, LogLevel } from '@microsoft/signalr'
import { SignalRProps, SignalRStoreProps } from '../../types'
import { useAppStore } from '../../store/appStore'
import { useEffect } from 'react'


function configureHubConnection() {
    const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:7064/hub")
        .configureLogging(LogLevel.Information)
        .withAutomaticReconnect()
        .build();

    return connection;
}

function start(connection: HubConnection) {
    if (connection.state === HubConnectionState.Disconnected) {
        connection.start().catch(err => (console.error(err)));
    }
}

function stop(connection: HubConnection) {
    if (connection.state === HubConnectionState.Disconnected) {
        connection.stop().catch(err => (console.error(err)));
    }
}

export const useSignalRStore = create<SignalRStoreProps>(() => ({
    hub: configureHubConnection(),
}));


export const SignalR: React.FunctionComponent = ({ children, ...props }) => {

    const { setIsControllerConnected, addInputToHistory } = useAppStore();
    const { hub } = useSignalRStore();

    useEffect(() => {

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
    }, [addInputToHistory, hub, setIsControllerConnected])

    return <>
        {children}
    </>
}