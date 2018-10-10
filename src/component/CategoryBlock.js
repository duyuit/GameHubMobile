/**
* This is the category component used in the home page
**/

// React native and others libraries imports
import React, { Component } from 'react';
import { Image, Dimensions, TouchableOpacity,ImageBackground } from 'react-native';
import { View, Button, Left, Body, Right  } from 'native-base';
import { Actions } from 'react-native-router-flux';
import ImageSlider from 'react-native-image-slider';
// Our custom files and classes import
import Text from './Text';
import ListGame from './ListGame'
import ListGameHori from './ListGameHori'
import Colors from '../Colors'

export default class CategoryBlock extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
     
     index:0,
    };

    setInterval(() => {
      if(this.state.index==2)
      {
        this.setState({index:0});
      }else
      this.setState({index:this.state.index+1});

     
    }, 4050);
  }
  render() {
    return(
    
      <View  style={{flex:1,paddingTop:this.props._margin,backgroundColor: Colors.navbarBackgroundColor}}>
      <View> 
        <Text style={{fontSize:25,color:'white',fontWeight:'bold'}}>Super Hot!!!!!</Text>
      
        </View>
        <TouchableOpacity
        style={{marginTop:10}}
          onPress={this._onPress.bind(this)}
          activeOpacity={0.9}>   
          <View>

           
           <ImageSlider  autoPlayWithInterval={4000} style={styles.image} images={[
        'https://img.gta5-mods.com/q95/images/gta-online-missions-for-sp/ff6dbe-gtaonline_art_2880x1800.jpg',
        'https://phongvu.vn/cong-nghe/wp-content/uploads/2018/09/csgo-free.jpg',
        'https://cdn.images.express.co.uk/img/dynamic/143/590x/PUBG-886916.jpg'
      ]}/>
           
            
          
            <View style={styles.text}>
             <Button  full  style={{marginStart:-15,backgroundColor: 'rgba(0, 0, 0, 0.5)',
             height:50,borderBottomStartRadius:50,borderBottomEndRadius:10}}>
                <Text  style={{paddingLeft:20,fontSize:18,width:'100%',color:'white',textAlign:'left'}}>
                {games[this.state.index].name}
                </Text>
             </Button>
            </View>
          </View>
        </TouchableOpacity>
        <View style={{width:'100%'}}>
        {
          this.props.isHoriental ? 
           <ListGameHori games={games}></ListGameHori> : <ListGame games={games}></ListGame>
        }
         
        </View>

      
      </View>
  
    );
  }

  _onPress() {
    Actions.category({id: this.props.id, title: this.props.title});
  }
}
var games=[
  {
    key:1,
    name:'GTA V',
    cost:100,
    tag:'FPS,Open world',
    img:'https://img.gta5-mods.com/q95/images/gta-online-missions-for-sp/ff6dbe-gtaonline_art_2880x1800.jpg'
  }
  ,
  {
    key:2,
    name:'CSGO',
    cost:100,
    tag:'FPS,Esport',
    img:'https://phongvu.vn/cong-nghe/wp-content/uploads/2018/09/csgo-free.jpg'
   
  }
  , 
  {
    key:3,
    name:'PUBG',
    cost:100,
    tag:'Survive, Battleground',
    img:'https://cdn.images.express.co.uk/img/dynamic/143/590x/PUBG-886916.jpg'

  }, 
  {
    key:3,
    name:'PUBG',
    cost:100,
    tag:'Survive, Battleground',
    img:'https://cdn.images.express.co.uk/img/dynamic/143/590x/PUBG-886916.jpg'

  },
  {
    key:2,
    name:'CSGO',
    cost:100,
    tag:'FPS,Esport',
    img:'https://phongvu.vn/cong-nghe/wp-content/uploads/2018/09/csgo-free.jpg'
   
  }];

const styles = {
  text: {
    width: Dimensions.get('window').width,
    height: 200,
    position: 'absolute',
    alignItems: 'flex-end',
    justifyContent: 'flex-end',
  },
  title: {
    textAlign: 'center',
    color: '#fdfdfd',
    fontSize: 32
  },
  subtitle: {
    textAlign: 'center',
    color: '#fdfdfd',
    fontSize: 16,
    fontWeight: '100',
    fontStyle: 'italic'
  },
  overlay: {
    position: 'absolute',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: 'rgba(30, 42, 54, 0.4)'
  },
  border: {
    position: 'absolute',
    top: 10,
    left: 10,
    right: 10,
    bottom: 10,
    borderWidth: 1,
    borderColor: 'rgba(253, 253, 253, 0.2)'
  },
  image: {
    height: 200,
    width: null,
    flex: 1
  }
};
