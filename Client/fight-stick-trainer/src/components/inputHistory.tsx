import { ControllerButtons } from '../enums'
import { FaceButton } from './faceButton'
import { HubConnectionState } from '@microsoft/signalr'
import { mergeStyleSets } from '@fluentui/react'
import { useAppStore } from '../store/appStore'
import { useCallback } from 'react'
import { useSignalRStore } from '../common/communication/signalR'



export function InputHistory() {

    const { hub } = useSignalRStore();
    const isConnected = useAppStore(state => state.isControllerConnected);

    const classes = mergeStyleSets({
        inputHistory: {
            maxHeight: '90%',
            overflowX: 'hidden',
            padding: '3vmin'
        }
    });

    if (isConnected && hub.state === HubConnectionState.Connected) {
        return <div className={classes.inputHistory}>
            <Inputs />
        </div>
    }
    else if (hub.state === HubConnectionState.Disconnected) {
        return <div className={classes.inputHistory}>
            <h6>Unable to contact server. Please refresh.</h6>
        </div>
    }
    return <></>
}

function Inputs() {

    const inputHistory = useAppStore(useCallback(state => state.inputHistory, []));
    const inputHistoryCount = useAppStore(useCallback(state => state.inputHistoryCount, []));

    if (inputHistoryCount > 0) {
        return <>
            {
                inputHistory.map((inputName: ControllerButtons, index: number) => {
                    return <FaceButton key={index} inputName={inputName} />
                })
            }
        </>
    }
    else
        return <></>
}