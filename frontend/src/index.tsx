import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { BrowserRouter } from 'react-router-dom';
import { AuthContext } from './context/Context';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <BrowserRouter>
    <AuthContext.Provider value={sessionStorage.getItem("token") || ""}>
      <App />
      </AuthContext.Provider>
    </BrowserRouter>
  </React.StrictMode>
);
