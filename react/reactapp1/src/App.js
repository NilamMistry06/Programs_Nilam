import { useState } from "react";
import Tesseract from 'tesseract.js';

const Hi = (props) => {
 const {num} = props;
  return (
    <div>Hello {props.num} {num}</div>
  )
}

function App() {

  const [number, setNumber] = useState(0);
  const [textarea, setTextarea] = useState(
    "The content of a textarea goes in the value attribute"
  );

  const add = () =>{
    setNumber(number + 1)
  }

  const handleChange = (event) => {
    setTextarea(event.target.value)
  } 

  //Read image text start
  const [text, setText] = useState('');

  function handleFileChange(event) {
    const imageFile = event.target.files[0];
    readImage(imageFile);
  }

  function readImage(imageFile) {
    Tesseract.recognize(imageFile)
      .then(result => {
        setText(result.data.text);
      })
      .catch(err => {
        console.error(err);
      });
  }
    //Read image text end

  return (
    <div className="App">
      <div>Hi..</div>
      <Hi  num={number} />
      <div>Number={number}</div>
      <button onClick={add}>Add</button>

      <input type="text" />
      <textarea value={textarea} onChange={handleChange} />

      {/* Read image text */}
      <div>
        <input type="file" onChange={handleFileChange} />
        <span>{text}</span>
      </div>
    </div>
  );
}

export default App;
