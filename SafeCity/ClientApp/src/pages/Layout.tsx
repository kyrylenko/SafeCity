import React from 'react';
import { NavLink } from 'react-router-dom';

function Layout(props: any) {
    return (
        <>
            <header>
                <nav className='navbar fixed-top navbar-expand-md navbar-light bg-yellow'>
                    <NavLink to='/' className='navbar-brand' >Safe city </NavLink>
                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarContent" aria-controls="navbarContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className='collapse navbar-collapse' id='navbarContent'>
                        <ul className='navbar-nav mr-auto'>
                            <li className='nav-item mx-3'>
                                <NavLink to='/projects' className='nav-link'>Projects</NavLink>
                            </li>
                            <li className='nav-item mx-3'>
                                <NavLink to='/experts' className='nav-link'>Experts</NavLink>
                            </li>
                            <li className='nav-item mx-3'>
                                <NavLink to='/report' className='nav-link'>Report</NavLink>
                            </li>
                            <li className='nav-item mx-3'>
                                <NavLink to='/about' className='nav-link'>About</NavLink>
                            </li>
                        </ul>
                    </div>
                </nav>
            </header>
            <main>
                {props.children}
            </main>
            <footer>Footer</footer>
        </>
    );
}

export default Layout;
