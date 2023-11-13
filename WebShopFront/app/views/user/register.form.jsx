const React = require('react');
const { Form, Row, Col, Button } = require('react-bootstrap');
const { useState } = require('react');
const { useSelector, useDispatch } = require('react-redux');

const accountActionCreators = require('../../actionCreators/account.action.creators');

function RegisterForm(props) {
    const account = useSelector((state) => state.account);
    const dispatch = useDispatch();

    const [validated, setValidated] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState('');
    const [passwordConfirm, setPasswordConfirm] = useState('');

    const onEmailChange = (e) => {
        var val = e.target.value;
        setEmail(val);
    }

    const onPasswordChange = (e) => {
        var val = e.target.value;
        setPassword(val);
    }

    const onPasswordConfirmChange = (e) => {
        var val = e.target.value;
        setPasswordConfirm(val);
        const control = e.target;
        control.setCustomValidity('');
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        const form = e.currentTarget;
        const passConfirm = form.passwordConfirm;

        if (password != passwordConfirm) {
            passConfirm.setCustomValidity('Пароли не совпадают');
            setValidated(true);
            return;
        }

        setValidated(true);

        dispatch(accountActionCreators.register(email, password));
    }

    const handleEnterButton = () => {
        props.isLoginType(true);
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
                    <Form.Control name='email' type='email' placeholder='E-mail' onChange={onEmailChange} value={email} required />
                    <Form.Control.Feedback type="invalid">Некорректный email</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className='mb-4'>
                <Form.Group as={Col}>
                    <Form.Label>Введите пароль</Form.Label>
                    <Form.Control name='password' type='password' placeholder='Пароль' onChange={onPasswordChange} value={password} required />
                    <Form.Control.Feedback type="invalid">Пароль не может быть пустым</Form.Control.Feedback>
                </Form.Group>

            </Row>
            <Row className='mb-4'>
                <Form.Group as={Col}>
                    <Form.Label>Подтвердите пароль</Form.Label>
                    <Form.Control name='passwordConfirm' type='password' placeholder='Подтверждение пароля' onChange={onPasswordConfirmChange} value={passwordConfirm} required />
                    <Form.Control.Feedback type="invalid">Пароли не совпадают</Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Row className='mb-4'>
                <Col>
                    <Button type='submit' variant='secondary'>Зарегистрироваться</Button>
                </Col>
                <Col>
                    <Button type='button' variant='outline-secondary' onClick={handleEnterButton}>Есть аккаунт?</Button>
                </Col>
            </Row>
        </Form>
    );
}

module.exports = RegisterForm;