const React = require('react');
const { Routes, Route } = require('react-router');
const Router = require('react-router-dom').BrowserRouter;

const Header = require('./shared/header.jsx');
const HomePage = require('./home/home.page.jsx');
const CatalogPage = require('./home/catalog.page.jsx');
const OrderPage = require('./home/order.page.jsx');

function App() {
    return <Router>
        <Header/>
        <Routes>
            <Route path='/' element={<HomePage/>} />
            <Route path='/catalog' element={<CatalogPage/>} />
            <Route path='/orders' element={<OrderPage />} />
            <Route path='*' element={<HomePage/>} />
        </Routes>
    </Router>
}

module.exports = App;