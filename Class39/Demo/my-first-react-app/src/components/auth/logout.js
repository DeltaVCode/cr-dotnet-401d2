import React from 'react';
import Auth from './index';
import useAuth from '../../contexts/auth'

export default function Logout() {
  const { logout } = useAuth();

  function handleLogout() {
    logout();
  }

  return (
    <Auth>
      <button onClick={handleLogout}>Logout</button>
    </Auth>
  )
}