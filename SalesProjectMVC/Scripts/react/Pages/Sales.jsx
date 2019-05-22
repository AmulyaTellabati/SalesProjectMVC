import React, { Component } from 'react';
import ReactDOM from 'react-dom';

import ModalDelete from '../Modals/ModalDelete.jsx';
import ModalCreate from '../Modals/ModalCreate.jsx';

class Sales extends React.Component {
    constructor() {
        super();
        this.state = {
            SalesData: []
        }
        this.handleUserAdded = this.handleUserAdded.bind(this);
        this.handleUserUpdated = this.handleUserUpdated.bind(this);
        this.handleUserDeleted = this.handleUserDeleted.bind(this);
    }



    componentDidMount() {
        axios.get("/Sales/GetSaleData").then(response => {
            console.log(response.data);
            this.setState({
                SalesData: response.data
            });
        });
    }
    onCloseModal() {
        this.setState({
            active: false
        });
    }

    handleUserAdded(user) {
        let SalesData = this.state.SalesData.slice();
        SalesData.push(user);
        this.setState({ SalesData: SalesData });
    }

    handleUserUpdated(user) {
        let SalesData = this.state.SalesData.slice();
        for (let i = 0, n = users.length; i < n; i++) {
            if (SalesData[i]._id === user._id) {
                SalesData[i].name = user.name;
                SalesData[i].price = user.price;

                break; // Stop this loop, we found it!
            }
        }
        this.setState({ SalesData: SalesData });
    }

    handleUserDeleted(id) {
        let SalesData = this.state.SalesData.slice();
        SalesData = SalesData.filter(u => { return u.Id != id; });
        this.setState({ SalesData: SalesData });
    }
    render() {

        return (
            <div className="ui container">

                <h1>Sales List</h1>
                <div>
                    <ModalCreate
                        headerTitle='Create Sale'
                        buttonTriggerTitle='New Sale'
                        buttonSubmitTitle='Save'
                        buttonColor='blue'
                        onUserAdded={this.handleUserAdded} />
                    <table className="ui celled table">
                        <thead>
                            <tr>
                                <th>Customer</th>
                                <th>Product</th>
                                <th>Store</th>
                                <th>DateSold</th>
                                <th>Actions</th>
                                <th>Actions</th>

                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.SalesData.map((se, index) => {
                                    return <tr key={index}><td> {se.Name}</td><td>{se.Price}</td><td> <ModalCreate
                                        headerTitle='Edit Sale'
                                        buttonTriggerTitle='Edit' buttonIcon="edit outline icon"
                                        buttonSubmitTitle='Save'
                                        buttonColor='yellow'
                                        userID={se.Id}
                                        onUserUpdated={this.handleUserUpdated} /> </td><td><ModalDelete
                                            headerTitle='Delete Sale' userID={se.Id}
                                            buttonTriggerTitle='Delete' buttonIcon="trash alternate outline icon"
                                            buttonColor='red' onUserDeleted={this.handleUserDeleted} /></td></tr>;
                                })
                            }
                        </tbody>
                    </table>

                </div>


            </div>
        )
    }
}

export default Sales