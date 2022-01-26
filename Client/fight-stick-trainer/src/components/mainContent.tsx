import { HubConnectionState } from '@microsoft/signalr'
import { mergeStyleSets, Spinner, SpinnerSize } from '@fluentui/react'
import { useAppStore } from '../store/appStore'
import { useSignalRStore } from '../communication/signalR'

export const MainContent: React.FunctionComponent = ({ children, ...props }) => {

    const { hub } = useSignalRStore();
    const isConnected = useAppStore(state => state.isControllerConnected);

    const classes = mergeStyleSets({
        mainContent: {
            position: 'relative',
            gridColumn: '2 / span 1',
            gridRow: '1 / span 1',
            display: 'grid',
            gridTemplateColumns: 'auto',
            gridTemplateRows: 'auto',
            justifyContent: 'center',
            alignContent: 'center',
            alignSelf: 'stretch'
        }
    })

    if (isConnected && hub.state === HubConnectionState.Connected) {
        return <div className={classes.mainContent}>
            {children}
        </div>
    }
    else if (!isConnected && hub.state === HubConnectionState.Connected) {
        return <div className={classes.mainContent}>
            <h3>No controller connected</h3>
        </div>
    }
    if (hub.state === HubConnectionState.Reconnecting) {
        return <div className={classes.mainContent}>
            <h3>Reconnecting to server</h3>
            <Spinner size={SpinnerSize.large} />
        </div>
    }
    if (hub.state === HubConnectionState.Disconnected) {
        return <div className={classes.mainContent}>
            <h3>Unable to connect to the server...Please Refresh</h3>
            <h5>If the problem persists, fix it!</h5>
        </div>
    }

    return <div className={classes.mainContent}>
        <h3>Unable to connect to the server...Please Refresh</h3>
        <h5>If the problem persists, fix it!</h5>
    </div>

}

