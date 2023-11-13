const React = require('react');
const { useState, useEffect } = require('react');
const { Navbar, Nav, Form, Button, Container, NavDropdown, Offcanvas, Row, Col } = require('react-bootstrap');
const { LinkContainer } = require('react-router-bootstrap');
const { Link, useNavigate } = require('react-router-dom');
const { useSelector, useDispatch } = require('react-redux')

const RegisterForm = require('../user/register.form.jsx');
const LoginForm = require('../user/login.form.jsx');

const accountActionCreators = require('../../actionCreators/account.action.creators');

function Header(props) {
    const navigage = useNavigate();
    const dispatch = useDispatch();

    const account = useSelector((state) => state.account);

    const [searchShow, setSearchShow] = useState(false);
    const [registerShow, setRegisterShow] = useState(false);
    const [isLoginType, setLoginType] = useState(true);

    useEffect(() => {
        dispatch(accountActionCreators.tryLogin());
    },
        []);

    const handleSearchClose = () => setSearchShow(false);
    const handleSearchShow = () => {
        setRegisterShow(false);
        setSearchShow(true);
    }

    const handleRegisterClose = () => setRegisterShow(false);
    const handleRegisterShow = () => {
        setRegisterShow(true);
        setSearchShow(false);
    }

    const handleProfileButton = () => {
        if (!account.logged) {
            handleRegisterShow();
        }
    }

    const userIcon = (logged) => {
        if (logged) {
            return <i className='bi bi-person-fill' style={{ fontSize: '1.5rem' }}></i>;
        } else {
            return <i className="bi bi-person" style={{ fontSize: '1.5rem' }}></i>;
        }
    }

    const userForm = () => {
        const handleRegisterButton = (type) => setLoginType(type);
        if (isLoginType) {
            return <LoginForm isLoginType={handleRegisterButton} />
        } else {
            return <RegisterForm isLoginType={handleRegisterButton} />
        }
    };

    const userOffcanvasTitle = () => {
        if (isLoginType) {
            return <Offcanvas.Title>Вход в аккаунт</Offcanvas.Title>;
        } else {
            return <Offcanvas.Title>Регистрация</Offcanvas.Title>;
        }
    }

    return (
        <Navbar expand="lg" className="bg-body-tertiary">
            <Container fluid>
                <LinkContainer to='/'>
                    <Navbar.Brand>WebShop</Navbar.Brand>
                </LinkContainer>
                <Nav className="ms-auto my-2 my-lg-0">
                    <LinkContainer className='p-2 me-3' to='/'>
                        <Nav.Link onClick={handleSearchShow}><i className="bi bi-search" style={{ fontSize: '1.5rem' }}></i></Nav.Link>
                    </LinkContainer>
                    <LinkContainer className='p-2 me-3' to='/'>
                        <Nav.Link onClick={handleProfileButton}>{userIcon(account.logged)}</Nav.Link>
                    </LinkContainer>
                    <LinkContainer className='p-2 me-3' to='/'>
                        <Nav.Link> <i className="bi bi-cart" style={{ fontSize: '1.5rem' }}></i> </Nav.Link>
                    </LinkContainer>
                </Nav>
            </Container>
            <Offcanvas show={searchShow} onHide={handleSearchClose} placement='start'>
                <Offcanvas.Header closeButton>
                    <Offcanvas.Title>Поиск товаров</Offcanvas.Title>
                </Offcanvas.Header>
                <Offcanvas.Body>
                    <Form className='d-flex'>
                        <Form.Control className='me-2' type='search' placeholder='поиск' aria-label='Search' />
                        <Button variant='outline-success'><i className="bi bi-search"></i></Button>
                    </Form>
                </Offcanvas.Body>
            </Offcanvas>
            <Offcanvas show={registerShow} onHide={handleRegisterClose} placement='end'>
                <Offcanvas.Header closeButton>
                    {userOffcanvasTitle()}
                </Offcanvas.Header>
                <Offcanvas.Body>
                    {userForm()}
                    <Row className='mb-4'>
                        <Col>
                            <Button type='submit' className='btn btn-secondary'>Зарегистрироваться</Button>
                        </Col>
                    </Row>
                </Offcanvas.Body>
            </Offcanvas>
        </Navbar>
    );
}

module.exports = Header;