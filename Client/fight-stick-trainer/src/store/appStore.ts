import create from 'zustand'
import { AppStore } from '../types/appStore'

export const useStore = create<AppStore>((set, get) => ({
    isControllerConnected: false,
    inputHistory: [],
    inputHistoryCount: 0,
    setIsControllerConnected(connectionState: boolean) { set({ isControllerConnected: connectionState }) },
    addInputToHistory(inputName: string) {
        const inputHistory = get().inputHistory;
        inputHistory.push(inputName);
        set(state => { state.inputHistoryCount = inputHistory.length });
    },
}));
