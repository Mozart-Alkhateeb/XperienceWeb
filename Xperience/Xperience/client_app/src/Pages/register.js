import React, { Component } from 'react'
import { Input, Button, Form, Label, Select } from 'semantic-ui-react'
import {Link} from 'react-router-dom'

const options = [
    { key: 'm', text: 'Male', value: 'male' },
    { key: 'f', text: 'Female', value: 'female' },
]

export class register extends Component {
    render() {
        return (
            <div style={{ padding: "30px" }}>
                <Form>
                    <h1>Register</h1>
                    <Form.Input fluid label='Username' />
                    <Form.Input fluid label='Email' />
                    <Form.Group widths="equal">
                        <Form.Input fluid label='Password' type='password' />
                        <Form.Input fluid label='Confirm Password' type='password' />
                    </Form.Group>
                    <Form.Group widths="equal">
                        <Form.Input fluid label='D.O.B' type='date' />
                        <Form.Field
                            control={Select}
                            label='Gender'
                            options={options}
                            placeholder='Gender'
                        />
                    </Form.Group>
                    <Button type="submit" primary style={{ marginTop: "30px" }}>Register</Button>
                    Already Have an Account? <Link to="/login">Log in!</Link>

                </Form>
            </div>
        )
    }
}

export default register

