import React, { useState } from 'react';

export default function Counter(props) {
  const { title } = props;

  // useState hook!
  const [count, setCount] = useState(0);
  const [isEven, setIsEven] = useState(count % 2 == 0);

  function plusOne(e) {
    // console.log(e.target)
    setCount(count + 1);
    setIsEven(!isEven)
  }

  return (
    <>
      <h2>{title || 'My Counter'}</h2>
      <p>Count: {count} {isEven && 'is even'}</p>
      <button onClick={plusOne}>+1</button>
    </>
  )
}
