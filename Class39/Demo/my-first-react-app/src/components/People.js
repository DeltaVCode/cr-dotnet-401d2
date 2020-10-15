import React, { useEffect, useState } from 'react';
import Auth from './auth';
import useAuth from '../contexts/auth';

// Should be in .env as REACT_APP_API_SERVER instead of hard coded
const todoAPI = 'https://deltav-todo.azurewebsites.net/api/v1/Todos';

const mapTaskToPerson = task => ({
  id: task.id,
  name: task.assignedTo,
  attending: task.completed,
});

export default function People(props) {
  const { user: { token } } = useAuth();

  const [loading, setLoading] = useState(true);
  const [people, setPeople] = useState([]);

  useEffect(() => {
    console.log('Run me once when the component loads');

    async function fetchPeople() {
      // Slow down so we can see Loading...
      await delay(2000);

      let response = await fetch(todoAPI);
      let tasks = await response.json();
      console.log(tasks);
      setPeople(tasks.map(mapTaskToPerson));
      setLoading(false);
    }
    fetchPeople();

    // "Dispose" action
    return () => {
      console.log('Run me when component goes away')
    }
  }, []);

  // Run this function only if people.length has changed
  useEffect(() => {
    document.title = `People: ${people.length}`;
    console.log('changed title to ', document.title)
  }, [people.length])

  useEffect(() => {
    console.log('Run me every render');
  });

  console.log('Component function was called')

  async function savePerson(person) {
    // DO NOT USE push

    // setPeople(people.concat(person));

    // Or use ES6 spread
    // setPeople([person, ...people]);

    let response = await fetch(todoAPI, {
      method: 'post',
      body: JSON.stringify({
        "title": 'Attend event',
        "difficulty": 1,
        "assignedTo": person.name,
        "completed": false
      }),
      headers: {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json',
      },
    })
    let task = await response.json();
    setPeople([...people, mapTaskToPerson(task)])
  }

  async function deletePersonByIndex(indexToRemove) {
    let personToRemove = people[indexToRemove];

    setPeople(people.filter((person, idx) => idx !== indexToRemove));

    await fetch(`${todoAPI}/${personToRemove.id}`, {
      method: 'delete',
      headers: {
        'Authorization': `Bearer ${token}`,
      },
    });
  }

  function togglePersonAttending(index) {
    const newPeople = people.map((person, idx) => (
      idx !== index ? person :
        {
          ...person,
          attending: !person.attending
        }
    ));

    setPeople(newPeople);
    return;

    // longer way, not so idiomatic
    // let arr = []
    // for(let i = 0; i < people.length; i++) {
    //   if (i === index) {
    //     arr[index] = {
    //       // First, copy everything from the current person
    //       ...people[i],

    //       // Replace/set some properties
    //       copiedAt: new Date(),
    //       status: !people[i].status,
    //     };
    //   }
    //   else {
    //     arr[i] = people[i]
    //   }
    // }
    // console.log(arr);
    // setPeople(arr);
  }

  if (loading) {
    return <h1>People loading...</h1>
  }

  return (
    <>
      <h1>People!</h1>
      <Auth permission='create'>
        <PeopleForm onSave={savePerson} />
      </Auth>
      <PeopleList people={people}
         onDelete={deletePersonByIndex}
         onRsvp={togglePersonAttending} />
    </>
  )
}


function PeopleForm(props) {
  const { onSave } = props;

  function handleSubmit(e) {
    e.preventDefault();

    // e.target = the form that was submitted
    // Grab reference to the name input
    const { name } = e.target;

    const person = {
      name: name.value,
    };

    onSave(person);
  }

  return (
    <form onSubmit={handleSubmit}>
      <label>Name 
        <input name="name" />
      </label>
      <button>Save</button>
    </form>
  );
}

function PeopleList(props) {
  const { people, onDelete, onRsvp } = props;

  return (
    <ul>
      {people.map((person, idx) => (
        <li key={idx}>
          {person.name}
          <p>Attending: {person.attending ? 'Yes' : 'No'}</p>
          <Auth permission='update'>
            <input type="checkbox" checked={person.attending} onChange={() => onRsvp(idx)} />
          </Auth>
          <Auth permission='delete'>
            <button onClick={() => onDelete(idx)}>Delete</button>
          </Auth>
        </li>
      ))}
    </ul>
  )
}

function delay(timeout) {
  return new Promise((resolve) => {
    setTimeout(resolve, timeout);
  });
}