const React = require('react');
const { useNavigate } = require('react-router');

function HomePage(props){
    const navigate = useNavigate();
    return navigate('*');
}

module.exports = HomePage;