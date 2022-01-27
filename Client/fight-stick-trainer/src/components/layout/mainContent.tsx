import { ControllerConnectionState } from '../controllerConnectionState'
import { HubConnectionState } from '@microsoft/signalr'
import {
    IMessageBarStyles,
    IRawStyle,
    mergeStyleSets,
    MessageBar,
    MessageBarType,
    Spinner,
    SpinnerSize
    } from '@fluentui/react'
import { useAppStore } from '../../store/appStore'
import { useCallback } from 'react'
import { useSignalRStore } from '../../communication/signalR'

type MainContentProps = {
    styles?: IMainContentStyles;
}

export interface IMainContentStyles {
    root?: IRawStyle;
}
export const MainContent: React.FunctionComponent<MainContentProps> = ({ styles, children, ...props }) => {

    const { hub, statusText, statusDescription, hubStarted } = useSignalRStore();
    const isConnected = useAppStore(state => state.isControllerConnected);

    const defaultStyles: IMainContentStyles = {
        root: {
            displayName: 'main-content',
            display: 'grid',
            gridTemplateColumns: 'auto',
            gridTemplateRows: 'auto',
            justifyContent: 'center',
            alignContent: 'center',
            alignSelf: 'stretch'
        }
    }

    const classes = mergeStyleSets(defaultStyles, styles);


    const showConnectionStateMessages = useCallback(() => {

        const hubState = hub.state;

        const messageBarStyles: IMessageBarStyles = {
            content: {
                fontSize: '4vmin'
            }
        }

        console.log(`Hub connection is: ${hubState}`)
        console.log(`Hub start is: ${hubStarted}`)

        if (isConnected && hubState === HubConnectionState.Connected) {
            return children
        }

        if (!isConnected && hubState === HubConnectionState.Connected) {

            const classes = mergeStyleSets({
                notConnected: {
                    displayName: "not-connected",
                    textAlign: 'center'
                }
            })
            return <div className={classes.notConnected}>
                <div><ControllerConnectionState /></div>
                <div>No Controller connected</div>
            </div>

        }

        if (hubStarted && (hubState === HubConnectionState.Reconnecting || HubConnectionState.Disconnected || HubConnectionState.Disconnecting)) {
            return <MessageBar messageBarType={MessageBarType.error} styles={messageBarStyles}>
                {`${statusText} - ${statusDescription}`}
                {hubState === HubConnectionState.Reconnecting ? <Spinner size={SpinnerSize.large} /> : <></>}
            </MessageBar>
        }

        if (!hubStarted && hubState === HubConnectionState.Disconnected) {
            return <MessageBar messageBarType={MessageBarType.error} styles={messageBarStyles}>
                Disconnected - Unable to connect to the server...Please check to see if you are online
            </MessageBar>
        }
    }, [children, hub.state, hubStarted, isConnected, statusDescription, statusText]);

    const content = showConnectionStateMessages();

    return <div className={classes.root} >
        {content}
    </div>
}

