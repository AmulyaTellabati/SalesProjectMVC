﻿import React, { Component } from 'react';
import { Button, Modal } from 'semantic-ui-react';
import axios from 'axios';

class ModalDelete extends Component {

    constructor(props) {
        super(props);

        this.state = {
            modalOpen: false
        }

        this.handleOpen = this.handleOpen.bind(this);
        this.handleClose = this.handleClose.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleOpen(e) { this.setState({ modalOpen: true }) };
    handleClose(e) { this.setState({ modalOpen: false }) };

    handleSubmit(e) {

        let params = e.target.getAttribute('data-userid');
        let path = this.props.pathname;

        let url = `/` + path+`/Delete`+path+`/${params}`;

        axios.get(url).then(response => {
            this.handleClose();
            this.props.onUserDeleted(params);
        }).catch((err) => {
                this.handleClose();
                throw err;
         });
    }

    render() {
        return (
            <Modal
                trigger={<Button onClick={this.handleOpen} color={this.props.buttonColor}><i className={this.props.buttonIcon}></i>{this.props.buttonTriggerTitle}</Button>}
                open={this.state.modalOpen} pathname={this.props.pathname} onClose={this.handleClose} size='tiny'>
                <Modal.Header>{this.props.headerTitle}</Modal.Header>
                <Modal.Content>
                    <p>Are you sure you want to delete?</p>
                </Modal.Content>
                <Modal.Actions>
                    <Button onClick={this.handleSubmit} data-userid={this.props.userID} color='red'>Yes</Button>
                    <Button onClick={this.handleClose} color='black'>No</Button>
                </Modal.Actions>
            </Modal>
        );
    }
}

export default ModalDelete;