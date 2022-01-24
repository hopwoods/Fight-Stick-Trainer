import * as signalR from '@microsoft/signalr'
import React from 'react'
import './App.css'

const connection = new signalR.HubConnectionBuilder()
  .withUrl("/hub")
  .build();

let isControllerConnected: boolean;

connection.on("messageReceived", (isConnected: boolean) => {
  isControllerConnected = isConnected;
});

connection.start().catch(err => (err));

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Fight Stick Trainer</h1>
      </header>
      <section>
        <div>Controller Status: {isControllerConnected ? "Connected" : "Disconnected"}</div>
      </section>
    </div>
  );
}

export default App;
