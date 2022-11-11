import './App.css';
import { Component } from 'react';

class App extends Component{
  constructor(){
    super();
    this.state = {
      translatedText: []
    }
  }

  render(){
    const texts  = this.state.translatedText.map((item , index) => <li key={index}>{item.text}</li>)

    return (
      <div className='App'>
        <button onClick={this.getTranslatedText}>Отримати переклад речення</button>
        <ul>{texts}</ul>
      </div>
    )
  }

  getTranslatedText = async () => {
      var responce = await fetch(
        'api/Translate',
        {
          method: 'get'
        }
      )
      var responceJson = await responce.json();
      
      this.setState({
        translatedText: responceJson[0]["translations"]
      })
  }
}

export default App;
