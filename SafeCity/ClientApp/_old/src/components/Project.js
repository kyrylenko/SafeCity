import React, { Component } from 'react';

export class Project extends Component {
  static displayName = Project.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
  }


  render() {
    return (
      <div>
        <h1>Project</h1>
        <div>{this.props.match.params.id}</div>
      </div>
    );
  }
}
