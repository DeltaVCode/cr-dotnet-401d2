import React from 'react';
import './App.css';
import Counter from './components/Counter'
import People from './components/People'
import Settings from './components/Settings'

function App() {
  return (
    <div className="App">
      <Settings />
      <People />
      <Counter title="First Counter" />
      <Counter title="Second Counter" />
    </div>
  );
}

export default App;
