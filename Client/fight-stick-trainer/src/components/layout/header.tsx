import { appTheme } from '../../styles/globalStyles'
import { ControllerStatusBar } from './controllerStatusBar'
import { IControllerButtonStyles } from '../../types'
import { IRawStyle, mergeStyleSets } from '@fluentui/react'
import { ITitleStyles, Title } from './title'

type HeaderProps = React.ReactNode & {
    styles?: IHeaderStyles;
};

export interface IHeaderStyles {
    root?: IRawStyle;
}

export function Header({ styles }: HeaderProps) {

    const defaultStyles: IHeaderStyles = {
        root: {
            displayName: 'header',
            display: 'grid',
            gridTemplateColumns: 'auto 50vmin',
            gridTemplateRows: '10vmin',
            alignItems: 'center',
            fontSize: 'calc(10px + 2vmin)',
            color: 'white',
            backgroundColor: appTheme.palette.neutralLighter
        }
    }

    const titleStyles: ITitleStyles = {
        root: {
            gridColumn: '1 / span 1',
            gridRow: '1 / span 1',
        }
    }

    const controllerStatusBarStyles: IControllerButtonStyles = {
        root: {
            gridColumn: '2 / span 1',
            gridRow: '1 / span 1',
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);

    return <header className={classes.root}>
        <Title styles={titleStyles} />
        <ControllerStatusBar styles={controllerStatusBarStyles} />
    </header>
}