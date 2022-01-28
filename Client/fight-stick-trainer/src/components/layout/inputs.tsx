import ControllerInputIcon from '../icons/controllerInputIcon'
import { ControllerButtons } from '../../enums'
import { mergeStyleSets } from '@fluentui/react'
import { useAppStore } from '../../store/appStore'
import { useCallback } from 'react'

export function Inputs() {

    const classes = mergeStyleSets({
        history: {
            position: 'relative',
            gridColumn: '1 / span 1',
            gridRow: '2 / span 1',
            overflow: 'hidden',
            display: 'grid',
            gridTemplateColumns: '10vmin',
            gridTemplateRows: 'repeat(18,4vmin)',
            placeItems: 'center',
            alignSelf: 'stretch',
            boxShadow: 'inset -1px 0px 4px 0px rgb(0 0 0 / 50%)',
            borderTopRightRadius: '10px',
            '&::after': {
                background: 'linear-gradient(rgba(0, 0, 0, 0) 50%, rgb(30, 34, 42) 100%)',
                content: "''",
                height: '100%',
                position: 'absolute',
                width: '97%',
                left: 0,
                top: 0
            },
            height: '84vmin',
            paddingTop: '1vmin',
            backgroundColor: 'rgba(30,34,42,1)'
        }
    })

    const inputHistory = useAppStore(useCallback(state => state.inputHistory, []));
    const inputHistoryCount = useAppStore(useCallback(state => state.inputHistoryCount, []));

    if (inputHistoryCount > 0) {
        return <div className={classes.history}>
            {
                inputHistory.map((inputName: ControllerButtons, index: number) => {
                    return <ControllerInputIcon key={index} inputName={inputName} />
                })
            }
        </div>
    }
    else
        return <div className={classes.history}></div>
}

export default Inputs;