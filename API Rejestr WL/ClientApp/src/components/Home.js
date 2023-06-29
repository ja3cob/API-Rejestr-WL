import { useState, useRef } from 'react';
import './Home.css';

export function Home() {
    const [loader, setLoader] = useState(false);
    const [table, setTable] = useState(false);
    const [data, setData] = useState(null);
    const [cross, setCross] = useState(false);
    const inputRef = useRef(null);

    async function Search() {
        setCross(false);
        setLoader(true);

        try {
            const result = await fetch(`api/nip/${inputRef.current.value}`);
            if(result.ok) {
                const fetched = await result.json();
                setData(fetched);
                setTable(true);
            }
            else {
                setData(null);
                setCross(true);
                setTable(false);
            }
        } catch(exception) {
            setData(null);
            setTable(false);
            console.log(`Error fetching data: ${exception}`);
        } finally {
            setLoader(false);
        }
    }

    return (
        <div className="home-container">
            <div className={table ? 'search-container moved' : 'search-container'}>
                <p>Wyszukaj przedsiębiorcę</p>
                <div className='search-controls'>
                    <input ref={inputRef} className='search-input' type='text' placeholder='Wprowadź NIP...' />
                    <button onClick={Search}><i className='fa fa-search' /></button>
                    <div className={loader ? 'loader' : 'loader hidden'} />
                    <div className={cross ? 'cross' : 'cross hidden'}><i className='fa-solid fa-xmark' /></div>
                </div>
            </div>
            <div className='table-container'>
                {data ? (
                        <span>{JSON.stringify(data, null, 2)}</span>
                ) : (
                    <p>No data to display.</p>
                )}
            </div>
        </div>
    );
}