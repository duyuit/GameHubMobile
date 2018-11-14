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
     games_backup:this.props.games,
     paidSelect : 'Top Paid',
     sortSelect:'Rating'
    };
  }
  onPaidSelected(itemValue,itemIndex)
  {
      this.setState({paidSelect:itemValue});
      var games_temp = this.state.games_backup;
      switch(itemIndex)
      {
          case 0:
           games_temp = games_temp.filter(item => item.price !== 0)
          break;
          case 1:
              games_temp = games_temp.filter(item => item.price === 0)
          break;
          case 2:
            this.state.games.sort();
          break;
          
      }
      this.setState({games:games_temp});
  }
  sortByRating()
  {

  }
  sortByPriceDown()
  {
    function compare(a,b) {
      if (a.price < b.price)
        return 1;
      if (a.price > b.price)
        return -1;
      return 0;
    }
    var game_temp = this.state.games;
    game_temp.sort(compare);
    game_temp.push(game_temp[0]);
    this.setState({games:game_temp});
  }
  sortByPriceUp()
  {
    function compare(a,b) {
      if (a.price < b.price)
        return -1;
      if (a.price > b.price)
        return 1;
      return 0;
    }
    var game_temp = this.state.games;
    game_temp.sort(compare);
    game_temp.push(game_temp[0]);
    this.setState({games:game_temp});
    
  }
  componentWillMount()
  {
    // this.sortByPriceUp();
    this.onPaidSelected(0,0);
  }
  onSortSelected(itemValue,itemIndex)
  {
    this.setState({sortSelect:itemValue});
    switch(itemIndex)
    {
      case 0:
       break;
      case 1:
        this.sortByPriceUp();
        break;
      case 2:
        this.sortByPriceDown();
        break;
    }

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
       
        <ListGame games={this.state.games}></ListGame>
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
