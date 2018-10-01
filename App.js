import React, { Component } from 'react';
import { Router, Scene } from 'react-native-router-flux';

import Signup from './src/page/Signup';
import Login from './src/page/Login';

export default class App extends Component {
  render() {
    return (
      <Router hideNavBar='true'>
        <Scene key="root">
          <Scene key="pageOne" component={Login}  hideNavBar={true} initial={true} />
          <Scene key="pageTwo" component={Signup}  hideNavBar={true}  />
        </Scene>
      </Router>
    )
  }
}
