import React from 'react';
import './App.css';
import Counter from './components/Counter'
import People from './components/People'

function App() {
  return (
    <div className="App">
      <People />
      <Counter title="First Counter" />
      <Counter title="Second Counter" />
    </div>
  );
}

export default App;
