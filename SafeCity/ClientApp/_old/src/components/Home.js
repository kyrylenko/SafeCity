import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Safe city </h1>
        <p>Landing page and the list of projects is here</p>
        <div>
          <ul>
            <li><a href="project/1">Project 1</a></li>
            <li><a href="project/1">Project 1</a></li>
            <li><a href="project/1">Project 1</a></li>
            <li><a href="project/1">Project 1</a></li>
            <li><a href="project/1">Project 1</a></li>
            <li><a href="project/1">Project 1</a></li>
          </ul>
        </div>
      </div>
    );
  }
}
