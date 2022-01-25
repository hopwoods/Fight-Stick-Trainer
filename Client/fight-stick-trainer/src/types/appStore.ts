export type AppStore = {
    isControllerConnected: boolean;
    inputHistory: string[];
    inputHistoryCount: number;
    setIsControllerConnected: (connectionState: boolean) => void;
    addInputToHistory: (inputName: string) => void;
}