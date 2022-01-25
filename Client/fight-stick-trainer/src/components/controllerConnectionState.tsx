import microsoftXboxController from '@iconify/icons-mdi/microsoft-xbox-controller'
import microsoftXboxControllerOff from '@iconify/icons-mdi/microsoft-xbox-controller-off'
import { HubConnectionState } from '@microsoft/signalr'
import { Icon } from '@iconify/react'
import { mergeStyleSets } from '@fluentui/react'
import { useAppStore } from '../store/appStore'
import { useSignalRStore } from '../common/communication/signalR'


export function ControllerConnectionState() {

    const classes = mergeStyleSets({
        green: {
            color: 'LawnGreen'
        },
        red: {
            color: 'darkred'
        }
    });
    const isConnected = useAppStore(state => state.isControllerConnected)
    const { hub } = useSignalRStore();
    if (isConnected && hub.state === HubConnectionState.Connected)
        return <span className={classes.green}><Icon icon={microsoftXboxController} /></span>
    else
        return <span className={classes.red}><Icon icon={microsoftXboxControllerOff} /></span>
}