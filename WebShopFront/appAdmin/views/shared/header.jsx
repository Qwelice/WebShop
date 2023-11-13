const React = require('react');
const { useState, useEffect } = require('react');
const { Navbar, Container, Form, Nav, Button } = require('react-bootstrap');
const { useSelector, useDispatch } = require('react-redux');
const { LinkContainer } = require('react-router-bootstrap');

function Header(props) {
    const dispatch = useDispatch();

    const admin = useSelector((state) => state.adminAccount);

    const [validated, setValid] = useState(false);

    const loggedPart = () => {
        if (!admin.logged) {
            return;
        }
        return (
            <Nav className='ms-auto my-2 my-lg-0'>
                <Nav.Item className='d-flex flex-column'>
                    <div className="logged me-3">Вы вошли как:</div>
                    <div className="logged__email me-3">{admin.email}</div>
                </Nav.Item>
                <Form noValidate validated={validated} onSubmit={handleSubmit}>
                    <Button className='btn login-button'>Выйти</Button>
                </Form>
            </Nav>
        );
    }


    const handleSubmit = (e) => {
        e.preventDefault();
    }

    return (
        <Navbar expand='lg'>
            <Container fluid>
                <LinkContainer to={'/'}>
                    <Navbar.Brand>Admin Panel</Navbar.Brand>
                </LinkContainer>
                {loggedPart()}
            </Container>
        </Navbar>
    );
}

module.exports = Header;