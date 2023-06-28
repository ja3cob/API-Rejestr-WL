import React from 'react';
import { Link } from 'react-router-dom';
import './NavMenu.css'

export function NavMenu() {
    return (
        <>
            <nav className='navbar'>
                <Link to='/' className='navbar-logo'>
                    API Rejestru przedsiębiorców
                </Link>
            </nav>
        </>
    )
}