/**
* This is the category component used in the home page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import {ScrollView, Image, Dimensions, TouchableOpacity } from 'react-native';
import {Card,CardItem, View,Icon, Button ,List,ListItem,Thumbnail,Left,Body,Right } from 'native-base';
import { Actions } from 'react-native-router-flux';
import { Rating } from 'react-native-elements';
// Our custom files and classes import
import Text from '../component/Text';
import Navbar from '../component/Navbar';
import Colors from '../Colors'
import ListGameImage from '../component/ListGameImage';
export default class GameItem extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
     images:props.game.imageGames,
     index:0,
     game:props.game
    };
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
          <Button onPress={() => Actions.search()} transparent>
            <Icon name='ios-search-outline' />
          </Button>
          <Button onPress={() => Actions.cart()} transparent>
            <Icon name='ios-cart' />
          </Button>
        </Right>
      );
    return(
        <View style={styles.container}>
        <Navbar left={left} right={right} title="MY STORE" />
        <ScrollView>
        <View style={styles.container2}>
            <Thumbnail  style={{width:120,height:120,borderRadius:20}}
            source={{uri:this.state.images[0].urlOnline}} />
            <View style={{ flex:1,height:120,flexDirection:'column',marginLeft:20,justifyContent:'space-between'}}>
                <Text style={{fontWeight:'bold',fontSize:21,color:'rgba(255,255,255,0.9)'}}>{this.state.game.name}</Text>
                <Text style={{fontSize:15,color:'rgba(255,255,255,0.6)'}}>{this.state.game.publisher.name}</Text>
                <TouchableOpacity  style={{borderWidth:2,borderColor:'rgb(0,191,255)',marginTop:30,width:100,height:30,borderRadius:30,backgroundColor:'rgb(0,191,255)'}}>
                    <Text style={{paddingTop:2,textAlign:'center',width:'100%',color:'white',fontSize:15,fontWeight:'bold'}}>
                    100K</Text>
                </TouchableOpacity>
            </View>
        </View>
           
        <View style={styles.container2}>
        <Rating
        type="custom"
        ratingColor='black'
        ratingBackgroundColor='black'

        startingValue={5.0}
        readonly
        imageSize={30}
        style={{ paddingVertical: 10}}  />
         <Body/>
        </View>
        <ListGameImage images={this.state.images}></ListGameImage>
        <View style={{marginTop:10,width:380,height:1,backgroundColor:'white',alignSelf:'center'}}></View>
        <Text style={{color:'white',fontSize:18,marginTop:8,marginLeft:20}}>{this.state.game.content}</Text>
        <View style={{marginTop:10,width:380,height:1,backgroundColor:'white',alignSelf:'center'}}></View>
        <View style={styles.infor}>
        <Text style={{color:'white',fontSize:20,marginTop:10}}>Information: </Text>

        <Text style={{color:'white',fontSize:15,marginTop:10}}>Publisher: {this.state.game.publisher.name}</Text>
        <View style={{marginTop:10,width:300,height:0.5,backgroundColor:'white',alignSelf:'flex-start'}}></View>

        <Text style={{color:'white',fontSize:15,marginTop:10}}>Tag: FPS, Open world</Text>
        <View style={{marginTop:10,width:300,height:0.5,backgroundColor:'white',alignSelf:'flex-start'}}></View>

        <Text style={{color:'white',fontSize:15,marginTop:10}}>Age: 18+</Text>

        </View>
        </ScrollView>
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
    marginLeft:20,
    flex:1
 },
 infor:{
  marginTop:10,
   marginLeft:20
}
}
