const React = require('react');
const { useState, useEffect } = require('react');
const { Form, Row, Col, Button } = require('react-bootstrap');
const { useSelector, useDispatch } = require('react-redux');
const { useNavigate } = require('react-router');

const adminAccountActionCreators = require('../../actionCreators/admin.account.action.creators');

function LoginPage(props) {
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const admin = useSelector((state) => state.adminAccount);

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [validated, setValid] = useState(false);

    useEffect(()=>{
        if(admin.logged){
            navigate('/');
        }
    }, [admin.logged]);

    const onEmailChange = (e) => {
        var val = e.target.value;
        setEmail(val);
    }

    const onPasswordChange = (e) => {
        var val = e.target.value;
        setPassword(val);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        dispatch(adminAccountActionCreators.login(email, password));
    }

    return (
        <div className='form-container'>
            <Form noValidate validated={validated} onSubmit={handleSubmit}>
                <div className='form-container__body'>
                    <Row>
                        <div className="error__text text-danger">{admin.error}</div>
                    </Row>
                    <Row md={'8'} className='mb-5'>
                        <Col className='text-center'>
                            <h3>Вход в систему</h3>
                        </Col>
                    </Row>
                    <Row md={'8'} className='mb-3'>
                        <Form.Group as={Col}>
                            <Form.Label>E-mail</Form.Label>
                            <Form.Control type='email' value={email} onChange={onEmailChange} required />
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