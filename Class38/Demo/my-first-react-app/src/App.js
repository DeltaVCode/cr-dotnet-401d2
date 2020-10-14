import React from 'react';
import './App.css';
import Counter from './components/Counter'
import People from './components/People'
import Settings from './components/Settings'
import { useAuth } from './contexts/auth';

function App() {
  const { user } = useAuth();

  return (
    <div className="App">
      <h1>{user ? `Welcome, ${user.username}` : 'Who are you?'}</h1>
      <Settings />
      <People />
      <Counter title="First Counter" />
      <Counter title="Second Counter" />
    </div>
  );
}

export default App;
