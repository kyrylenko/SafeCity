import React from 'react';
import { Link } from 'react-router-dom';

const NotFound = (props: any) => {
    return <div style={{ textAlign: "center" }}>
        <h2 >404: Page not found</h2>
        <h5>You either tried some shady route or you came here by mistake.</h5>
        <Link to='/' title='Go to the home page'>Home</Link>
    </div>
}

export default NotFound;