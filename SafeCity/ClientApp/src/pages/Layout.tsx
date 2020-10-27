import React from 'react';
import { NavLink } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';

function Layout(props: any) {
    return (
        <>
            <header>
                <Navbar bg='yellow' expand='md' className='fixed-top'>
                    <Navbar.Brand as={NavLink} to='/'>Safe test fund</Navbar.Brand>
                    <Navbar.Toggle aria-controls='basic-navbar-nav' />
                    <Navbar.Collapse id='basic-navbar-nav'>
                        <Nav className='mr-auto'>
                            <li className='nav-item mx-3'>
                                <Nav.Link as={NavLink} to='/projects'>Projects</Nav.Link>
                            </li>
                            <li className='nav-item mx-3'>
                                <Nav.Link as={NavLink} to='/experts'>Experts</Nav.Link>
                            </li>
                            <li className='nav-item mx-3'>
                                <Nav.Link as={NavLink} to='/report'>Report</Nav.Link>
                            </li>
                            <li className='nav-item mx-3'>
                                <Nav.Link as={NavLink} to='/about'>About</Nav.Link>
                            </li>
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
            </header>
            <main>
                {props.children}
            </main>
            <footer>Footer</footer>
        </>
    );
}

export default Layout;
