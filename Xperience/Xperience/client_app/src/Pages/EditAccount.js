import React, { Component } from 'react'
import { Modal, Confirm, Button, Form } from 'semantic-ui-react'

const modalStyle = {
    //height: '90%'
}

class EditAccount extends Component {
    constructor(props) {
        super(props);
        this.state = {
            confirmOpen: false
        }
    }

    close(){
        this.setState(state => ({confirmOpen : false}));
    }
    open(){
        this.setState(state => ({confirmOpen : true}));
    }

    render() {
        return (
            <div>
                <Modal size="tiny" open={this.props.isOpen} style={modalStyle}>
                    <Modal.Header icon="edit" content="Edit Account" />
                    <Modal.Content scrolling>
                        <Modal.Description>
                            <Form>
                                <Form.Input label="Username" />
                                <Form.Input label="Name" />
                                <Form.Input label="DOB" />
                                <Form.Input label="Gender" />
                                <Form.Input label="location" />
                                <Form.Input label="langs" />
                                <Form.Input label="Nations" />
                                <Form.Input label="Biography" />
                                <Form.Input label="Info" />
                            </Form>
                        </Modal.Description>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button color='green' onClick={this.open.bind(this)}>Save</Button>
                        <Button color='red' onClick={this.props.closeModal}>Close</Button>
                    </Modal.Actions>
                </Modal>
                <Confirm
                    open={this.state.confirmOpen}
                    onCancel={this.close.bind(this)}
                    onConfirm={this.close.bind(this)}
                />
            </div>
        )
    }
}

export default EditAccount
