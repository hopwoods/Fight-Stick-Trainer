import { InputButton } from './inputButton'
import { useCallback, useEffect } from 'react'
import { useStore } from '../store/appStore'

export function InputHistory() {
    const inputHistory = useStore(useCallback(state => state.inputHistory, []));
    const inputHistoryCount = useStore(useCallback(state => state.inputHistoryCount, []));

    useEffect(() => {
        console.log(inputHistory);
        console.log(inputHistoryCount);
    }, [inputHistory, inputHistoryCount])

    const Inputs = useCallback(() => {
        if (inputHistoryCount > 0) {
            return <>
                {
                    inputHistory.map((inputName: string, index: number) => {
                        return <InputButton key={index} inputName={inputName} />
                    })
                }
            </>
        }
        else
            return <></>

    }, [inputHistory, inputHistoryCount])


    return <div className='Input-History'>
        <Inputs />
    </div>
}