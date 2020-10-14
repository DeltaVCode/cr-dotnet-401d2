import React, { useContext, useState } from 'react';

const usersAPI = 'https://deltav-todo.azurewebsites.net/api/v1/Users';

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
    if (!user) return false;

    return true;
  }

  async function login(username, password) {
    const result = await fetch(`${usersAPI}/Login`, {
      method: 'post',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, password }),
    });

    const resultBody = await result.json();

    if (result.ok) {
      return setUser(resultBody);
    }

    // TODO: add an error to show about invalid username/password
    logout();
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