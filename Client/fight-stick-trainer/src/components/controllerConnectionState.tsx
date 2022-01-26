import microsoftXboxController from '@iconify/icons-mdi/microsoft-xbox-controller'
import microsoftXboxControllerOff from '@iconify/icons-mdi/microsoft-xbox-controller-off'
import { HubConnectionState } from '@microsoft/signalr'
import { Icon } from '@iconify/react'
import { mergeStyleSets } from '@fluentui/react'
import { Tooltip } from './notifications/tooltip'
import { useAppStore } from '../store/appStore'
import { useSignalRStore } from '../communication/signalR'


export function ControllerConnectionState() {

    const classes = mergeStyleSets({
        icon: {
            fontSize: '4vmin',
        },
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
        return <Tooltip content="The controller is connected" id='ControllerConnectedTooltip'>
            <span className={`${classes.icon} ${classes.green}`}><Icon icon={microsoftXboxController} /></span>
        </Tooltip>
    else
        return <Tooltip content="The controller not connected" id='ControllerDisconnectedTooltip'>
            <span className={`${classes.icon} ${classes.red}`}><Icon icon={microsoftXboxControllerOff} /></span>
        </Tooltip>
}