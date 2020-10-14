import React, { useContext, useState } from 'react';

export const ThemeContext = React.createContext();

// Custom Hook
export function useTheme() {
  return useContext(ThemeContext);
}

export function ThemeProvider (props) {
  const { children, defaultMode } = props;

  const [state, setState] = useState({
    // Actual state values to track
    mode: defaultMode || 'light',

    // This is weird, but we are adding a *function* to state
    toggleMode: () =>
      // need to specify prevState so we don't use closure on original state
      setState(prevState => {
        return ({
          ...prevState,
          mode: prevState.mode === 'light' ? 'dark' : 'light'
        });
      }),
  });

  return (
    <ThemeContext.Provider value={state}>
      {children}
    </ThemeContext.Provider>
  )
}
