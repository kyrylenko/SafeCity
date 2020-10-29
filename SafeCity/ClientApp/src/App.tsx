import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Layout from './pages/Layout';
import Home from './pages/Home';
import Project from './pages/Project';
import Projects from './pages/Projects';
import Experts from './pages/Experts';
import Report from './pages/Report';
import About from './pages/About';
import NotFound from './pages/NotFound';

import 'bootstrap/dist/css/bootstrap.css';
import './main.css';
import './app.css';

function App() {
  return (
    <Layout>
      <Switch>
        <Route exact path='/' component={Home} />
        <Route exact path='/projects/:id' component={Project} />
        <Route exact path='/projects' component={Projects} />
        <Route exact path='/experts' component={Experts} />
        <Route exact path='/report' component={Report} />
        <Route exact path='/about' component={About} />
        <Route component={NotFound} />
      </Switch>
    </Layout>
  );
}

export default App;
