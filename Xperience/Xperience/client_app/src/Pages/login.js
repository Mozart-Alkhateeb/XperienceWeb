import React, { Component } from 'react'
import { Input, Button, Form, Label, Select } from 'semantic-ui-react'
import { Link } from 'react-router-dom'

class Login extends Component {
    render() {
        return (
            <div style={{ paddingTop: "100px", paddingLeft:"30px", paddingRight : "50px" }}>
                <Form>
                    <h1>Log in</h1>
                    <Form.Input fluid label='Username' />
                    <Form.Input fluid label='password' type="password" />
                    <Button type="submit" primary style={{ marginTop: "30px" }}>Log in</Button><br/><br/><br/>
                    Don't have an account?<Link to="/register"> Register!</Link>

                </Form>
            </div>
        )
    }
}

export default Login
