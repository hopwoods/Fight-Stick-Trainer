import { ControllerButtons } from '../enums'

export type AppStoreProps = {
    isControllerConnected: boolean;
    inputHistory: ControllerButtons[];
    inputHistoryCount: number;
    setIsControllerConnected: (connectionState: boolean) => void;
    addInputToHistory: (inputName: ControllerButtons) => void;
}