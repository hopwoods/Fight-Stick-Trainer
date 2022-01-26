import { ControllerButtons } from '../enums'

export type AppStoreProps = {
    isControllerConnected: boolean;

    inputHistory: ControllerButtons[];
    inputHistoryCount: number;
    addInputToHistory: (inputName: ControllerButtons) => void;
    clearInputHistory: () => void;

    setIsControllerConnected: (connectionState: boolean) => void;
}