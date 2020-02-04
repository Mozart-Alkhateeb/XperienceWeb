import React, {Component} from 'react';
import Sidebar from 'react-sidebar'
import { Header, Icon, Image, Menu, Segment,Label,Input,Button } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'

class LeftSidebar extends Component{
    render(){
       return <div>

          <Sidebar
            sidebar={
                    <Menu secondary vertical style={{width : 100 + "%"}}>
                        <Menu.Item style={{color:"white"}}>
                            <Icon name="bars" size="big"/>
                        </Menu.Item>
                        <Menu.Item
                            name='inbox'
                            style={{color:"white"}}
                        >
                            <p></p>
                        </Menu.Item>
                        <Menu.Item
                            name='spam'
                            style={{color:"white"}}
                        >
                            <p></p>
                        </Menu.Item>
                        <Menu.Item style={{color:"white"}}>
                            <Label>7</Label>
                            
                        </Menu.Item>
                        <Menu.Item
                            name='updates'
                            style={{color:"white"}}
                        >
                            <p></p>
                        </Menu.Item>

                        <Menu.Item
                            name='updates'
                            style={{color:"white"}}
                        >
                            <p></p>
                        </Menu.Item>
                    </Menu>
            }
            styles={{ sidebar: { background: "black", width: "20%", color:"white" } }}
            open={this.props.isOpen}
        /> 
       </div>
    }
}

export default LeftSidebar;