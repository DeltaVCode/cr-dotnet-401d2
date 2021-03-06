import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { AuthProvider } from './contexts/auth';
import { ThemeProvider } from './contexts/theme';
import * as serviceWorker from './serviceWorker';

import { QueryCache, ReactQueryCacheProvider } from 'react-query'
 
const queryCache = new QueryCache()
 
ReactDOM.render(
  <React.StrictMode>
    <AuthProvider>
      <ReactQueryCacheProvider queryCache={queryCache}>
        <ThemeProvider>
          <App />
        </ThemeProvider>
      </ReactQueryCacheProvider>
    </AuthProvider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
