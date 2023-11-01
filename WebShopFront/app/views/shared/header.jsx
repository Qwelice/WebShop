const React = require('react');
const { Navbar, Nav, Form, Button, Container, NavDropdown, Offcanvas, Row, Col } = require('react-bootstrap');
const { LinkContainer } = require('react-router-bootstrap');
const { Link } = require('react-router-dom');

function Header(props) {
    const [searchShow, setSearchShow] = React.useState(false);
    const [registerShow, setRegisterShow] = React.useState(false);

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
                        <Nav.Link onClick={handleRegisterShow}><i className='bi bi-person' style={{ fontSize: '1.5rem' }}></i></Nav.Link>
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
                    <Offcanvas.Title>Регистрация</Offcanvas.Title>
                </Offcanvas.Header>
                <Offcanvas.Body>
                    <Form>
                        <Row className='mb-4'>
                            <Form.Group as={Col}>
                                <Form.Label>Введите почту</Form.Label>
                                <Form.Control type='email' placeholder='E-mail' />
                            </Form.Group>
                        </Row>
                        <Row className='mb-4'>
                            <Form.Group as={Col}>
                                <Form.Label>Введите пароль</Form.Label>
                                <Form.Control type='text' placeholder='Пароль' />
                            </Form.Group>

                        </Row>
                        <Row className='mb-4'>
                            <Form.Group as={Col}>
                                <Form.Label>Подтвердите пароль</Form.Label>
                                <Form.Control type='text' placeholder='Подтверждение пароля' />
                            </Form.Group>
                        </Row>
                    </Form>
                </Offcanvas.Body>
            </Offcanvas>
        </Navbar>
    );
}

function Test(props) {
    return (
        <Navbar expand='lg' className='bg-body-light'>
            <Link to='/'>WebShop</Link>

            <Nav className='me-auto'>
                <Nav.Item>
                    <Link><i className="bi bi-person"></i></Link>
                </Nav.Item>
                <Nav.Item>
                    <Link><i className="bi bi-bag"></i></Link>
                </Nav.Item>
            </Nav>
            <Navbar.Toggle aria-controls='navbar-expanded-content' />
            <Navbar.Collapse id='navbar-expanded-content'>
            </Navbar.Collapse>
        </Navbar>
    );
}

module.exports = Header;