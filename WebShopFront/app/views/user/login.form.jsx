const React = require('react');
const { useState, useEffect } = require('react');
const { Button, Form, Row, Col } = require('react-bootstrap');
const { useDispatch, useSelector } = require('react-redux');

const accountActionCreators = require('../../actionCreators/account.action.creators');
const { useNavigate } = require('react-router');

function LoginForm(props) {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const account = useSelector((state) => state.account);

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [validated, setValidated] = useState(false);

    const onEmailChange = (e) => {
        var val = e.target.value;
        setEmail(val);
    }

    const onPasswordChange = (e) => {
        var val = e.target.value;
        setPassword(val);
    }

    const handleRegisterButton = () => {
        props.isLoginType(false);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        setValidated(true);
        dispatch(accountActionCreators.login(email, password));
    }

    const errorText = () => {
        return (
            <div className="error__text text-danger">
                {account.error}
            </div>
        );
    }

    return (
        <Form noValidate validated={validated} onSubmit={handleSubmit}>
            <Row className='mb-4'>
                <div className="error__text">
                    {errorText()}
                </div>
            </Row>
            <Row className='mb-4'>
                <Form.Group as={Col}>
                    <Form.Label>Введите почту</Form.Label>
                    <Form.Control type='email' placeholder='E-mail' onChange={onEmailChange} value={email} required />
                </Form.Group>
            </Row>
            <Row className='mb-4'>
                <Form.Group as={Col}>
                    <Form.Label>Введите пароль</Form.Label>
                    <Form.Control type='password' placeholder='Пароль' onChange={onPasswordChange} value={password} required />
                </Form.Group>

            </Row>
            <Row className='mb-4'>
                <Col>
                    <Button type='submit' variant='secondary'>Войти</Button>
                </Col>
                <Col>
                    <Button type='button' variant='outline-secondary' onClick={handleRegisterButton}>Регистрация</Button>
                </Col>
            </Row>
        </Form>
    );
}

module.exports = LoginForm;