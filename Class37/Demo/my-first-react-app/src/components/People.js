import React, {useState} from 'react';

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

  return (
    <>
      <h1>People!</h1>
      <PeopleForm onSave={savePerson} />
      <PeopleList people={people} />
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
  const { people } = props;

  return (
    <ul>
      {people.map((person, idx) => (
        <li key={idx}>{person.name}</li>
      ))}
    </ul>
  )
}