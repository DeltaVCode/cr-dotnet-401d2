import React from 'react';
import './App.css';
import Counter from './components/Counter'
import People from './components/People'
import Settings from './components/Settings'
import { useAuth } from './contexts/auth';
import Login from './components/auth/login'
import Logout from './components/auth/logout'
import Auth from './components/auth'; // index.js

function App() {
  const { user, hasPermission } = useAuth();

  return (
    <div className="App">
      <h1>{user ? `Welcome, ${user.username}` : 'Who are you?'}</h1>
      <Auth>
        <h2>User can delete? {hasPermission('delete') ? 'Yes' : 'No'}</h2>
      </Auth>
      <Login />
      <Settings />
      <Auth>
        <People />
      </Auth>
      <Counter title="First Counter" />
      <Logout />
      <Counter title="Second Counter" />
    </div>
  );
}

export default App;
