import React from 'react';
import { observer } from 'mobx-react-lite';
import { NavLink } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import auth from '../services/auth';

const Layout = observer(({ children, authStore }: { children: any, authStore: any }) => {
    
    const handleLogin = () => {
        if (authStore.user) {
            auth.signOut()
        } else {
            auth.signIn()
        }
    };

    return (
        <>
            <header>
                <Navbar bg='yellow' expand='md' className='fixed-top'>
                    <Navbar.Brand as={NavLink} to='/'>Фонд безпечного міста</Navbar.Brand>
                    <Navbar.Toggle aria-controls='basic-navbar-nav' />
                    <Navbar.Collapse id='basic-navbar-nav'>
                        <Nav className='mr-auto'>
                            <li className='nav-item mx-3'>
                                <Nav.Link as={NavLink} to='/projects'>Проекти</Nav.Link>
                            </li>
                            <li className='nav-item mx-3'>
                                <Nav.Link as={NavLink} to='/experts'>Експерти</Nav.Link>
                            </li>
                            <li className='nav-item mx-3'>
                                <Nav.Link as={NavLink} to='/report'>Звіти</Nav.Link>
                            </li>
                            <li className='nav-item mx-3'>
                                <Nav.Link as={NavLink} to='/about'>Про нас</Nav.Link>
                            </li>
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
            </header>
            <main>
                {children}
            </main>
            <footer className='mt-auto'>
                <div className='container'>
                    <div className='row'>
                        <div className='col-md-4'>
                            пошта: <a href='mailto:kirilenko.pavlo@gmail.com'>kirilenko.pavlo@gmail.com</a>
                            <br />
                            тел: <a href='tel:+380959242349'>+3 8095 9242349</a>
                        </div>
                        <div className='col-md-8 text-right'>
                            <button onClick={handleLogin} className='btn btn-link'>{authStore.user ? 'log out' : 'log in'}</button>
                        </div>
                    </div>
                </div>
            </footer>
        </>
    );
})

export default Layout;
