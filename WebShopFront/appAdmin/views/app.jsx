const React = require('react');
const {useEffect} = require('react');
const { Routes, Route } = require('react-router');
const Router = require('react-router-dom').BrowserRouter;

const HomePage = require('./home/home.page.jsx');
const Header = require('./shared/header.jsx');
const LoginPage = require('./account/login.page.jsx');
const NewCategoryPage = require('./home/new.category.page.jsx');
const NewProductPage = require('./home/new.product.page.jsx');
const { useDispatch } = require('react-redux');

const adminAccountActionCreators = require('../actionCreators/admin.account.action.creators');

function App() {
    const dispatch = useDispatch();

    useEffect(()=>{
        dispatch(adminAccountActionCreators.tryLogin());
    },
    []);
    return <Router>
        <Header/>
        <Routes>
            <Route path='/' element={<HomePage />}/>
            <Route path='/login' element={<LoginPage />} />
            <Route path='/newCategory' element={<NewCategoryPage/>} />
            <Route path='/newProduct' element={<NewProductPage />} />
            <Route path='*' element={<HomePage />} />
        </Routes>
    </Router>
}

module.exports = App;