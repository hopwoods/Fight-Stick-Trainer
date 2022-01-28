import { HubConnectionState } from '@microsoft/signalr'
import { lazy } from 'react'
import { mergeStyleSets } from '@fluentui/react'
import { useAppStore } from '../../store/appStore'
import { useSignalRStore } from '../../communication/signalR'

const ClearHistoryButton = lazy(() => import('../buttons/clearHistoryButton'));
const Inputs = lazy(() => import('./inputs'));

export function InputHistory() {

    const { hub } = useSignalRStore();
    const isConnected = useAppStore(state => state.isControllerConnected);

    const classes = mergeStyleSets({
        inputHistory: {
            position: 'relative',
            gridColumn: '1 / span 1',
            gridRow: '1 / span 1',
            overflow: 'hidden',
            display: 'grid',
            gridTemplateColumns: '10vmin',
            gridTemplateRows: '8vmin, auto',
            justifyContent: 'center',
            alignContent: 'start',
            alignSelf: 'stretch',
            padding: 0,
        },
        historyLabel: {
            position: 'relative',
            gridColumn: '1 / span 1',
            gridRow: '1 / span 1',
            fontSize: '2vmin',
            padding: '0',
            paddingTop: '1.5vmin',
            textShadow: '1px 1px 2px rgb(122 122 122 / 75%)',
            alignSelf: 'stretch',
            placeItems: 'center'
        }
    })

    if (isConnected && hub.state === HubConnectionState.Connected) {
        return <div className={classes.inputHistory}>
            <div className={classes.historyLabel}>
                <ClearHistoryButton />
            </div>
            <Inputs />
        </div>
    }
    else if (!isConnected && hub.state === HubConnectionState.Connected) {
        return <></>
    }
    else if (hub.state === (HubConnectionState.Reconnecting || HubConnectionState.Disconnecting || HubConnectionState.Disconnected)) {
        return <></>
    }
    return <></>
}
export default InputHistory;