import App from './App'
import React from 'react'
import ReactDOM from 'react-dom'
import reportWebVitals from './reportWebVitals'
import { AppStyling } from './styles/globalStyles'
import { registerIcons } from './styles/registerIcons'
import { SignalR } from './communication/signalR'
import './index.css'

registerIcons();

ReactDOM.render(
  <React.StrictMode>
    <SignalR>
      <AppStyling>
        <App />
      </AppStyling>
    </SignalR>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
