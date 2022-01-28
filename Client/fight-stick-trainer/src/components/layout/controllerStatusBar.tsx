import { IRawStyle, mergeStyleSets } from '@fluentui/react'
import { lazy } from 'react'

type ControllerStatusBarProps = React.ReactNode & {
    styles?: IControllerStatusBarStyles;
};

export interface IControllerStatusBarStyles {
    root?: IRawStyle;
}

const ControllerConnectionState = lazy(() => import('../icons/controllerConnectionState'));
const WirelessControllerIcon = lazy(() => import('../icons/wirelessControllerIcon'));

export function ControllerStatusBar({ styles }: ControllerStatusBarProps) {

    const defaultStyles: IControllerStatusBarStyles = {
        root: {
            displayName: 'controller-status-bar',
            justifySelf: 'end',
            display: 'grid',
            gridTemplateColumns: 'repeat(8, 5vmin)',
            gridTemplateRows: 'auto',
            justfiyContent: 'center',
            alignContent: 'center',
            alignItems: 'end',
            direction: 'rtl',
            marginRight: '2vmin'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    return <div className={classes.root}>
        <ControllerConnectionState />
        <WirelessControllerIcon />
    </div>
}

export default ControllerStatusBar