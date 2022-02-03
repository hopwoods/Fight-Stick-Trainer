import create from 'zustand'
import { BatteryInformation } from '../types'
import { BatteryLevel, BatteryType, ControllerButtons } from '../enums'

type AppStoreProps = {
    isControllerConnected: boolean;
    setIsControllerConnected: (connectionState: boolean) => void;

    isControllerWireless: boolean;
    setIsControllerWireless: (isWireless: boolean) => void;
    
    batteryInfo: BatteryInformation;
    setBatteryInformation: (batteryInformation: BatteryInformation) => void;

    inputHistory: ControllerButtons[];
    inputHistoryCount: number;
    addInputToHistory: (inputName: ControllerButtons) => void;
    clearInputHistory: () => void;    
}

export const useAppStore = create<AppStoreProps>((set, get) => ({

    //Controller Connection
    isControllerConnected: false,
    setIsControllerConnected(connectionState: boolean) { set({ isControllerConnected: connectionState }) },

    //Controller Wireless
    isControllerWireless: false,
    setIsControllerWireless(isWireless: boolean) { set({ isControllerWireless: isWireless }) },

    // Battery Info
    batteryInfo: {
        BatteryType: BatteryType.Disconnected,
        BatteryLevel: BatteryLevel.Empty
    },
    setBatteryInformation(batteryInformation: BatteryInformation) { set({ batteryInfo: batteryInformation }) },

    //Input History
    inputHistory: [],
    inputHistoryCount: 0,
    async addInputToHistory(inputName: ControllerButtons) {
        const inputHistory = get().inputHistory;
        await inputHistory.unshift(inputName); //unshift inserts new item at the start of the array.
        set(state => { state.inputHistoryCount = inputHistory.length });
    },
    clearInputHistory() {
        const inputHistory = get().inputHistory;
        inputHistory.length = 0;
        set(state => { state.inputHistoryCount = inputHistory.length });
    },

}));
