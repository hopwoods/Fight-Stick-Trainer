import * as signalR from '@microsoft/signalr'
import { ControllerConnectionState } from './components/controllerConnectionState'
import { InputHistory } from './components/inputHistory'
import { useStore } from './store/appStore'
import './App.css'

function App() {

  const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7064/hub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

  const setIsControllerConnected = useStore(state => state.setIsControllerConnected);
  const addInputToHistory = useStore(state => state.addInputToHistory);

  connection.on("ReceiveControllerConnectionState", (isConnected: boolean) => {
    setIsControllerConnected(isConnected)
  });

  connection.on("ReceiveButtonPress", (inputName: string) => {
    console.log(`Button Pressed: ${inputName}`)
    addInputToHistory(inputName);
  });

  connection.start().catch(err => (console.error(err)));

  return (
    <div className="App">
      <header className="App-header">
        <h1>Fight Stick Trainer</h1>
        <h3>Controller Status: <ControllerConnectionState /></h3>
      </header>
      <section className='App-content'>
        <InputHistory />
      </section>
    </div>
  );
}

export default App;
