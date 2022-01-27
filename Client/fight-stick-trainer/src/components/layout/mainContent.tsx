import { ControllerWithButtonsIcons } from '../icons'
import { HubConnectionState } from '@microsoft/signalr'
import { IRawStyle, mergeStyleSets, Spinner, SpinnerSize } from '@fluentui/react'
import { useAppStore } from '../../store/appStore'
import { useSignalRStore } from '../../communication/signalR'

type MainContentProps = {
    styles?: IMainContentStyles;
}

export interface IMainContentStyles {
    root?: IRawStyle;
}
export const MainContent: React.FunctionComponent<MainContentProps> = ({ styles, children, ...props }) => {

    const { hub } = useSignalRStore();
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

    function showConnectionStateMessages() {

        if (isConnected && hub.state === HubConnectionState.Connected) {
            return children
        }

        if (!isConnected && hub.state === HubConnectionState.Connected) {
            return <h3>No controller connected.</h3>
        }

        if (hub.state === HubConnectionState.Connecting) {
            return <ControllerWithButtonsIcons />
        }

        if (hub.state === HubConnectionState.Reconnecting) {
            return <>
                <h3>Reconnecting to server</h3>
                <Spinner size={SpinnerSize.large} />
            </>
        }

        if (hub.state === HubConnectionState.Disconnected || HubConnectionState.Disconnecting) {
            return <>
                <h3>Unable to connect to the server...Please Refresh</h3>
                <h5>If the problem persists, fix it!</h5>
            </>
        }
    }

    const content = showConnectionStateMessages();

    return <div className={classes.root} >
        {content}
    </div>
}

