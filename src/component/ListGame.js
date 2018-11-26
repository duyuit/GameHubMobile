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
     isLib:this.props.isLib
    };

   
  }
  render() {
    return(
   
 
     <View>    
     <FlatList
      data={this.props.games}
      renderItem={({ item: rowData }) => {
         return (
             <GameItem game={rowData} isLib = {this.state.isLib}></GameItem>
         );
       }}
      keyExtractor={(item, index) => index}
     >
     </FlatList>   
</View>
     
      
    );
  }


}
