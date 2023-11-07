const React = require('react');
const { Routes, Route } = require('react-router');
const Router = require('react-router-dom').BrowserRouter;

const HomePage = require('./home/home.page.jsx');
const Header = require('./shared/header.jsx');
const LoginPage = require('./account/login.page.jsx');

function App() {
    return <Router>
        <Header/>
        <Routes>
            <Route path='/' element={<LoginPage/>}/>
        </Routes>
    </Router>
}

module.exports = App;