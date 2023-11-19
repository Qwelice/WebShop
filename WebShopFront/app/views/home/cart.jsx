const React = require('react')
const { useState, useEffect } = require('react');
const { ListGroup, Button, Card, Row, Col } = require('react-bootstrap');
const { useDispatch, useSelector } = require('react-redux');

const shopActionCreators = require('../../actionCreators/shop.action.creators');
const getUri = require('../../helpers/photo.uri');
const { useNavigate } = require('react-router');

function Cart(props) {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const cart = useSelector((state) => state.cart);

    if (cart.products.length <= 0) {
        return <div className="empty-cart">
            Ваша корзина пока пуста
        </div>
    }

    const onCartAppendClick = (product) => {
        dispatch(shopActionCreators.appendToCart(product, cart.products));
    }

    const onCartRemoveClick = (product) => {
        dispatch(shopActionCreators.removeFromCart(product, cart.products));
    }

    return (
        <div className="cart">
            <div className="cart__body">
                <ListGroup>
                    {cart.products.map((item, index) => {
                        return <ListGroup.Item key={'cart-product-' + index}>
                            <div className="cart__item">
                                <div className="cart__item-name">{item.product.name}</div>
                                <Button type='button' variant='secondary' onClick={() => onCartAppendClick(item.product)} size='sm' style={{ fontSize: '1rem' }}><i className="bi bi-plus-square"></i></Button>
                                <div className="cart__item-count">{item.count}</div>
                                <Button type='button' variant='secondary' onClick={() => onCartRemoveClick(item.product)} size='sm' style={{ fontSize: '1rem' }}><i className="bi bi-dash-square"></i></Button>
                            </div>
                        </ListGroup.Item>
                    })}
                </ListGroup>
                <Button className='mt-3 justify-self-center' type='button'>Оформление заказа</Button>
            </div>
        </div>
    );
}

module.exports = Cart;