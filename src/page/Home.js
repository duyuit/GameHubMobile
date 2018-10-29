/**
* This is the Home page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import { Image } from 'react-native';
import { Container, Content, View, Button, Left, Right, Icon, Card, CardItem, cardBody, Thumbnail } from 'native-base';
import { Actions } from 'react-native-router-flux';


// Our custom files and classes import
import Text from '../component/Text';
import Navbar from '../component/Navbar';
import SideMenu from '../component/SideMenu';
import SideMenuDrawer from '../component/SideMenuDrawer';
import CategoryBlock from '../component/CategoryBlock';
import Colors from '../Colors'

export default class Home extends Component {

  render() {
    var left = (
      <Left style={{flex:1}}>
        <Button onPress={() => this._sideMenuDrawer.open()} transparent>
          <Icon name='ios-menu-outline' />
        </Button>
      </Left>
    );
    var right = (
      <Right style={{flex:1}}>
        <Button onPress={() => Actions.search({games:games})} transparent>
          <Icon name='ios-search-outline' />
        </Button>
        <Button onPress={() => Actions.gameLibrary({games:games})} transparent>
          <Thumbnail   source={require('../image/download.png')} small style={{width:20,height:20,borderRadius:0}}></Thumbnail>
        </Button>
      </Right>
    );
    return(
      
      <SideMenuDrawer ref={(ref) => this._sideMenuDrawer = ref} >
          <Container >
            <Navbar left={left} right={right} title="HOME" />
            <Content>
              {this.renderCategories()}
            </Content>
          </Container>
      </SideMenuDrawer>
    );
  }

  renderCategories() {
    games.find
    let cat = [];
    for(var i=0; i<categories.length; i++) {
      if(i==0)
      {
        cat.push(
        <CategoryBlock games={games} _margin = {10} key={categories[i].id} id={categories[i].id} image={categories[i].image} title={categories[i].title} />
      );
      }else
      {
        if(i%2 == 0)
        cat.push(
          <CategoryBlock games={games} isHoriental='false' _margin = {30} key={categories[i].id} id={categories[i].id} image={categories[i].image} title={categories[i].title} />
        );
        else 
        cat.push(
          <CategoryBlock games={games} isHoriental = 'true' _margin = {30} key={categories[i].id} id={categories[i].id} image={categories[i].image} title={categories[i].title} />
        );
      }
      
    }
    return cat;
  }

}
var games=[
  {
    key:1,
    name:'GTA V',
    cost:100,
    tag:'FPS,Open world',
    img:'https://img.gta5-mods.com/q95/images/gta-online-missions-for-sp/ff6dbe-gtaonline_art_2880x1800.jpg',
  }
  ,
  {
    key:2,
    name:'CSGO',
    cost:100,
    tag:'FPS,Esport',
    img:'https://phongvu.vn/cong-nghe/wp-content/uploads/2018/09/csgo-free.jpg'
   
  }
  , 
  {
    key:3,
    name:'PUBG',
    cost:100,
    tag:'Survive, Battleground',
    img:'https://cdn.images.express.co.uk/img/dynamic/143/590x/PUBG-886916.jpg'

  }, 
  {
    key:3,
    name:'PUBG',
    cost:100,
    tag:'Survive, Battleground',
    img:'https://cdn.images.express.co.uk/img/dynamic/143/590x/PUBG-886916.jpg'

  },
  {
    key:2,
    name:'CSGO',
    cost:100,
    tag:'FPS,Esport',
    img:'https://phongvu.vn/cong-nghe/wp-content/uploads/2018/09/csgo-free.jpg'
   
  }];
var categories = [
  {
    id: 1,
    title: 'SALE OFF',
    image: 'http://res.cloudinary.com/atf19/image/upload/c_scale,w_489/v1500284127/pexels-photo-497848_yenhuf.jpg'
  },
  {
    id: 2,
    title: 'NEWS!!!',
    image: 'http://res.cloudinary.com/atf19/image/upload/c_scale,w_460/v1500284237/pexels-photo-324030_wakzz4.jpg'
  },
  {
    id: 3,
    title: 'HOT TREND',
    image: 'http://res.cloudinary.com/atf19/image/upload/c_scale,w_445/v1500284286/child-childrens-baby-children-s_shcevh.jpg'
  }
];