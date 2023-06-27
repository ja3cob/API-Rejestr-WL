import './Home.css';

function Search() {
  console.log("search");
}

export function Home() {
    return (
        <div className="home-container">
            <div className='search-container'>
                <p>Wyszukaj przedsiębiorcę</p>
                <div className='search-controls'>
                    <input className='search-input' type='text' placeholder='Wprowadź NIP...' />
                    <button onClick={Search}><i class='fa fa-search' /></button>
                </div>
            </div>
        </div>
    );
}