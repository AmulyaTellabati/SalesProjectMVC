import React, { Component } from 'react';
import ReactDOM from 'react-dom';
//import { Button } from 'semantic-ui-react';

export class Products extends React.Component {
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

    render() {

        return (
            <section>           
                
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
                                    return <tr key={index}><td>{p.Id}</td><td> {p.Name}</td><td>{p.Price}</td><td><Button className="ui red button">Edit</Button></td><td><button className="ui red basic button">Delete</button></td></tr>;
                                })
                            }
                        </tbody>
                    </table>
                </div>


            </section>
        )
    }
}

ReactDOM.render(<Products></Products>, document.getElementById('main')); 



//class Sales extends React.Component {
//    constructor() {
//        super();
//        this.state = {
//            SalesData: []
//        }
//    }

//    componentDidMount() {
//        axios.get("/home/GetSalesData").then(response => {
//            console.log(response.data);
//            this.setState({
//                SalesData: response.data
//            });
//        });
//    }

//    render() {

//        return (
//            <section>
//                <h1>Sales List</h1>
//                <div>
//                    <table>
//                        <thead><tr><th>Sales Id</th><th>Customer</th><th>Product</th><th>Store</th><th>Date Sold</th></tr></thead>
//                        <tbody>
//                            {
//                                this.state.SalesData.map((s, index) => {
//                                    return <tr key={index}><td>{s.Id}</td><td> {s.customer}</td><td>{s.Price}</td></tr>;
//                                })
//                            }
//                        </tbody>
//                    </table>
//                </div>


//            </section>
//        )
//    }
//}

//ReactDOM.render(<Sales></Sales>, document.getElementById('Sales')); 