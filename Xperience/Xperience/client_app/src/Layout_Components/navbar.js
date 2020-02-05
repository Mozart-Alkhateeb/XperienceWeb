import React, { Component } from 'react'
import { Header, Icon, Image, Menu, Segment, Label, Input, Button } from 'semantic-ui-react'
import 'semantic-ui-css'
import { Navbar, Nav, Form ,FormControl} from 'react-bootstrap'

class TopNavbar extends Component {
    constructor() {
        super();
        this.state = {
            Name: "profile"
        }
    }
    setActive(e, { name }) {
        this.setState(state => ({
            Name: name
        }))
    }
    render() {
        return (
            <Navbar bg="dark" variant="dark" style={{ height: "4rem" }}>
                <Navbar.Brand>Xperience</Navbar.Brand>
                <Nav className='mr-auto'>
                    <Nav.Link><Icon name="feed" />Feeds</Nav.Link>
                    <Nav.Link><Icon name="location arrow" />Xplore</Nav.Link>
                    <Nav.Link><Icon name="bell" /> Notifications</Nav.Link>
                    <Nav.Link><Icon name="user outline" /> Profile</Nav.Link>
                </Nav>
                <Form inline>
                    <FormControl type="text" placeholder="Search" className="mr-sm-2" />
                    <Button variant="outline-info">Search</Button>
                </Form>
            </Navbar>
        )
    }
}

export default TopNavbar;
