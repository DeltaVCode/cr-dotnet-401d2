import React from 'react';
import { useAuth } from '../../contexts/auth';

export default function Login() {
  const { user, login, logout } = useAuth();

  if (user) {
    function handleLogout() {
      logout();
    }

    return (
      <button onClick={handleLogout}>Log Out</button>
    );
  }

  function handleSubmit(e) {
    e.preventDefault();
    const { username, password } = e.target.elements;

    login(username.value);
  }

  return (
    <form onSubmit={handleSubmit}>
      <label>Username <input type="text" name="username" /></label>
      <label>Password <input type="password" name="password" /></label>
      <button>Log In</button>
    </form>
  )
}