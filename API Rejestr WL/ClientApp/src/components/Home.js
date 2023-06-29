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
            <div className={table ? 'table-container' : 'table-container hidden'}>
                {data &&
                    <table>
                        <thead>
                            <tr>
                                <th colSpan={2}>
                                    {data.name}
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Regon</td>
                                <td>{data.regon}</td>
                            </tr>
                            <tr>
                                <td>KRS</td>
                                <td>{data.krs}</td>
                            </tr>
                            <tr>
                                <td>NIP</td>
                                <td>{data.nip}</td>
                            </tr>
                            <tr>
                                <td>PESEL</td>
                                <td>{data.pesel}</td>
                            </tr>
                            <tr>
                                <td>Data wznowienia działalności</td>
                                <td>{data.restorationDate}</td>
                            </tr>
                            <tr>
                                <td>Podstawa wznowienia działalności</td>
                                <td>{data.restorationBasis}</td>
                            </tr>
                            <tr>
                                <td>Data wykreślenia</td>
                                <td>{data.removalDate}</td>
                            </tr>
                            <tr>
                                <td>Podstawa wykreślenia</td>
                                <td>{data.removalBasis}</td>
                            </tr>
                            <tr>
                                <td>Data odmowy rejestracji</td>
                                <td>{data.registrationDenialDate}</td>
                            </tr>
                            <tr>
                                <td>Podstawa odmowy rejestracji</td>
                                <td>{data.registrationDenialBasis}</td>
                            </tr>
                            <tr>
                                <td>Prawna data rejestracji</td>
                                <td>{data.registrationLegalDate}</td>
                            </tr>
                            <tr>
                                <td>Adres roboczy</td>
                                <td>{data.workingAddress}</td>
                            </tr>
                            <tr>
                                <td>Adres siedziby</td>
                                <td>{data.residenceAddress}</td>
                            </tr>
                            <tr>
                                <td>Autoryzowani urzędnicy</td>
                                <td><ul>{data.authorizedClerks.map((item, index) => (<li key={index}>{item}</li>))}</ul></td>
                            </tr>
                            <tr>
                                <td>Czy posiada wirtualne konta</td>
                                <td>{data.hasVirtualAccounts ? 'Tak' : 'Nie'}</td>
                            </tr>
                            <tr>
                                <td>Status VAT</td>
                                <td>{data.statusVat}</td>
                            </tr>
                            <tr>
                                <td>Numery kont</td>
                                <td>{data.accountNumbers.map((item, index) => (<li key={index}>{item}</li>))}</td>
                            </tr>
                            <tr>
                                <td>Partnerzy</td>
                                <td>{data.partners.map((item, index) => (<li key={index}>{item.firstName} {item.lastName}</li>))}</td>
                            </tr>
                            <tr>
                                <td>Reprezentanci</td>
                                <td>{data.representatives.map((item, index) => (<li key={index}>{item.firstName} {item.lastName}</li>))}</td>
                            </tr>
                        </tbody>
                    </table>
                }
            </div>
        </div>
    );
}