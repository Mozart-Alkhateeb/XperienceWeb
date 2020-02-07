import React, { Component } from 'react'
import { Icon } from 'semantic-ui-react'
import 'semantic-ui-css'
import { Modal, Button, Form } from 'react-bootstrap'
import { Multiselect } from 'multiselect-react-dropdown';


const renderLabel = (label) => ({
    color: 'blue',
    content: `Customized label - ${label.text}`,
    icon: 'check',
})


class EditAccount extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isOpen: false,
            options: [{ name: 'Srigar', id: 1 }, { name: 'Sam', id: 2 }],
            selectedValue : []
        }
    }

    onMultiSelect(selectedList, selectedItem) {

    }

    onMultiRemove(selectedList, removedItem) {

    }

    render() {
        return (
            <div>
                <Modal
                    size="md"
                    aria-labelledby="contained-modal-title-vcenter"
                    centered
                    show={this.props.isOpen}
                >
                    <Modal.Header>
                        <Modal.Title><Icon name='user' />Edit User</Modal.Title>
                    </Modal.Header>
                    <Modal.Body style={{ maxHeight: "30rem", overflowY: "scroll" }}>
                        <Form>
                            <Form.Group>
                                <Form.Label>Username</Form.Label>
                                <Form.Control type='text' />
                                <Form.Label>Name</Form.Label>
                                <Form.Control type='text' />
                                <Form.Label>D.O.B</Form.Label>
                                <Form.Control type='date' />
                                <Form.Label>Gender</Form.Label>
                                <Form.Control as='select'>
                                    <option>Male</option>
                                    <option>Female</option>
                                </Form.Control>
                                <Form.Label>Location</Form.Label>
                                <Form.Control type='text' />
                                <Form.Label>Languages</Form.Label>
                                <div>
                                    <Multiselect
                                        options={this.state.options} // Options to display in the dropdown
                                        selectedvalues={this.state.selectedValue} // Preselected value to persist in dropdown
                                        onSelect={this.onMultiSelect} // Function will trigger on select event
                                        onRemove={this.onMultiRemove} // Function will trigger on remove event
                                        displayValue="name" // Property name to display in the dropdown options
                                    />
                                </div>

                            </Form.Group>
                        </Form>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button>Save</Button>
                        <Button className="btn-danger" onClick={this.props.closeModal}>Cancel</Button>
                    </Modal.Footer>
                </Modal>
            </div>
        )
    }
}

export default EditAccount
