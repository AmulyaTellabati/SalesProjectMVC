import React, { Component } from 'react'
import { render } from 'react-dom'
import { BrowserRouter } from 'react-router-dom'

import App from './Modals/AppRedirect.jsx'

function renderApp() {
    render(
        <BrowserRouter>
            <App />
        </BrowserRouter>,
        document.getElementById('main')
    )
}
renderApp()

// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept()
    //module.hot.accept('./routes', () => { const NextApp = require('./routes').default; renderApp(); });
}
