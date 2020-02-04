import React, { Component } from 'react'
import {Container, Row, Col} from 'react-bootstrap'
import { animated as a} from 'react-spring'
import {Image} from 'semantic-ui-react'




const form = {
    marginTop : "100px",
    background: "white",
    height : "500px",
    borderRadius : "0.5em",
    border: "2px solid #F5F5F5",
}

class Index extends Component {
    constructor(){
        super();
        document.body.style = "background : linear-gradient(to right, #00C9FF, #92FE9D)";
    }
    render() {
        return (
            <div>
                <Container>
                    <Row className='justify-content-md-center'>
                        <Col sm={7}>
                            <Image src={require("./logo.png")} size='large' style={{marginTop:"20%"}}/>
                        </Col>
                        <Col sm={5} style={form}>
                            {this.props.children}
                        </Col>
                    </Row>
                </Container>
            </div>
        )
    }
}

export default Index
