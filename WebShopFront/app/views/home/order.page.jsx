const React = require('react');
const { useState, useEffect } = require('react');
const { Form, Button, ListGroup } = require('react-bootstrap');
const { useDispatch, useSelector } = require('react-redux');

const shopActionCreators = require('../../actionCreators/shop.action.creators');
const { useNavigate } = require('react-router');

function OrderPage(props) {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const account = useSelector((state) => state.account);
    const cart = useSelector((state) => state.cart);

    const [email, setEmail] = useState('');

    useEffect(() => {
        const data = localStorage.getItem('email');
        if(data){
            setEmail(data);
        }
    }, [])

    const contactForm = () => {
        if (!account.logged) {
            return (
                <Form.Control type='email' placeholder='e-mail' required />
            );
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        dispatch(shopActionCreators.cartNewOrder(email, cart.products));
        navigate('/catalog');
    }

    return (
        <div className="orders">
            <div className="orders__body">
                <div className="orders__header">
                    Оформление заказа
                </div>
                <Form noValidate onSubmit={handleSubmit}>
                    {contactForm()}
                    <Button type='submit' variant='secondary'>Оформить заказ</Button>
                </Form>
                <div className="orders-summary">
                    <div className="orders-summary__title">Список товаров</div>
                    <ListGroup>
                        {cart.products.map((item, index) => {
                            return <ListGroup.Item key={'order-product-' + index} className='d-flex flex-row'>
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