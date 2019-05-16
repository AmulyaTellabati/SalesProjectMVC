/// <reference path="modal.js" />

import React, { Component } from 'react';
import ReactDOM from 'react-dom';       

import ModalDelete from './Modals/ModalDelete.jsx';

 class Products extends React.Component {
    constructor() {
        super();
        this.state = {
            ProductData: []
        }
    }

    componentDidMount() {
        axios.get("/home/GetProductData").then(response => {
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
    render() {
       
        return (
            <div>           
                
                <h1>Products List</h1>
                <div>
                    <table className="ui celled table">
                        <thead>
                            <tr>
                                <th>Product Id</th>
                                <th>Product Name</th>
                                <th>Product Price</th>
                                <th>Actions</th>
                                <th>Actions</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.ProductData.map((p, index) => {
                                    return <tr key={index}><td>{p.Id}</td><td> {p.Name}</td><td>{p.Price}</td><td><button className="ui yellow button"><i className="edit outline icon"></i>Edit</button> </td><td><ModalDelete
                                        headerTitle='Delete Product' userID={p.Id}
                                        buttonTriggerTitle='Delete' buttonIcon="trash alternate outline icon"
                                        buttonColor='red' /></td></tr>;
                                })
                            }
                        </tbody>
                    </table>
                    
                </div>
               

            </div>
        )
    }
}

ReactDOM.render(<Products></Products>, document.getElementById('main')); 