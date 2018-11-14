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
import ListGame from './ListGameCategory'
import Colors from '../Colors'
import App from '../../App';
import ListGameCategory from './ListGameCategory';


export default class CategoryBlock extends Component {
  
  constructor(props)
  {
    super(props);
    this.state = {
      games: props.games,
      games_random:[],
      index:0,
      images:[],
      indexArray:[]
     };

   

    setInterval(() => {
      if(this.state.index==2)
      {
        this.setState({index:0});
      }else
      this.setState({index:this.state.index+1});
    }, 4050);
  }
  componentWillMount()
  {
    var images=[];
    var indexArray=[];
    var games_random=[];
    for(var i=0;i<3;i++)
    {
      var ran= Math.floor((Math.random() * 15) + 1);
      images.push(this.state.games[ran].imageGames[0].urlOnline);
      indexArray.push(ran);
    }
    this.setState({images:images,indexArray:indexArray});

    var last_random=[];
    for(var i=0;i<3;i++)
    {
      var ran=Math.floor((Math.random() * 15) + 1);
      while(last_random.includes(ran))
      {
        ran = Math.floor((Math.random() * 15) + 1)
      }
      last_random.push(ran);
      games_random.push(this.state.games[ran]);
     
    }
    this.setState({games_random:games_random});
  }

  onShowGameList()
  {
    Actions.gameListShow({games:this.state.games});
  }
  render() {
    return(
    
      <View  style={{flex:1,paddingTop:this.props._margin,backgroundColor: Colors.navbarBackgroundColor}}>
      <View> 
        <Text style={{fontSize:25,color:'white',fontWeight:'bold'}}>Super Hot!!!!!</Text>
      
        </View>
        <TouchableOpacity
        style={{marginTop:10}}
          onPress={()=>{Actions.GameShow({game:this.state.games[this.state.indexArray[this.state.index]]});}}
          activeOpacity={0.9}>   
          <View>

           
           <ImageSlider  autoPlayWithInterval={4000} style={styles.image} images={this.state.images}/>
           
            
          
            <View style={styles.text}>
             <Button  full  style={{marginStart:-15,backgroundColor: 'rgba(0, 0, 0, 0.5)',
             height:50,borderBottomStartRadius:50,borderBottomEndRadius:10}}>
                <Text  style={{paddingLeft:20,fontSize:18,width:'100%',color:'white',textAlign:'left'}}>
                {this.state.games[this.state.indexArray[this.state.index]].name}
                </Text>
             </Button>
            </View>
          </View>
        </TouchableOpacity>
        <View style={{width:'100%'}}>
      
          <ListGameCategory games={this.state.games_random}></ListGameCategory>
       
   
        </View>

             <TouchableOpacity onPress={() => this.onShowGameList()} style={{alignSelf:'flex-end',paddingEnd:15}}>
            <Text style={{color:'white',fontSize:25}}>See all</Text>
            </TouchableOpacity>
      </View>
  
    );
  }

  _onPress() {
    Actions.category({id: this.props.id, title: this.props.title});
  }
}

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
