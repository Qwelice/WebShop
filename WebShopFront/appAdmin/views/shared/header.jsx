const React = require('react');
const { Navbar, Container } = require('react-bootstrap');
const { LinkContainer } = require('react-router-bootstrap');

function Header(props) {
    return (
        <Navbar expand='lg'>
            <Container fluid>
                <LinkContainer to={'/'}>
                    <Navbar.Brand>Admin Panel</Navbar.Brand>
                </LinkContainer>
            </Container>
        </Navbar>
    );
}

module.exports = Header;