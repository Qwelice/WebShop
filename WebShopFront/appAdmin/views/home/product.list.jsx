const React = require('react');
const { useState, useEffect } = require('react');

const adminActionCreators = require('../../actionCreators/admin.action.creators');
const { useDispatch, useSelector } = require('react-redux');
const { Card, Form, Button } = require('react-bootstrap');
const NavPanel = require('../shared/nav.panel.jsx');

function ProductList(props) {
    const dispatch = useDispatch();
    const prodsState = useSelector((state) => state.products);

    const [query, setQuery] = useState('');
    const [queryCache, setQueryCache] = useState([]);
    const [productCache, setProductCache] = useState([]);
    const [typingTimeout, setTypingTimeout] = useState(0);

    useEffect(() => {
        dispatch(adminActionCreators.requestProductList());
    }, []);

    const getUri = (photoData) => {
        return `data:image/jpeg;base64,${photoData}`;
    }

    const onSearchChange = (e) => {
        var val = e.target.value;
        setQuery(val);

        clearTimeout(typingTimeout);

        const timeoutId = setTimeout(() => {
            if (val.length > 0) {
                dispatch(adminActionCreators.requestProductListByQuery(val));
            }
        }, 1000);

        setTypingTimeout(timeoutId);
    }

    const handleSearchSubmit = (e) => {
        e.preventDefault();
        if (query.length > 0) {
            dispatch(adminActionCreators.requestProductListByQuery(query));
        }
    }

    return (
        <div className="products">
            <NavPanel />
            <div className="products__search">
                <Form noValidate onSubmit={handleSearchSubmit}>
                    <div className="search__body d-flex flex-row mt-3 mb-4">
                        <Form.Control className='me-2' type='search' value={query} onChange={onSearchChange} />
                        <Button type='submit' variant='outline-success'><i className="bi bi-search"></i></Button>
                    </div>
                </Form>
            </div>
            <div className='products__page'>
                {prodsState.products.map((item, index) =>
                    <Card className='m-2' key={'product-card-' + index} style={{ width: '18rem' }}>
                        <Card.Header style={{ textAlign: 'center' }}>
                            <Card.Title>{item.name}</Card.Title>
                        </Card.Header>
                        <Card.Img variant='top' src={getUri(item.photoData)} />
                        <Card.Body>
                            <Card.Title style={{ fontSize: '1rem' }}>{item.price}&#8381;</Card.Title>
                            <Card.Text>{item.description}</Card.Text>
                        </Card.Body>
                    </Card>)}
            </div>
        </div>
    );
}

module.exports = ProductList;