import React, { Component } from 'react';
import './App.css';
import Root from './root'
import Account from './Pages/account'
import Register from './Pages/register'
import Index from './Pages/index'
import { BrowserRouter as Router, Route, Switch, Redirect } from 'react-router-dom'
import Login from './Pages/login';
import EditAccount from './Pages/EditAccount'
import 'bootstrap/dist/css/bootstrap.css';


class App extends Component {
    constructor() {
        super();
        this.state = {
            sidebarOpen: false
        }
    }

    render() {
        return <div>

            <Router>
                <Switch>
                    <Route exact path={"/"}>
                        <Redirect to={"/register"} />
                    </Route>
                    <Route path={"/account"}>
                        <Root />
                        <Account />
                    </Route>
                    <Route path={"/register"}>
                        <Index>
                            <Register />
                        </Index>
                    </Route>
                    <Route path={"/login"}>
                        <Index>
                            <Login />
                        </Index>
                    </Route>
                </Switch>
            </Router>
        </div>
    }
}

export default App;
