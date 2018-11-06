/**
* This is the category component used in the home page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import { FlatList,Image, Dimensions, TouchableOpacity } from 'react-native';
import {Card,CardItem, View, Button ,List,ListItem,Thumbnail,Left,Body,Right } from 'native-base';
import { Actions } from 'react-native-router-flux';
// Our custom files and classes import
import Text from './Text';
import Colors from '../Colors';
import GameItem from './GameItem';

export default class ListGame extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
     games:[],
     index:0,
    };

   
  }
  componentWillMount()
  {
    
    var countItem = 3;
    if(this.props.specialList == 'true')
     countItem = this.props.games.length;

     var games_temp=[];
    for(var i=0; i<countItem; i++) {
      games_temp.push(this.props.games[i]);
    }
    this.setState({games:games_temp});
  }
  render() {
    return(
   
 
     <View>    
     <FlatList
      data={this.state.games}
      renderItem={({ item: rowData }) => {
         return (
             <GameItem game={rowData} isHori='false'></GameItem>
         );
       }}
      keyExtractor={(item, index) => index}
     >
     </FlatList>   
</View>
     
      
    );
  }


}
