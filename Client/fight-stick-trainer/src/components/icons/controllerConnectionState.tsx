import microsoftXboxController from '@iconify/icons-mdi/microsoft-xbox-controller'
import microsoftXboxControllerOff from '@iconify/icons-mdi/microsoft-xbox-controller-off'
import { HubConnectionState } from '@microsoft/signalr'
import { Icon } from '@iconify/react'
import { IRawStyle, mergeStyleSets } from '@fluentui/react'
import { Tooltip } from '../notifications/tooltip'
import { useAppStore } from '../../store/appStore'
import { useSignalRStore } from '../../communication/signalR'

type ControllerConnectionStateProps = {
    styles?: IControllerConnectionStateStyles;
}

export interface IControllerConnectionStateStyles {
    root: IRawStyle;
}

export function ControllerConnectionState({ styles }: ControllerConnectionStateProps) {

    const isConnected = useAppStore(state => state.isControllerConnected)
    const { hub } = useSignalRStore();

    const defaultStyles: IControllerConnectionStateStyles = {
        root: {
            displayName: 'controller-connection-state',
            fontSize: '4vmin',
            color: isConnected ? 'LawnGreen' : 'darkred'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);


    if (isConnected && hub.state === HubConnectionState.Connected)
        return <Tooltip content="The controller is connected" id='ControllerConnectedTooltip'>
            <span className={classes.root}><Icon icon={microsoftXboxController} /></span>
        </Tooltip>
    else
        return <Tooltip content="The controller not connected" id='ControllerDisconnectedTooltip'>
            <span className={classes.root}><Icon icon={microsoftXboxControllerOff} /></span>
        </Tooltip>
}