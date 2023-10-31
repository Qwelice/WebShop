const React = require('react');
const { Routes } = require('react-router');
const Router = require('react-router-dom').BrowserRouter;

const Header = require('./shared/header.jsx');

function App() {
    return <Router>
        <Header/>
        <div className="test__block">
            <h2>Hello, World!</h2>
        </div>
        <Routes>

        </Routes>
    </Router>
}

module.exports = App;