import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Sidebar from 'react-sidebar'

class App extends Component {
    render() {
        return <div>
            <Sidebar
                sidebar = {<b>Sidebar Content</b>}
                styles={{ sidebar: { background: "black", width: "20%", color:"white" } }}
                open={true}
            >
            </Sidebar>
            
        </div>
    }
}

export default App;
