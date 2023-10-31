const React = require('react');
const { Navbar, Nav } = require('react-bootstrap');
const { Link } = require('react-router-dom');

function Header(props) {
    return (
        <Navbar expand='lg' className='bg-body-light'>
            <Navbar.Brand>
                <Link to='/'>WebShop</Link>
            </Navbar.Brand>
            <Navbar.Toggle aria-controls='navbar-expanded-content'/>
            <Navbar.Collapse id='navbar-expanded-content'>
                <Nav className='m-auto'>
                    
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    );
}

module.exports = Header;