import { ClearHistoryButton } from './buttons/clearHistoryButton'
import { ControllerButtons } from '../enums'
import { FaceButton } from './icons/faceButton'
import { HubConnectionState } from '@microsoft/signalr'
import { mergeStyleSets } from '@fluentui/react'
import { useAppStore } from '../store/appStore'
import { useCallback } from 'react'
import { useSignalRStore } from '../communication/signalR'

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
            alignSelf: 'stretch'
        },
        historyLabel: {
            position: 'relative',
            gridColumn: '1 / span 1',
            gridRow: '1 / span 1',
            fontSize: '2vmin',
            paddingTop: '1vmin',
            textShadow: '1px 1px 2px rgb(122 122 122 / 75%)'
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

function Inputs() {

    const classes = mergeStyleSets({
        history: {
            position: 'relative',
            gridColumn: '1 / span 1',
            gridRow: '2 / span 1',
            overflow: 'hidden',
            padding: '2vmin',
            display: 'grid',
            gridTemplateColumns: '15vmin',
            gridTemplateRows: 'repeat(10vmin)',
            justifyContent: 'center',
            alignContent: 'start',
            alignSelf: 'stretch',
            boxShadow: 'inset -1px 0px 4px 0px rgb(0 0 0 / 50%)',
            borderTopRightRadius: '10px',
            '&::after': {
                background: 'linear-gradient(rgba(0, 0, 0, 0) 70%, rgb(40, 44, 52) 100%)',
                content: "''",
                height: '100%',
                position: 'absolute',
                width: '97%',
                left: 0,
                top: 0
            },
            height: '82vmin',
        }
    })

    const inputHistory = useAppStore(useCallback(state => state.inputHistory, []));
    const inputHistoryCount = useAppStore(useCallback(state => state.inputHistoryCount, []));

    if (inputHistoryCount > 0) {
        return <div className={classes.history}>
            {
                inputHistory.map((inputName: ControllerButtons, index: number) => {
                    return <FaceButton key={index} inputName={inputName} />
                })
            }
        </div>
    }
    else
        return <div className={classes.history}></div>
}