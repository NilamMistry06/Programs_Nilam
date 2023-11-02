import React from 'react';
import ReactDOM from 'react-dom/client';
import './test.css';
import App from './App';
import reportWebVitals from './reportWebVitals';


var element = React.createElement('h1', { className: 'greeting' }, 'Hello, world for test');

const root = ReactDOM.createRoot(document.getElementById('testroot'));
root.render(
  <React.StrictMode>
    <App />
    {element}
  </React.StrictMode>
);