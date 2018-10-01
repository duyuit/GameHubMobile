import {StyleSheet} from "react-native";
export default  styles= StyleSheet.create({
    container: {
        flex:1,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
    },
    logo:
        {
            width: 150,
            height: 150,
              resizeMode: 'contain'
        },

    textRegister:
        {   alignSelf:'flex-end',
            color:'white',
            fontStyle:'italic',
            fontSize:15,
        },
    textLogin:
        {
            marginTop:20,
            color:'white',
            fontSize:20,
        },
    inputText:
        {
            backgroundColor:'rgba(255, 255, 255,1)',
            padding:10,
            width:300,
            fontSize:18,
            color:'white',
            opacity:1
        },
    imageSocial:
        {
            width:40,
            height:40,
            resizeMode: 'contain'

        }
});
