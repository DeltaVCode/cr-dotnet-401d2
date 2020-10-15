import React, { useContext, useCallback, useMemo, useState } from 'react';
import jwt from 'jsonwebtoken';

const usersAPI = 'https://deltav-todo.azurewebsites.net/api/v1/Users';

export const AuthContext = React.createContext();

export function useAuth() {
  const auth = useContext(AuthContext);
  if (!auth) throw new Error('You are missing AuthProvider!');
  return auth;
}
export default useAuth;

export function AuthProvider(props) {
  const [user, setUser] = useState(null);

  const login = useCallback(async function login(username, password) {
    const result = await fetch(`${usersAPI}/Login`, {
      method: 'post',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, password }),
    });

    const resultBody = await result.json();

    if (result.ok) {
      let user = processToken(resultBody.token);
      console.log('setting user from token', user);
      setUser(user);
      return !!user; // return true if user is truthy
    }

    // TODO: add an error to show about invalid username/password
    logout();
    return false;
  }, []);

  function logout() {
    setUser(null)
  }

  const hasPermission = useCallback(function hasPermission(permission) {
    return user?.permissions.includes(permission);
  }, [user]);

  const state = useMemo(() => ({
    user,
    timestamp: new Date(),

    login,
    logout,
    hasPermission,
  }), [user, login, hasPermission])

  return (
    <AuthContext.Provider value={state}>
      {props.children}
    </AuthContext.Provider>
  )
}

function processToken(token) {
  if (!token)
    return null;

  try {
    const payload = jwt.decode(token);
    if (payload){
      return {
        id: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
        username: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
        permissions: payload.permissions || [],
      }
    }

    return null;
  }
  catch (e) {
    console.warn(e);
    return null;
  }
}
