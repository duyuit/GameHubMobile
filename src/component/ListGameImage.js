 import React, { Component } from 'react';
import {FlatList, Image, Dimensions, TouchableOpacity } from 'react-native';
import {Card,CardItem, View, Button ,List,ListItem,Thumbnail,Left,Body,Right } from 'native-base';
import { Actions } from 'react-native-router-flux';
// Our custom files and classes import
import Text from './Text';
import Colors from '../Colors';
import GameItem from './GameItem';

export default class ListGameImage extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
     
     index:0,
    };

   
  }
  render() {
    return(
   
    <View>    
            <FlatList
            horizontal
             data={this.props.images}
             renderItem={({ item: rowData }) => {
              if(rowData.index == 0)
              {
                return (
                  <Thumbnail  style={{width:300,height:200,borderRadius:10,borderWidth:2,borderColor:'white'}}
                  source={{uri: rowData.img}} />
                  );
              }else
              {
                return (
                  <Thumbnail  style={{marginLeft:30,width:300,height:200,borderRadius:10,borderWidth:2,borderColor:'white'}}
                  source={{uri: rowData.img}} />
                  );
              }
                
              }}
             keyExtractor={(item, index) => index}
            >

            </FlatList>   
      </View>
     
     
      
    );
  }


}
