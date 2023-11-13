const React = require('react');
const { useState, useEffect } = require('react');
const { Button, Offcanvas, ListGroup } = require('react-bootstrap');
const { useSelector, useDispatch } = require('react-redux');
const { useNavigate } = require('react-router');
const NavPanelButton = require('../shared/nav.panel.button.jsx');
const NavPanelOffcanvas = require('../shared/nav.panel.offcanvas.jsx');
const NavPanel = require('../shared/nav.panel.jsx');

function HomePage(props) {
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const admin = useSelector((state) => state.adminAccount);

    useEffect(() => {
        if (!admin.logged) {
            navigate('/login');
        }
    }, [])

    return (
        <div className="home">
            <div className="home__body">
                <NavPanel />
            </div>
        </div>
    );
}

module.exports = HomePage;