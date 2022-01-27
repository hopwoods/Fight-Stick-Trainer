import create from 'zustand'
import { ControllerButtons } from '../enums'

type AppStoreProps = {
    isControllerConnected: boolean;

    inputHistory: ControllerButtons[];
    inputHistoryCount: number;
    addInputToHistory: (inputName: ControllerButtons) => void;
    clearInputHistory: () => void;

    setIsControllerConnected: (connectionState: boolean) => void;
}

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
