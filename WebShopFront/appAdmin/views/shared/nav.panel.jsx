const React = require('react');
const {useState, useEffect} = require('react');
const NavPanelButton = require('./nav.panel.button.jsx');
const NavPanelOffcanvas = require('./nav.panel.offcanvas.jsx');

function NavPanel(props){
    const [navPanelShow, setNavPanelShow] = useState(false);

    const showNavPanel = () => setNavPanelShow(true);
    const handleNavPanelClose = () => setNavPanelShow(false);

    return (
        <div>
            <NavPanelButton showNavPanel={showNavPanel}/>
            <NavPanelOffcanvas navPanelShow={navPanelShow} handleNavPanelClose={handleNavPanelClose} />
        </div>
    );
}

module.exports = NavPanel;