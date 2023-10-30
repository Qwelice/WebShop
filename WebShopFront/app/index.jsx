import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import '../css/main.scss';

const React = require('react');
const ReactDOM = require('react-dom/client');

const App = require('./views/app.jsx');

ReactDOM.createRoot(document.getElementById('root'))
.render(
    <App/>
);