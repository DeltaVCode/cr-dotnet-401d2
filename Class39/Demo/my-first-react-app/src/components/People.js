import React, {useState} from 'react';
import Auth from './auth';

export default function People(props) {
  const [people, setPeople] = useState([
    { name: 'Keith' }
  ]);

  function savePerson(person) {
    // DO NOT USE push

    // setPeople(people.concat(person));

    // Or use ES6 spread
    setPeople([person, ...people]);
  }

  function deletePersonByIndex(indexToRemove) {
    console.log(indexToRemove);
    setPeople(people.filter((person, idx) => idx !== indexToRemove));
  }

  function togglePersonAttending(index) {
    console.log(index);
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

  return (
    <>
      <h1>People!</h1>
      <PeopleForm onSave={savePerson} />
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