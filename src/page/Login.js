/**
* This is the Login Page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import {Thumbnail, Container, View, Left, Right, Button, Icon, Item, Input } from 'native-base';
import { Actions } from 'react-native-router-flux';
import {TouchableOpacity} from 'react-native'
import axios from 'axios';

// Our custom files and classes import
import Colors from '../Colors';
import Text from '../component/Text';
import Navbar from '../component/Navbar';
import Signup from './Signup'
import { MyGlobal } from '../component/MyGlobal';

export default class Login extends Component {
  constructor(props) {
      super(props);
      this.state = {
        username: '',
        password: '',
        hasError: false,
        errorText: '',
        enableButton:false
      };
  }

 
  render() {
    return(
      <Container style={{backgroundColor: '#fdfdfd'}}>
        <Navbar title="LOGIN" />
        <View style={{flex: 1, justifyContent: 'center', alignItems: 'center', paddingLeft: 50, paddingRight: 50}}>
        <View  style={{marginBottom:70}}>
        <Thumbnail  source={require('../image/logo.png')}  large style={{width:400,height:150}}></Thumbnail>
        </View>
        
          <View style={{marginBottom: 35, width: '100%'}}>
            <Text style={{fontSize: 24, fontWeight: 'bold', textAlign: 'left', width: '100%', color: Colors.navbarBackgroundColor}}>Welcome, </Text>
            <View style={{flexDirection:'row'}}>
              <Text style={{fontSize: 18, textAlign: 'left', color: '#687373'}}>Login to continue or</Text>
            <TouchableOpacity  onPress= {() => {Actions.signup(); }}>
            <Text rounded style={{fontSize: 18, textAlign: 'right', color: '#4286f4'}}> Sign up </Text>
            </TouchableOpacity>
             
            </View>
          </View>
          <Item>
              <Icon active name='ios-person' style={{color: "#687373"}}  />
              <Input placeholder='Email or Username' onChangeText={(text) => this.setState({username: text})} placeholderTextColor="#687373">{this.props.username}</Input>
          </Item>
          <Item>
              <Icon active name='ios-lock' style={{color: "#687373"}} />
              <Input placeholder='Password' onChangeText={(text) => this.setState({password: text})} secureTextEntry={true} placeholderTextColor="#687373" />
          </Item>
          {this.state.hasError?<Text style={{color: "#c0392b", textAlign: 'center', marginTop: 10}}>{this.state.errorText}</Text>:null}
          
          <View style={{alignItems: 'center'}}>
            <Button disabled={this.state.enableButton} rounded onPress={() => this.login()} style={{justifyContent: "center",width:110,backgroundColor: Colors.navbarBackgroundColor, marginTop: 20}}>
              <Text style={{color: '#fdfdfd',fontSize:18}}>Login</Text>
            </Button>
          </View>
        </View>
      </Container>
    );
  }

  login() {
    /*
      Remove this code and replace it with your service
      Username: this.state.username
      Password: this.state.password
    */
   if(this.state.username =="" || this.state.password =="")
   {
    this.setState({hasError: true, errorText: 'Please fill all fields !'});
    return;
   }
   else{
    this.setState({enableButton:true,hasError: true, errorText: 'Waiting...'});
   }

   axios.post('http://localhost:49911/api/Auths/', { 
      email: this.state.username,
      password:this.state.password,
    })
    .then(res => {
      if(res.data.isSuccess)
      {
        this.setState({hasError:true,errorText:'Registration Success, going to Home'})
       // alert('Registration Success, going to Home',1);
        MyGlobal.user_id = res.data.payload.id;
        setTimeout(() => {
          Actions.home();
        }, 2000);
      }else
      {
        this.setState({enableButton:false,hasError:true,errorText:res.data.message})
      }
    
    });
   

    
    //Actions.home();
  }


}
