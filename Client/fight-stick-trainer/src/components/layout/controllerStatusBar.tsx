import { ControllerConnectionState } from '../controllerConnectionState'
import { IRawStyle, mergeStyleSets } from '@fluentui/react'

type ControllerStatusBarProps = React.ReactNode & {
    styles?: IControllerStatusBarStyles;
};

export interface IControllerStatusBarStyles {
    root?: IRawStyle;
}

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
    </div>
}