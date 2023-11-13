const React = require('react');
const { useState, useEffect } = require('react');
const { Form, Row, Col, Button } = require('react-bootstrap');
const NavPanel = require('../shared/nav.panel.jsx');
const { useNavigate } = require('react-router');
const { useSelector } = require('react-redux');

function NewCategoryPage(props) {
    const navigate = useNavigate();

    const adminAccount = useSelector((state) => state.adminAccount);

    const [validated, setValid] = useState(false);

    useEffect(()=>{
        if(!adminAccount.logged){
            navigate('/');
        }
    },
    []);

    const handleSubmit = (e) => {
        e.preventDefault();
    }

    return (
        <div className="new-category">
            <div className="new-category__body">
                <NavPanel />
                <div className="new-category__header">
                    Добавление новой категории
                </div>
                <div className="form-container">
                    <Form noValidate validated={validated} onSubmit={handleSubmit}>
                        <div className='form-container__body'>
                            <Row>
                                <div className="error__text text-danger"></div>
                            </Row>
                            <Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Название категории</Form.Label>
                                    <Form.Control type='text' className='mb-3' required />
                                    <Button type='submit' className='btn login-button'>Зарегистрировать</Button>
                                </Form.Group>
                            </Row>
                        </div>
                    </Form>
                </div>
            </div>
        </div>
    );
}

module.exports = NewCategoryPage;