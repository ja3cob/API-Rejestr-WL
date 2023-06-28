import { useState, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import './Home.css';

export function Home() {
  const [loader, setLoader] = useState(false);
  const [table, setTable] = useState(false);
  const inputRef = useRef(null);
  const navigate = useNavigate();

  async function Search() {
    setLoader(true);
    setTable(true);

    const result = await fetch(`api/nip/${inputRef.current.value}`);
    console.log(result.ok);
  }
  
    return (
        <div className="home-container">
            <div className={table ? 'search-container moved' : 'search-container'}>
                <p>Wyszukaj przedsiębiorcę</p>
                <div className='search-controls'>
                    <input ref={inputRef} className='search-input' type='text' placeholder='Wprowadź NIP...' />
                    <button onClick={Search}><i className='fa fa-search' /></button>
                    <div className={loader ? 'loader' : 'loader hidden'} />
                </div>
            </div>
            <div className='table-container'>
                
            </div>
        </div>
    );
}