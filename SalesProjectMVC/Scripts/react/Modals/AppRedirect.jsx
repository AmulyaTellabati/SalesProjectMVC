
import React from 'react'
import { Route, Switch, Redirect } from 'react-router-dom'
import { createGlobalStyle } from 'styled-components'


import Customer from '../Pages/Customer.jsx'
import Products from '../Pages/Products.jsx'
import Stores from '../Pages/Stores.jsx'
import Sales from '../Pages/Sales.jsx'
import NavBar from '../Pages/MenuNav.jsx'

const GlobalStyle = createGlobalStyle`
  body, html {
    padding: 0;
    margin: 0;
  }
  *, *:before, *:after {
    padding: 0;
    margin: 0;
  }
`

const App = () => {


    return (
   <div>
            <GlobalStyle />
            <NavBar />
            <Switch>
                
                <Route path="/Products" component={Products} />
                <Route path="/Customers" component={Customer} />
                <Route path="/Stores" component={Stores} />
                <Route path="/Sales" component={Sales} />

                  < Redirect to = "/Products" />
            </Switch>
       </div>
    )
}

export default App

