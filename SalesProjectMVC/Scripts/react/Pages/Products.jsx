import React, { Component } from 'react';
import ReactDOM from 'react-dom';

import ModalDelete from '../Modals/ModalDelete.jsx';
import ModalCreate from '../Modals/ModalCreate.jsx';

class Products extends React.Component {
    constructor() {
        super();
        this.state = {
            ProductData: []
        }
        this.handleUserAdded = this.handleUserAdded.bind(this);
        this.handleUserUpdated = this.handleUserUpdated.bind(this);
        this.handleUserDeleted = this.handleUserDeleted.bind(this);
    }



    componentDidMount() {
        axios.get("/Product/GetProductData").then(response => {
            console.log(response.data);
            this.setState({
                ProductData: response.data
            });
        });
    }
    onCloseModal() {
        this.setState({
            active: false
        });
    }

    handleUserAdded(user) {
        let ProductData = this.state.ProductData.slice();
        ProductData.push(user);
        this.setState({ ProductData: ProductData });
    }

    handleUserUpdated(user) {
        let ProductData = this.state.ProductData.slice();
        for (let i = 0, n = users.length; i < n; i++) {
            if (ProductData[i]._id === user._id) {
                ProductData[i].name = user.name;
                ProductData[i].price = user.price;

                break; // Stop this loop, we found it!
            }
        }
        this.setState({ ProductData: ProductData });
    }

    handleUserDeleted(id) {
        let ProductData = this.state.ProductData.slice();
        ProductData = ProductData.filter(u => { return u.Id != id; });
        this.setState({ ProductData: ProductData });
    }
    render() {

        return (
            <div className="ui container">

                <h1>Products List</h1>
                <div>
                    <ModalCreate
                        headerTitle='Create Product'
                        buttonTriggerTitle='Create New'
                        buttonSubmitTitle='Save' buttonColor='blue' pathname='Product'
                        onUserAdded={this.handleUserAdded} label='Price'
                        type='number' PH='100' ML='4'/>
                    <table className="ui celled table">
                        <thead>
                            <tr>
                                <th>Product Name</th>
                                <th>Product Price</th>
                                <th>Actions</th>
                                <th>Actions</th>

                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.ProductData.map((p, index) => {
                                    return <tr key={index}><td> {p.Name}</td><td>{p.Price}</td><td> <ModalCreate
                                        headerTitle='Edit Product' buttonTriggerTitle='Edit' buttonIcon="edit outline icon"
                                        buttonSubmitTitle='Save' buttonColor='yellow'
                                        userID={p.Id} pathname='Product' onUserUpdated={this.handleUserUpdated} label='Price'
                                        type='number' PH='100' ML='4' /> </td><td><ModalDelete
                                            headerTitle='Delete Product' userID={p.Id} pathname='Product'
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

//ReactDOM.render(<Products></Products>, document.getElementById('main'));

export default Products