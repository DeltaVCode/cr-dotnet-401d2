import React from 'react';
import './App.css';
import Counter from './components/Counter'

function App() {
  return (
    <div className="App">
      <Counter title="First Counter" />
      <Counter title="Second Counter" />
    </div>
  );
}

export default App;
