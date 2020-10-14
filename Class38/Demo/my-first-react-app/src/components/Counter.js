import React, { useState } from 'react';

export default function Counter(props) {
  const { title } = props;

  // useState hook!
  const [count, setCount] = useState(0);
  const [isEven, setIsEven] = useState(count % 2 === 0);
  const [numberToAdd, setNumberToAdd] = useState(2);

  function addToCount(n) {
    const newCount = count + n;
    setCount(newCount);
    setIsEven(newCount % 2 === 0);
  }

  function plusOne(e) {
    e.preventDefault();
    // console.log(e.target)
    addToCount(1);
  }

  function plusFromUncontrolledInput(e) {
    e.preventDefault();
    addToCount(parseInt(e.target.form.number.value));
  }

  function plusFromControlledInput(e) {
    e.preventDefault();
    addToCount(numberToAdd);
  }

  function numberToAddChange(e) {
    setNumberToAdd(parseInt(e.target.value));
  }

  return (
    <form>
      <h2>{title || 'My Counter'}</h2>
      <p>Count: {count} {isEven && 'is even'}</p>
      <button onClick={plusOne}>+1</button>
      <div>
        <h3>Uncontrolled Input</h3>
        <button onClick={plusFromUncontrolledInput}>+</button>
        <input name="number" type="number" defaultValue="2" />
      </div>
      <div>
        <h3>Controlled Input</h3>
        <button onClick={plusFromControlledInput}>+</button>
        <input type="number" value={numberToAdd} onChange={numberToAddChange} />
      </div>
    </form>
  )
}
