import React, { useContext, useState } from 'react';

export const AuthContext = React.createContext();

export function useAuth() {
  const auth = useContext(AuthContext);
  if (!auth) throw new Error('You are missing AuthProvider!');
  return auth;
}

export function AuthProvider(props) {
  const [state, setState] = useState({
    user: null,

    // Functions!
    login,
    logout,
  });

  function setUser(user) {
    setState(prevState => ({
      ...prevState,
      user,
    }));
  }

  function login(username, password) {
    console.log('Auth!', username);
    setUser({ username })
  }

  function logout() {
    setUser(null)
  }

  return (
    <AuthContext.Provider value={state}>
      {props.children}
    </AuthContext.Provider>
  )
}