import React, { Component } from 'react';
import { Message, Button, Form, Select } from 'semantic-ui-react';
import axios from 'axios';


class SelectedSale extends Component {

    constructor(props) {
        super(props);

        this.state = {
            value: 'select',
            selectedproduct: '', selectedstore: '', selectedcustomer: '',
            validationError: ''
        }
        this.handleChange = this.handleChange.bind(this);
    }
    //handleInputChange(e) {
    //    debugger;
    //    const target = e.target;
    //    // const value = target.type === 'checkbox' ? target.checked : target.value;
    //    const Name = target.name;
    //    this.setState({ [Name]: value });
    //}
    handleChange(event) {
        this.setState({ value: event.target.value });
        { this.props.change}
    }


    render() {
       
        var items = this.props.node;
        return (<div>
            <label >{this.props.name}</label><br />
            <select name={this.props.name} value={this.state.value} onChange={this.handleChange}>
               
                {
                    items.map(function (item) {
                        return <option value={item.Id} key={item.Id}>{item.Name}</option>;
                    })
                }
            </select><br/></div>);
    }

}   

    export default SelectedSale;

//onChange = { this.props.change }

//<DateInput
//    name="date"
//    placeholder="Date"
//    value={this.state.date}
//    iconPosition="left"
//    onChange={this.handleChange}
///>

//<label>Customer</label>
//    <Dropdown selection name='selectedcustomer' placeholder='Select'
//        value={this.state.selectedcustomer} options={CustOptions} onChange={this.handleInputChange}></Dropdown>


//<Form.Select
//    label='Customer' placeholder='' id='selectedcustomer' name='selectedcustomer' value={this.state.selectedcustomer} options={CustOptions} onChange={this.handleInputChange} />

//    <Form.Field>
//        <label>Product</label>
//        <Dropdown selection simple
//            name='selectedproduct' placeholder='Select' options={PdtOptions}
//            value={this.state.selectedproduct} onChange={this.handleInputChange}></Dropdown>
//    </Form.Field>




//    <Form.Field>
//        <label>Store</label>
//        <Dropdown selection name='selectedstore'
//            value={this.state.selectedstore} placeholder='Select' options={StoreOptions} onChange={this.handleInputChange}></Dropdown>
//    </Form.Field>

//<SelectedSale name='Product' node={this.state.products} change={this.handleInputChange} />
//    <SelectedSale name='Customer' node={this.state.customers} change={this.handleInputChange} />
//    <SelectedSale name='Store' node={this.state.stores} change={this.handleInputChange} />
        //const PdtOptions = this.state.products.map((p, index) => ({
        //    key: p.Id,
        //    text: p.Name,
        //    value: p.Name,
        //}));
        //const CustOptions = this.state.customers.map((p, index) => ({
        //    key: p.Id,
        //    text: p.Name,
        //    value: p.Name,
        //}));
        //const StoreOptions = this.state.stores.map((p, index) => ({
        //    key: p.Id,
        //    text: p.Name,
        //    value: p.Name,
        //}));