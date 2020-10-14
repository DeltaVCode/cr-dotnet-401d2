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

  async function handleSubmit(e) {
    e.preventDefault();
    // Pull value out so we can access form after the await
    const { target } = e;

    const { username, password } = target.elements;

    if (!await login(username.value, password.value))
    {
      target.reset();
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <label>Username <input type="text" name="username" /></label>
      <label>Password <input type="password" name="password" /></label>
      <button>Log In</button>
    </form>
  )
}