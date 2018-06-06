import React from 'react';
import {Link} from 'react-router';

class HomePage extends React.Component {
    render() {
        return(
            <div className="jumbotron">
                <h1>Sheets</h1>
                <p>A web application for remembering your WH40k forces.</p>
                <Link to="about" className="btn btn-primary btn-lg">Tell me more</Link>
            </div>
        );
    }
}

export default HomePage;