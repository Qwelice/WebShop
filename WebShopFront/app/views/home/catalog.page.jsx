const React = require('react');
const { useState, useEffect } = require('react');
const { useDispatch, useSelector } = require('react-redux');

const shopActionCreators = require('../../actionCreators/shop.action.creators');
const { Pagination, Card, Form, Button } = require('react-bootstrap');

function CatalogPage(props) {
    const dispatch = useDispatch();
    const prods = useSelector((state) => state.products);
    const cart = useSelector((state) => state.cart);

    const [query, setQuery] = useState('');
    const [typingTimeout, setTypingTimeout] = useState(0);

    useEffect(() => {
        dispatch(shopActionCreators.getProducts());
    }, [])

    const pagination = () => {
        const pageCount = prods.pageCount;
        const currentPage = prods.currentPage;

        const items = [];

        const onPageClick = (index) => {
            if (query.length > 0) {
                dispatch(shopActionCreators.getProductsByQueryAndPage(query, index));
            } else {
                dispatch(shopActionCreators.getProductsByPage(index));
            }
        }

        for (let index = 1; index <= pageCount; index++) {
            items.push(<Pagination.Item key={'pagination-' + index} active={index == currentPage} onClick={() => onPageClick(index)}>{index}</Pagination.Item>)
        }

        return (
            <Pagination>
                {items}
            </Pagination>
        );
    }

    const getUri = (photoData) => {
        return `data:image/jpeg;base64,${photoData}`;
    }

    const onSearchChange = (e) => {
        var val = e.target.value;
        setQuery(val);

        clearTimeout(typingTimeout);

        const timeoutId = setTimeout(() => {
            if (val.length > 0) {
                dispatch(shopActionCreators.getProductsByQuery(val));
            } else {
                dispatch(shopActionCreators.getProducts());
            }
        }, 1000);

        setTypingTimeout(timeoutId);
    }

    const handleBuyClick = (item) => {
        dispatch(shopActionCreators.appendToCart(item, cart.products));
    }

    const handleSearchSubmit = (e) => {
        e.preventDefault();

        dispatch(shopActionCreators.getProductsByQuery(query));
    }

    return <div className="catalog">
        <div className="catalog__body">
            <div className="catalog__search">
                <Form noValidate onSubmit={handleSearchSubmit}>
                    <div className="search__body d-flex flex-row mt-3 mb-4">
                        <Form.Control className='me-2' type='search' value={query} onChange={onSearchChange} />
                        <Button type='submit' variant='outline-success'><i className="bi bi-search"></i></Button>
                    </div>
                </Form>
            </div>
            <div className="catalog__pagination">{pagination()}</div>
            <div className="catalog__products">
                {prods.list.map((item, index) =>
                    <Card className='m-4' key={'product-card-' + index} style={{ width: '18rem' }}>
                        <Card.Img variant='top' src={getUri(item.photoData)} />
                        <Card.Body>
                            <Card.Subtitle className='mb-2'>{item.categories[0].name}</Card.Subtitle>
                            <Card.Title>{item.name}</Card.Title>
                            <Card.Title>{item.price}&#8381;</Card.Title>
                            <Button type='button' variant='secondary' onClick={() => handleBuyClick(item)}>Купить</Button>
                        </Card.Body>
                    </Card>
                )}
            </div>
            <div className="catalog__pagination mt-2">{pagination()}</div>
        </div>
    </div>
}

module.exports = CatalogPage;