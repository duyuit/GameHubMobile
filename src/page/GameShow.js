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
     
     index:0,
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
            source={{uri:'http://files.vforum.vn/2016/T06/img/vforum.vn-333764-res-33ce7d5f5baeb85748f744ec9c5ac79b.jpg'}} />
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
        <Rating

        type="custom"
        ratingColor='black'
        ratingBackgroundColor='black'

        startingValue={5.0}
        readonly
        imageSize={30}
        style={{ paddingVertical: 10}}  />
         <Body/>
        <Text style={{fontSize:20,marginTop:10,color:'white'}}>18+</Text>
        </View>
        <ListGameImage images={images}></ListGameImage>
        <View style={{marginTop:10,width:380,height:1,backgroundColor:'white',alignSelf:'center'}}></View>
        <Text style={{color:'white',fontSize:18,marginTop:8,marginLeft:20}}>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a g</Text>
        <View style={{marginTop:10,width:380,height:1,backgroundColor:'white',alignSelf:'center'}}></View>
        <View style={styles.infor}>
        <Text style={{color:'white',fontSize:20,marginTop:10}}>Information: </Text>

        <Text style={{color:'white',fontSize:15,marginTop:10}}>Publisher: Duykk</Text>
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
    marginLeft:20
 },
 infor:{
  marginTop:10,
   marginLeft:20
}
}
var images=[
  {
    index:0,
    img:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQTZhylJ7Ezh_KtghK_QYP8s8DJHG68ly8POwr1kw09uw0ffN-G'
  },
  {
    index:1,
    img:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3hGD1kO0R_Wu8xibPteXtQrjXbGukb7qDr6wbMKVT4WGfryJO'
  },
  {
    index:2,
    img:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQyCVZBf8F0dyRIkW9NLtDmbcfQHQ-R87NYhziqrsjgLyUGPh95'
  },
  {
    index:3,
    img:'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRo1tqI8qJhKxhbVyhKqFa5CnlSOGjY9N57XdYpw1bw5Xmmac3V'
  }
]
