/**
* This is the category component used in the home page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import {Text,ScrollView, Image, Dimensions, TouchableOpacity,Picker } from 'react-native';
import { Left,Container, Content, View, Header, Body, Icon, Item, Input, Thumbnail, Button, Right, Grid, Col, Footer } from 'native-base';
import { Actions } from 'react-native-router-flux';
import axios from 'axios';
import { MyGlobal } from '../component/MyGlobal';

// Our custom files and classes import
import Navbar from '../component/Navbar';
import Colors from '../Colors'
import ListGame from '../component/ListGame';
export default class GameLibrary extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
     games:this.props.games,
      isOpenSearch:false,
      searchText:'',
      games: props.games,
      backup: props.games
    };
  }
 
  componentWillMount()
  {
    axios.get('http://localhost:49911/api/Accounts/'+MyGlobal.user_id)
    .then(response =>{
      this.setState({ games: response.data.payload.games});

      console.log(this.state.games);
    }).then(()=>{
      this.setState({isDone:true});
    });
  }
  render() {
    var left = (
        <Left style={{flex:1}}>
          <Button onPress={() => Actions.pop()} transparent>
            <Icon name='ios-arrow-back' />
          </Button>
        
        </Left>
      );
      var right = (
        <Right style={{flex:1}}>
          <Button onPress={() => {
            this.setState({isOpenSearch:!this.state.isOpenSearch})
          }} transparent>
            <Icon name='ios-search-outline' />
          </Button>
        </Right>
      );
    
    return(
        <View style={styles.container}>
    
          {
          this.state.isOpenSearch == true?
          <Header
          searchBar
          rounded
          style={{backgroundColor: Colors.navbarBackgroundColor}}
          backgroundColor={Colors.navbarBackgroundColor}
          androidStatusBarColor={Colors.statusBarColor}
          noShadow={true}
        >
       
            <Item>
              <Button transparent onPress={() => {this.setState({isOpenSearch:!this.state.isOpenSearch})}}>
                <Icon name="ios-close" size={32} style={{fontSize: 32}} />
              </Button>
              <Input
                placeholder="Search..."
                value={this.state.searchText}
                onChangeText={(text) => this.onSearch(text) }
                onSubmitEditing={() => this.search(this.state.searchText)}
                style={{marginTop: 9}}
              />
              <Icon name="ios-search" onPress={() => this.search(this.state.searchText)} />
            </Item>
          </Header>
          :
          <Navbar left={left} right={right} title="Library" />
          }

      
        {
        this.state.isDone? 
        <ListGame games={this.state.games} isLib='true'></ListGame>
        :
        <Text>Loading...</Text>
        }
        </View>
        
    );
  }


}
var styles=
{
 container:{
     flex:1,
     flexDirection: 'column',
     backgroundColor: Colors.navbarBackgroundColor
 },
 container2:{
     marginTop:10,
    flexDirection:'row',
    marginLeft:20
 },
 infor:{
  marginTop:10,
   marginLeft:20
}
}
