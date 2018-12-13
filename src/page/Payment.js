import React, { Component } from 'react';

import { TouchableHighlight, AsyncStorage } from 'react-native';

import { Container, Content, View, Grid, Col, Left, Right, Button, Icon, List, ListItem, Body, Radio, Input, Item } from 'native-base';

import FAIcon  from 'react-native-vector-icons/FontAwesome';

import { Actions } from 'react-native-router-flux';
import axios from 'axios';
import { MyGlobal } from '../component/MyGlobal';


// Our custom files and classes import

import Colors from '../Colors';

import Text from '../component/Text';

import Navbar from '../component/Navbar';



export default class Checkout extends Component {

  constructor(props) {

      super(props);

      this.state = {
        game:this.props.game,
        hasError:false,
        errorText:'',
        balance:0,
        isDone:false
      };

  }



  componentWillMount() {
    axios.get('http://localhost:49911/api/Accounts/'+MyGlobal.user_id)
    .then(response =>{
        this.setState({balance:response.data.payload.money})
        this.setState({isDone:true});
    })
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

      </Right>

    );

    return(

      <Container style={{backgroundColor: '#fdfdfd'}}>

        <Navbar left={left} right={right} title="CHECKOUT" />

      {
        this.state.isDone?
     
        <Content padder>
      
         <View style={{flexDirection:'row'}}>
           <View style={{flex:1}}>
             <Text style={{fontSize:23,fontWeight:'bold'}}>{this.state.game.name}</Text>
             <Text tyle={{marginTop:10,fontSize:18}}>{this.state.game.publisher.name}</Text>
             <Text tyle={{marginTop:10,fontSize:18}}>Adventure, Puzzle</Text>
           </View>
           <Text style={{fontSize:23}}>{this.state.game.price/1000}$</Text>
           </View>
           <View style={{marginTop:10,width:'90%',height:1,backgroundColor:'black',alignSelf:'center'}}></View>
          <View>
            <Text style={{marginTop: 15, marginBottom: 7, fontSize: 18}}>Payement method</Text>

            <ListItem style={{borderWidth: 1, borderColor: 'rgba(149, 165, 166, 0.3)', paddingLeft: 10, marginLeft: 0}}>

              <Text>Pay with card</Text>

              <FAIcon name="cc-mastercard" size={20} color="#c0392b" style={{marginLeft: 7}} />

              <FAIcon name="cc-visa" size={20} color="#2980b9" style={{marginLeft: 2}} />

              <Right>

                <Radio selected={this.state.card} onPress={() => this.setState({card: true, paypal: false})} />

              </Right>

            </ListItem>

            <ListItem style={{borderWidth: 1, borderColor: 'rgba(149, 165, 166, 0.3)', paddingLeft: 10, marginLeft: 0, borderTopWidth: 0}}>

              <Text>Pay with Paypal</Text>

              <FAIcon name="cc-paypal" size={20} color="#34495e" style={{marginLeft: 7}} />

              <Right>

                <Radio selected={this.state.paypal} onPress={() => this.setState({card: false, paypal: true})} />

              </Right>

            </ListItem>

          </View>
          {this.state.hasError?<Text style={{color: "#c0392b", textAlign: 'center', marginTop: 10}}>{this.state.errorText}</Text>:null}
          <Text>Balance: {this.state.balance}</Text>
          <View style={{marginTop: 10, marginBottom: 10, paddingBottom: 7}}>

            <Button onPress={() => this.checkout()} style={{backgroundColor: Colors.navbarBackgroundColor}} block iconLeft>

              <Text style={{color: '#fdfdfd'}}>Purchase</Text>

            </Button>

          </View>

        </Content>
        :
        <Text>Loading....</Text>
   }
      </Container>

    );

  }

 
  checkout() {

    this.setState({hasError:true,errorText:'Loading'})
    axios.post('http://localhost:49911/api/Accounts/buy/'+MyGlobal.user_id, { 
      id:this.state.game.id,
    })
    .then(res => {
      if(res.data.isSuccess)
      {
        this.setState({hasError:false,errorText:''})
        alert("Purchase success")
        setTimeout(() => {
          Actions.pop();
        }, 2000);
      }else
      {
        console.log('user_id: '+ MyGlobal.user_id);
        console.log('game_id: '+ this.state.game.id);

        this.setState({hasError:true,errorText:res.data.message})
      }
    
    });

 

  }



}



const styles = {

  invoice: {

    paddingLeft: 20,

    paddingRight: 20

  },

  line: {

    width: '100%',

    height: 1,

    backgroundColor: '#bdc3c7'

  }

};