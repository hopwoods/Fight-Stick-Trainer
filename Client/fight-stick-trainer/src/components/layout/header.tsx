import { ControllerStatusBar } from './controllerStatusBar'
import { IControllerButtonStyles } from '../../types'
import { IRawStyle, mergeStyleSets } from '@fluentui/react'
import { ITitleStyles, Title } from './title'

type HeaderProps = React.ReactNode & {
    styles?: IHeaderStyles;
};

export interface IHeaderStyles {
    root?: IRawStyle;
    rainbow?: IRawStyle;
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
            background: 'linear-gradient(180deg, rgba(40,44,58,1) 0%, rgba(50,54,62,1) 100%)',
            borderBottom: '1px solid rgba(30,34,42,1)',
            boxShadow: '2px 0 3px rgba(0,0,0,70%)'
        },
        rainbow: {
            alignSelf: 'stretch',
            justifySelf: 'stretch',
            background: 'linear-gradient(270deg, rgba(84,255,82,1) 0%, rgba(193,255,82,1) 20%, rgba(83,255,91,1) 40%, rgba(83,200,177,1) 60%, rgba(83,225,166,1) 80%, rgba(84,255,82,1) 100%)',
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

    return <>
        <div className={classes.rainbow}></div>
        <header className={classes.root}>
            <Title styles={titleStyles} />
            <ControllerStatusBar styles={controllerStatusBarStyles} />
        </header>
    </>
}