import { HubConnectionState } from '@microsoft/signalr'
import { IControllerConnectionStateStyles } from '../icons/controllerConnectionState'
import { lazy, useCallback } from 'react'
import { Spinner, SpinnerSize } from '@fluentui/react'
import { useAppStore } from '../../store/appStore'
import { useSignalRStore } from '../../communication/signalR'

const ControllerConnectionState = lazy(() => import('../icons/controllerConnectionState'));

export function useConnectionStateMessage() {

    const { hub, statusText, statusDescription, hubStarted } = useSignalRStore();
    const controllerIsConnected = useAppStore(state => state.isControllerConnected);
    const hubState = hub.state;

    const showConnectionStateMessages = useCallback(() => {

        const controllerConnectionStateStyles: IControllerConnectionStateStyles = {
            root: {
                color: '#ffffff'
            }
        }

        if (!hubStarted && hubState === HubConnectionState.Disconnected) {
            return <div>Disconnected - Unable to connect to the server </div>
        }

        if (!controllerIsConnected && hubState === HubConnectionState.Connected) {
            return <>
                <div><ControllerConnectionState styles={controllerConnectionStateStyles} /></div>
                <div>No Controller connected </div>
            </>
        }

        if (hubStarted && (hubState === HubConnectionState.Reconnecting || HubConnectionState.Disconnected || HubConnectionState.Disconnecting)) {
            return <>
                {`${statusText} - ${statusDescription}`}
                {hubState === HubConnectionState.Reconnecting ? <Spinner size={SpinnerSize.large} styles={{ root: { marginTop: '2vmin' } }} /> : <></ >}
            </>
        }
    }, [hubStarted, hubState, controllerIsConnected, statusDescription, statusText]);

    return { showConnectionStateMessages, controllerIsConnected, hubState }
}