const React = require('react');
const { useState, useEffect } = require('react');
const { Form, Button, ListGroup } = require('react-bootstrap');
const { useDispatch, useSelector } = require('react-redux');

function OrderPage(props) {
    const dispatch = useDispatch();
    const account = useSelector((state) => state.account);
    const cart = useSelector((state) => state.cart);

    const contactForm = () => {
        if (!account.logged) {
            return (
                <Form.Control type='email' placeholder='e-mail' required />
            );
        }
    }

    return (
        <div className="orders">
            <div className="orders__body">
                <div className="orders__header">
                    Оформление заказа
                </div>
                <Form noValidate>
                    {contactForm()}
                    <Button type='submit' variant='secondary'>Оформить заказ</Button>
                </Form>
                <div className="orders-summary">
                    <div className="orders-summary__title">Список товаров</div>
                    <ListGroup>
                        {cart.products.map((item, index) => {
                            return <ListGroup.Item className='d-flex flex-row'>
                                <div className="me-2">{item.product.name}</div>
                                <div className="me-2">{item.product.price}</div>
                                <div className="me-2">{item.count}</div>
                            </ListGroup.Item>
                        })}
                    </ListGroup>
                </div>
            </div>
        </div>
    );
}

module.exports = OrderPage;