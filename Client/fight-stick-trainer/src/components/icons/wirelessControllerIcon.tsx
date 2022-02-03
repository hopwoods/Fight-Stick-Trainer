import wifiIcon from '@iconify/icons-mdi/wifi'
import { HubConnectionState } from '@microsoft/signalr'
import { Icon } from '@iconify/react'
import { IRawStyle, mergeStyleSets } from '@fluentui/react/lib/Styling'
import { lazy } from 'react'
import { useAppStore } from '../../store/appStore'
import { useSignalRStore } from '../../communication/signalR'

type WirelessControllerProps = {
    styles?: IWirelessControllerIconStyles;
}

export interface IWirelessControllerIconStyles {
    root: IRawStyle;
}

const Tooltip = lazy(() => import('../notifications/tooltip'));

export default function WirelessControllerIcon({ styles }: WirelessControllerProps) {

    const { isControllerWireless, isControllerConnected } = useAppStore()
    const { hub } = useSignalRStore();

    const defaultStyles: IWirelessControllerIconStyles = {
        root: {
            displayName: 'wirelees-controller-icon',
            fontSize: '4vmin',
            color: 'lawnGreen'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    if (isControllerConnected && isControllerWireless && hub.state === HubConnectionState.Connected)
        return <Tooltip content="The controller is wireless" id='ControllerIsWirelessTooltip'>
            <span className={classes.root}><Icon icon={wifiIcon} /></span>
        </Tooltip>
    else
        return <></>
}