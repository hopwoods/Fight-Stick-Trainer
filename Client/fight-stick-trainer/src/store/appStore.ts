import create from 'zustand'
import { AppStoreProps } from '../types'
import { ControllerButtons } from '../enums'

export const useAppStore = create<AppStoreProps>((set, get) => ({

    //Controller Connection
    isControllerConnected: false,
    setIsControllerConnected(connectionState: boolean) { set({ isControllerConnected: connectionState }) },

    //Input History
    inputHistory: [],
    inputHistoryCount: 0,
    addInputToHistory(inputName: ControllerButtons) {
        const inputHistory = get().inputHistory;
        inputHistory.unshift(inputName); //unshift inserts new item at the start of the array.
        set(state => { state.inputHistoryCount = inputHistory.length });
    },
    clearInputHistory() {
        const inputHistory = get().inputHistory;
        inputHistory.length = 0;
        set(state => { state.inputHistoryCount = inputHistory.length });
    },

}));
