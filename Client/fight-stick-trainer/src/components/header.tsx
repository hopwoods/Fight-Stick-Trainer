import { appTheme } from '../styles/globalStyles'
import { ControllerConnectionState } from './controllerConnectionState'
import { mergeStyleSets } from '@fluentui/react'
import { XboxLogoIcon } from './icons'

export function Header() {
    const classes = mergeStyleSets({
        appHeader: {
            gridColumn: '1 / span 1',
            gridRow: '1 / span 1',
            display: 'grid',
            gridTemplateColumns: 'auto 10vmin',
            gridTemplateRows: '10vmin',
            alignItems: 'center',
            fontSize: 'calc(10px + 2vmin)',
            color: 'white',
            backgroundColor: appTheme.palette.neutralLighter
        },
        title: {
            gridColumn: '1 / span 1',
            gridRow: '1 / span 1',
            justifySelf: 'start',
            marginLeft: '3vmin',
            height: '7vmin'
        },
        controllerStatus: {
            gridColumn: '2 / span 1',
            gridRow: '1 / span 1',
            justifySelf: 'end',
            marginRight: '3vmin'
        }
    });

    return <header className={classes.appHeader}>
        <div className={classes.title}>
            <XboxLogoIcon styles={{ root: { fontSize: '5vmin', position: 'relative', top: '1.2vmin', display: 'inline-block' } }} /> Fight Stick Trainer
        </div>
        <div className={classes.controllerStatus}>
            <ControllerConnectionState />
        </div>
    </header>
}