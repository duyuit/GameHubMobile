import React, { Component } from 'react';
import { Root } from 'native-base';
import { Scene, Router, Actions } from 'react-native-router-flux';

import Signup from './src/page/Signup';
import Login from './src/page/Login';
import Home from './src/page/Home'
import ListGame from './src/component/ListGame'
import GameShow from './src/page/GameShow'
export default class App extends Component {
  render() {
    return (
      <Root>
        <Router>
          <Scene key="root">
            <Scene  key="home" component={Home} hideNavBar />
            <Scene  key="GameShow" component={GameShow} hideNavBar />
            {/* <Scene key="search" component={Search} modal hideNavBar />
            <Scene key="cart" component={Cart} modal hideNavBar />
            <Scene key="wishlist" component={WishList} modal hideNavBar />
            <Scene key="map" component={Map} modal hideNavBar />
            <Scene key="contact" component={Contact} modal hideNavBar />
            <Scene key="newsletter" component={Newsletter} modal hideNavBar />
            <Scene key="category" component={Category} hideNavBar />
            <Scene key="product" component={Product} hideNavBar />
            <Scene key="imageGallery" component={ImageGallery} modal hideNavBar /> */}
            <Scene initial  key="login" component={Login} hideNavBar />
            <Scene key="signup" component={Signup} hideNavBar />
            {/* <Scene key="checkout" component={Checkout} hideNavBar /> */}
          </Scene>
        </Router>
      </Root>
    )
  }
}
