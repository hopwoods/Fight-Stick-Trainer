import microsoftXboxControllerBatteryAlert from '@iconify/icons-mdi/microsoft-xbox-controller-battery-alert'
import microsoftXboxControllerBatteryCharging from '@iconify/icons-mdi/microsoft-xbox-controller-battery-charging'
import microsoftXboxControllerBatteryFull from '@iconify/icons-mdi/microsoft-xbox-controller-battery-full'
import microsoftXboxControllerBatteryLow from '@iconify/icons-mdi/microsoft-xbox-controller-battery-low'
import microsoftXboxControllerBatteryMedium from '@iconify/icons-mdi/microsoft-xbox-controller-battery-medium'
import Tooltip from '../notifications/tooltip'
import { BatteryLevel, BatteryType } from '../../enums'
import { HubConnectionState } from '@microsoft/signalr'
import { Icon } from '@iconify/react'
import { IRawStyle, mergeStyleSets } from '@fluentui/react/lib/Styling'
import { useAppStore } from '../../store/appStore'
import { useSignalRStore } from '../../communication/signalR'


type BatteryInfoIconProps = {
    styles?: IBatteryInfoIconStyles;
}

export interface IBatteryInfoIconStyles {
    root: IRawStyle;
}


export default function BatteryInfoIcon({ styles }: BatteryInfoIconProps) {

    const { batteryInfo, isControllerConnected } = useAppStore()
    const { hub } = useSignalRStore();

    const defaultStyles: IBatteryInfoIconStyles = {
        root: {
            displayName: 'wirelees-controller-icon',
            fontSize: '4vmin',
            color: 'lawnGreen'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    if (isControllerConnected && hub.state === HubConnectionState.Connected) {

        if (batteryInfo.BatteryType === BatteryType.Wired) {
            return <Tooltip content="The controller is plugged in." id='batteryInfo'>
                <span className={classes.root}><Icon icon={microsoftXboxControllerBatteryCharging} /></span>
            </Tooltip>
        }
        else if (batteryInfo.BatteryLevel === BatteryLevel.Empty) {
            return <Tooltip content="The battery level is empty" id='batteryInfo'>
                <span className={classes.root}><Icon icon={microsoftXboxControllerBatteryAlert} /></span>
            </Tooltip>
        }
        else if (batteryInfo.BatteryLevel === BatteryLevel.Low) {
            return <Tooltip content="The battery level is low" id='batteryInfo'>
                <span className={classes.root}><Icon icon={microsoftXboxControllerBatteryLow} /></span>
            </Tooltip>
        }
        else if (batteryInfo.BatteryLevel === BatteryLevel.Medium) {
            return <Tooltip content="The battery level is medium" id='batteryInfo'>
                <span className={classes.root}><Icon icon={microsoftXboxControllerBatteryMedium} /></span>
            </Tooltip>
        }
        else if (batteryInfo.BatteryLevel === BatteryLevel.Full) {
            return <Tooltip content="The battery level is full" id='batteryInfo'>
                <span className={classes.root}><Icon icon={microsoftXboxControllerBatteryFull} /></span>
            </Tooltip>
        }
    }

    return <></>
}