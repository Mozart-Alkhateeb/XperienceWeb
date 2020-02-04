import React, { Component } from 'react'
import { Header, Icon, Image, Menu, Segment, Label, Input, Button } from 'semantic-ui-react'

class TopNavbar extends Component {
    constructor(){
        super();
        this.state = {
            Name : "profile"
        }
    }
    setActive(e , {name}){
        this.setState(state => ({
            Name : name
        }))
    }
    render() {
        return (

            <Menu style={{ height: 5 + "rem" }}>
                <Menu.Menu>
                    <Menu.Item
                        name="feeds"
                        active = {this.state.Name === "feeds"}
                        onClick = {this.setActive.bind(this)}
                    ><Icon name="feed"/> Feeds</Menu.Item>
                    <Menu.Item
                        name="Notfs"
                        active = {this.state.Name === "Notfs"}
                        onClick = {this.setActive.bind(this)}
                    ><Icon name="bell"/> Notifications</Menu.Item>
                    <Menu.Item
                        name="Xplore"
                        active = {this.state.Name === "Xplore"}
                        onClick = {this.setActive.bind(this)}
                    ><Icon name="location arrow"/>Xplore</Menu.Item>
                    <Menu.Item
                        name="profile"
                        active = {this.state.Name === "profile"}
                        onClick = {this.setActive.bind(this)}
                    ><Icon name="user circle" /> Profile</Menu.Item>
                </Menu.Menu>
                <Menu.Menu position="right">
                    <Menu.Item>
                        <Input icon="search" placeholder="search..." />
                    </Menu.Item>
                    <Menu.Item>
                        <Button icon positive>
                            <Icon name="paper plane" />
                        </Button>
                    </Menu.Item>
                </Menu.Menu>
            </Menu>
        )
    }
}

export default TopNavbar;
