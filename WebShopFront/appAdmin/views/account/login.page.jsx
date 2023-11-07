const React = require('react');
const { useState } = require('react');
const { Form, Row, Col, Button } = require('react-bootstrap');

function LoginPage(props) {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [validated, setValid] = useState(false);

    const onLoginChange = (e) => {
        var val = e.target.value;
        setLogin(val);
    }

    const onPasswordChange = (e) => {
        var val = e.target.value;
        setPassword(val);
    }

    const validateLogin = (value) => {
        var count = value.split('@').length - 1;
        
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    }

    return (
        <div className='form-container'>
            <Form noValidate validated={validated} onSubmit={handleSubmit}>
                <div className='form-container__body'>
                    <Row md={'8'} className='mb-5'>
                        <Col className='text-center'>
                            <h3>Вход в систему</h3>
                        </Col>
                    </Row>
                    <Row md={'8'} className='mb-3'>
                        <Form.Group as={Col}>
                            <Form.Label>Логин (или E-mail)</Form.Label>
                            <Form.Control type='text' value={login} onChange={onLoginChange} required />
                        </Form.Group>
                    </Row>
                    <Row md={'8'} className='mb-5'>
                        <Form.Group as={Col}>
                            <Form.Label>Пароль</Form.Label>
                            <Form.Control type='password' value={password} onChange={onPasswordChange} required />
                        </Form.Group>
                    </Row>
                    <Row md={'8'} className='mt-5'>
                        <Col className='d-flex flex-column pt-3'>
                            <button type='submit' className='btn login-button'>Войти</button>
                        </Col>
                    </Row>
                </div>
            </Form>
        </div>
    );
}

module.exports = LoginPage;