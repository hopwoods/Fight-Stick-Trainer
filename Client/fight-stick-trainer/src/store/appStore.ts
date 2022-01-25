import create from 'zustand'
import { AppStoreProps } from '../types'
import { ControllerButtons } from '../enums'

export const useAppStore = create<AppStoreProps>((set, get) => ({
    isControllerConnected: false,
    inputHistory: [],
    inputHistoryCount: 0,
    setIsControllerConnected(connectionState: boolean) { set({ isControllerConnected: connectionState }) },
    addInputToHistory(inputName: ControllerButtons) {
        const inputHistory = get().inputHistory;
        inputHistory.push(inputName);
        set(state => { state.inputHistoryCount = inputHistory.length });
    },
}));
