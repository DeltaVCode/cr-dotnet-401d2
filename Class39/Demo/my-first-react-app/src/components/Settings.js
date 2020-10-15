import React from 'react';
import { useTheme } from '../contexts/theme';

export default function Settings() {
  const theme = useTheme();

  function handleChange() {
    // Update the context with the function it exports
    theme.toggleMode();
  }

  return (
    <form>
      <label>
        Enable dark mode?
        <input type="checkbox" onClick={handleChange} />
      </label>
    </form>
  )
}