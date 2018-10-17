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
     
     index:0,
    };
  }
  render() {
    return(
        <View style={styles.container}>
        <View style={styles.container2}>
        <Thumbnail  style={{width:120,height:120,borderRadius:20}} source={{uri:'http://static.game24h.vn/upload/2016/2016-4/game/2016-12-03/game-chu-be-lua-va-co-gai-nuoc1.png'}} />
        <View style={{height:120,flexDirection:'column',marginLeft:20,justifyContent:'space-between'}}>
            <Text style={{fontWeight:'bold',fontSize:23,color:'rgba(255,255,255,0.9)'}}>Super Cat Tales 2</Text>
            <Text style={{fontSize:15,color:'rgba(255,255,255,0.6)'}}>Gionathan</Text>
            <TouchableOpacity  style={{borderWidth:2,borderColor:'rgb(0,191,255)',marginTop:30,width:100,height:30,borderRadius:30,backgroundColor:'rgb(0,191,255)'}}>
                <Text style={{paddingTop:2,textAlign:'center',width:'100%',color:'white',fontSize:15,fontWeight:'bold'}}>
                100K</Text>
            </TouchableOpacity>
        </View>
     
        </View>
           
           <View style={styles.container2}>

           </View>
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
    flexDirection:'row',
    marginLeft:20
 }

}
