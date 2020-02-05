import React, { Component } from 'react'
import { Header, Icon, Button } from 'semantic-ui-react'
import { Row, Col, Container } from 'react-bootstrap'
import 'semantic-ui-css'
import EditAccount from './EditAccount'

class Account extends Component {
    constructor() {
        super();
        this.getData();

        this.state = {
            user: null,
            ModalOpen : false
        }
    }
    getData() {
        fetch("/api/Users").then(res => res.json())
            .then((result) => {
                this.setState({
                    user: result
                });
            })
    }
    openModal(){
        this.setState(state =>({
            user : this.state.user,
            ModalOpen : true
        }))
    }
    closeModal(){
        this.setState(state =>({
            user : this.state.user,
            ModalOpen : false
        }))
    }
    render() {
        return (
            <div style={{ marginTop: 50 + "px" }}>
                <Container>
                    <Row className='justify-content-md-center'>
                        <Col sm={2} >
                            <Header icon>
                                <Button icon style={{ height: '10rem', width: '10rem', background: 'rgba(0,0,0,0)' }}>
                                    <Icon name='user outline' />
                                </Button>
                            </Header>
                        </Col>
                        <Col sm={6}>
                            <center>
                                <h2>This is your name</h2>
                                <p>
                                    <Button content="Primary" primary onClick={this.openModal.bind(this)}> Edit Profile</Button>
                                    <Button icon>
                                        <Icon name="setting" />
                                    </Button>
                                </p>
                                <p>
                                    This is a useless biography. Please for a good biography go to facebook or instagram bcz we
                                    dont care abt you mfs yeah!
                                </p>
                            </center>
                        </Col>
                    </Row>
                    <hr color="black" width="1000" />
                </Container>
                <EditAccount isOpen = {this.state.ModalOpen} closeModal={this.closeModal.bind(this)}/>
            </div>
        )
    }
}
export default Account;
