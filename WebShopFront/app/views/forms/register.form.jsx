const React = require('react');
const { Form, Row, Col, Button } = require('react-bootstrap');
const { useState } = require('react');
const {useSelector, useDispatch} = require('react-redux');

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
    }

    const handleSubmit = (e) => {
        // dispatch(accountActionCreators.register(email, password));
    }

    return (
        <Form noValidate validated={validated} onSubmit={handleSubmit}>
            <Row className='mb-4'>
                <Form.Group as={Col}>
                    <Form.Label>Введите почту</Form.Label>
                    <Form.Control type='email' placeholder='E-mail' onChange={onEmailChange} value={email} />
                </Form.Group>
            </Row>
            <Row className='mb-4'>
                <Form.Group as={Col}>
                    <Form.Label>Введите пароль</Form.Label>
                    <Form.Control type='password' placeholder='Пароль' onChange={onPasswordChange} value={password} />
                </Form.Group>

            </Row>
            <Row className='mb-4'>
                <Form.Group as={Col}>
                    <Form.Label>Подтвердите пароль</Form.Label>
                    <Form.Control type='password' placeholder='Подтверждение пароля' onChange={onPasswordConfirmChange} value={passwordConfirm} />
                </Form.Group>
            </Row>
            <Row className='mb-4'>
                <Col>
                    <Button type='submit' className='btn btn-secondary'>Зарегистрироваться</Button>
                </Col>
            </Row>
        </Form>
    );
}

module.exports = RegisterForm;