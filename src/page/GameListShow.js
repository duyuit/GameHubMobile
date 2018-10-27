/**
* This is the category component used in the home page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import {ScrollView, Image, Dimensions, TouchableOpacity,Picker } from 'react-native';
import {Card,CardItem, View,Icon, Button ,List,ListItem,Thumbnail,Left,Body,Right } from 'native-base';
import { Actions } from 'react-native-router-flux';
// Our custom files and classes import
import Navbar from '../component/Navbar';
import Colors from '../Colors'
import ListGame from '../component/ListGame';
export default class GameListShow extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
     games:this.props.games,
     paidSelect : 'Top Paid',
     sortSelect:'Rating'
    };
  }
  onPaidSelected(itemValue,itemIndex)
  {
      this.setState({paidSelect:itemValue});
      switch(itemValue)
      {
          case 'paid':
            this.state.games.sort();
          break;
          
      }
  }
  onSortSelected(itemValue,itemIndex)
  {
    this.setState({sortSelect:itemValue});

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
        <Navbar left={left} right={right} title="GAMES" />
        <View style={{flexDirection:'row'}}>
        <Picker  
        onValueChange={(itemValue, itemIndex) =>this.onPaidSelected(itemValue,itemIndex)}
        style={{color:'white',width:200}}
        selectedValue={this.state.paidSelect}
        >
               <Picker.Item label = "Top Paid" value = "paid" />
               <Picker.Item label = "Top Free" value = "free" />
               <Picker.Item label = "Hots" value = "hot" />
        </Picker>

        <Picker  
        onValueChange={(itemValue, itemIndex) =>this.onSortSelected(itemValue,itemIndex)}
        style={{color:'white',width:200}}
        selectedValue={this.state.sortSelect}>
               <Picker.Item label = "Rating" value = "rating" />
               <Picker.Item label = "Low > Hight" value = "low" />
               <Picker.Item label = "Hight > Low" value = "hight" />
        </Picker>

        </View>
       
        <ListGame specialList='true' games={this.props.games}></ListGame>
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
