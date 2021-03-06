import { HubConnectionState } from '@microsoft/signalr'
import { IConnectionAlertStyles } from '../notifications/connectionAlert'
import { IFooterStyles } from './footer'
import { IRawStyle, mergeStyleSets } from '@fluentui/react'
import { lazy } from 'react'
import { useConnectionStateMessage } from './mainContent.vm'

const Footer = lazy(() => import('./footer'));
const ConnectionAlert = lazy(() => import('../notifications/connectionAlert'));

type MainContentProps = {
    styles?: IMainContentStyles;
}

export interface IMainContentStyles {
    root?: IRawStyle;
}

export const MainContent: React.FunctionComponent<MainContentProps> = ({ styles, children, ...props }) => {

    const { showConnectionStateMessages, controllerIsConnected, hubState } = useConnectionStateMessage();

    const defaultStyles: IMainContentStyles = {
        root: {
            displayName: 'main-content',
            display: 'grid',
            gridTemplateColumns: '1fr',
            gridTemplateRows: '84vmin 4vmin',
            placeItems: 'center',
            placeContent: 'center',
            placeSelf: 'stretch',
            height: '100%',
            background: 'radial-gradient(at 50% 178%, rgb(0 153 61 / 18%) 15%, rgb(33 42 46 / 60%) 75%, rgb(40 44 52) 100%)'
        }
    }
    const alertContent = showConnectionStateMessages();
    const classes = mergeStyleSets(defaultStyles, styles);
    const connectionAlertStyles: IConnectionAlertStyles = {
        root: {
            position: 'relative',
            right: '4vmin',
            gridColumn: '1 / span 1',
            gridRow: '1 / span 1'
        }
    }

    const footerStyles: IFooterStyles = {
        root: {
            gridColumn: '1 / span 1',
            gridRow: '2 / span 1'
        }
    }

    if (controllerIsConnected && hubState === HubConnectionState.Connected) {
        return <div className={classes.root}>
            <>{children}</>
            <Footer styles={footerStyles} />
        </div>
    }
    else
        return <div className={classes.root} >
            <ConnectionAlert styles={connectionAlertStyles}>
                {alertContent}
            </ConnectionAlert>
            <Footer styles={footerStyles} />
        </div>
}

export default MainContent;