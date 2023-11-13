import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import 'bootstrap-icons/font/bootstrap-icons.min.css';
import '../scss/main.scss';

const React = require('react');
const ReactDOM = require('react-dom/client');
const Provider = require('react-redux').Provider;

const App = require('./views/app.jsx');
const store = require('./helpers/store');

ReactDOM.createRoot(document.getElementById('root'))
    .render(
        <Provider store={store}>
            <App />
        </Provider>
    );