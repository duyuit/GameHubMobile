/**
* This is the category component used in the home page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import {FlatList, Image, Dimensions, TouchableOpacity } from 'react-native';
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
     
     index:0,
    };

   
  }
  _onRenderItem()
  {
    let cat = [];
    for(var i=0; i<3; i++) {
     
  cat.push(
   
      <GameItem game={this.props.games[i]}></GameItem>


 );
    }
    return cat; 
  }
  renderItem(item)
  {
    <GameItem game={item}></GameItem>
  }
  render() {
    return(
   
    <View>    
            <FlatList
            horizontal
             data={this.props.games}
             renderItem={({ item: rowData }) => {
                return (
                    <GameItem game={rowData} isHori='true'></GameItem>
                );
              }}
             keyExtractor={(item, index) => index}
            >

            </FlatList>   
        
          <View >
            <TouchableOpacity style={{alignSelf:'flex-end',paddingEnd:15}}>
            <Text style={{color:'white',fontSize:20}}>See all</Text>
            </TouchableOpacity>

        </View>
      </View>
     
     
      
    );
  }


}
