/**
* This is the category component used in the home page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import { Image, Dimensions, TouchableOpacity } from 'react-native';
import {ScrollView,Card,CardItem, View, Button ,List,ListItem,Thumbnail,Left,Body,Right } from 'native-base';
import { Actions } from 'react-native-router-flux';
// Our custom files and classes import
import Text from './Text';
import Colors from '../Colors';
export default class GameItem extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
     game:props.game,
    };
  }
  
  render() {
    return(
   
    
      <TouchableOpacity
      style={{flexDirection:'row',marginTop:20}}
      onPress = {()=>
      {
          Actions.GameShow({game:this.state.game});
      }}
    >

  
  
      <View style={{flexDirection:'row'}}>
      <Thumbnail  style={{width:80,height:80,borderRadius:10}} source={{uri: this.props.game.imageGames[0].urlOnline}} />
      <View style={{width:'55%',marginStart:10,marginTop:10,flexDirection:'column'}}>
      <Text style={{color:'rgba(255,255,255,0.9)',fontSize:18}}>{this.props.game.name}</Text>
      <Text style={{marginTop:10,color:'rgba(255,255,255,0.6)',fontSize:13}}>{this.props.game.name}</Text>
      </View>
    
      </View>
      <Body/>
  
        <View>
      <TouchableOpacity  style={{borderWidth:1,borderColor:'white',marginTop:8,width:80,height:40,borderRadius:30,backgroundColor:Colors.navbarBackgroundColor}}>
      
    {
      this.props.game.price === 0 ?  
      <Text style={{paddingTop:10,textAlign:'center',width:'100%',color:'white',fontSize:15,fontWeight:'bold'}}>
      FREE</Text>
      :
      <Text style={{paddingTop:10,textAlign:'center',width:'100%',color:'white',fontSize:15,fontWeight:'bold'}}>
      {this.props.game.price/1000}K</Text>
    }
     
      </TouchableOpacity>
      
      </View> 
    </TouchableOpacity>
    );
  }


}
var styles=
{
  row:{
    flexDirection:'row',
    marginStart:5
  }

}
