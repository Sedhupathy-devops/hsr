import React from 'react';
import Calculator from './Calculator';
import './App.css';
import '../node_modules/jquery/dist/jquery';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../node_modules/bootstrap/dist/js/bootstrap.bundle';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Calculator />
      </header>
    </div>
  );
}

export default App;
