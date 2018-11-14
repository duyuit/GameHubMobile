/**
* This is the Search file
**/

// React native and others libraries imports
import React, { Component } from 'react';
import { Container, Content, View, Header, Body, Icon, Item, Input, Thumbnail, Button, Right, Grid, Col, Footer } from 'native-base';
import { Actions } from 'react-native-router-flux';

// Our custom files and classes import
import Colors from '../Colors';
import Text from '../component/Text';
import GameListShow from './GameListShow';
import ListGame from '../component/ListGame';
export default class Search extends Component {
  constructor(props) {
      super(props);
      this.state = {
        searchText: '',
        games: props.games,
        backup: props.games
      };
  }

  componentWillMount() {
    if(this.props.searchText) {
      this.setState({searchText: this.props.searchText});
      this.search(this.props.searchText);
    }
  }
  onSearch(text)
  {
    this.setState({searchText: text});
     if(text == "")
    {
      this.setState({games:this.state.backup});
      return;
    }
  //  this.search(this.state.searchText);
  }
  render() {
    return(
      <Container style={{backgroundColor: Colors.navbarBackgroundColor}}>
        <Header
          searchBar
          rounded
          style={{backgroundColor: Colors.navbarBackgroundColor}}
          backgroundColor={Colors.navbarBackgroundColor}
          androidStatusBarColor={Colors.statusBarColor}
          noShadow={true}
        >
       
            <Item>
              <Button transparent onPress={() => Actions.pop()}>
                <Icon name="ios-close" size={32} style={{fontSize: 32}} />
              </Button>
              <Input
                placeholder="Search..."
                value={this.state.searchText}
                onChangeText={(text) => this.onSearch(text) }
                onSubmitEditing={() => this.search(this.state.searchText)}
                style={{marginTop: 9}}
              />
              <Icon name="ios-search" onPress={() => this.search(this.state.searchText)} />
            </Item>
          </Header>
         
                 <ListGame  games={this.state.games}></ListGame>
        
           
          
      </Container>
    );
  }


  search(text) {

    var newGame=[];
   
    for(var i=0;i<this.state.backup.length;i++)
    {
      var string = this.state.backup[i].name;
      if(string.includes(text))
        newGame.push(this.state.backup[i]);
    }
  
    this.setState({games: newGame});
  }

}
