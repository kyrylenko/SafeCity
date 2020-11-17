import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import './index.css';
import App from './App';
import auth from './services/auth';
import * as serviceWorker from './serviceWorker';

auth.load(updateSigninStatus);

function updateSigninStatus(isSignedIn: boolean) {
  console.log(`app loaded, signed in: ${isSignedIn} token: ${auth.getToken()}`);
}

const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter>
    <React.StrictMode>
      <App />
    </React.StrictMode>
  </BrowserRouter >,
  rootElement);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
