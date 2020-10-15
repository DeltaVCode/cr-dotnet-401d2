import React from 'react';
import { useQuery } from 'react-query';

const todoAPI = 'https://deltav-todo.azurewebsites.net/api/v1/Todos';

export default function() {
  const info = useQuery('todo', () => fetch(todoAPI).then(res => res.json()));
  console.log(info);

  if (!info.data) {
    return (<h1>Loading Todos...</h1>);
  }

  return (
    <ul>
      {info.data.map(todo => (
        <li key={todo.id}>{todo.title}</li>
      ))}
    </ul>
  )
}