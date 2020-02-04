import React, { Component } from 'react'
import LeftSidebar from './Layout_Components/sidebar.js';
import TopNavbar from './Layout_Components/navbar.js';

class Root extends Component {
    constructor(){
        super();
        this.state = {
            isOpen : false
        }
    }
    update(){
        console.log("hello");
        this.setState(state => ({
            isOpen : !this.state.isOpen
        }))
    }
    render() {
        return (
            <div>
                <TopNavbar/>
            </div>
        )
    }
}
export default Root
