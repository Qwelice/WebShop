const React = require('react');
const { useState, useEffect } = require('react');
const { Card, Form, Col, Row, Button, ListGroup } = require('react-bootstrap');
const NavPanel = require('../shared/nav.panel.jsx');
const { useDispatch, useSelector } = require('react-redux');

const adminActionCreators = require('../../actionCreators/admin.action.creators');

function NewProductPage(props) {

    const dispatch = useDispatch();
    const category = useSelector((state) => state.category);

    const [validated, setValid] = useState(false);
    const [name, setName] = useState('');
    const [price, setPrice] = useState('');
    const [selectedCategory, setSelectedCategory] = useState([]);
    const [description, setDescription] = useState('');
    const [photo, setPhoto] = useState(null);

    useEffect(() => {
        dispatch(adminActionCreators.requestCategories());
    }, []);

    const onNameChange = (e) => {
        var val = e.target.value;
        setName(val);
    }

    const onPriceChange = (e) => {
        var val = e.target.value;
        setPrice(val);
    }

    const onCategoryClick = (item) => {
        const isSelected = selectedCategory.includes(item);
        if (isSelected) {
            setSelectedCategory(selectedCategory.filter(selected => selected != item));
        } else {
            setSelectedCategory([...selectedCategory, item]);
        }
    }

    const onDescriptionChange = (e) => {
        var val = e.target.value;
        setDescription(val);
    }

    const onPhotoChange = (e) => {
        const file = e.target.files[0];
        setPhoto(file);
    }

    const validatePrice = () => {
        var val = parseInt(price);
        if(val){
            return true;
        }else{
            return false;
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        setValid(true);

        if(!validatePrice()){
            return;
        }

        const formData = new FormData();
        formData.append('name', name);
        formData.append('description', description);
        formData.append('price', parseInt(price));
        formData.append('photo', photo);

        selectedCategory.forEach((item, index) => {
            formData.append(`categories[${index}].id`, item.id);
            formData.append(`categories[${index}].name`, item.name);
        });

        dispatch(adminActionCreators.productCreation(formData));

    };

    const categorySelect = () => {
        return (
            <ListGroup className='mb-4' style={{ maxHeight: '8rem', overflowY: 'auto' }}>
                {category.categories.map((item, index) =>
                    <ListGroup.Item key={item.id} type='button' action active={selectedCategory.includes(item)} onClick={() => onCategoryClick(item)}>
                        {item.name}
                    </ListGroup.Item>)}
            </ListGroup>
        );
    };

    return (
        <div className="product">
            <div className='product__body'>
                <NavPanel />
                <div className="product-preview">
                    <div className="product-header">
                        Добавление нового товара
                    </div>
                    <Card>

                    </Card>
                </div>
                <div className="product-form">
                    <div className="product-header mb-3" style={{textAlign: 'start'}}>
                        Форма регистрации товара
                    </div>
                    <Form noValidate validated={validated} onSubmit={handleSubmit}>
                        <div className='product-form__container'>
                            <Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Название товара</Form.Label>
                                    <Form.Control className='mb-3' type='text' value={name} onChange={onNameChange} required />
                                    <Form.Label>Цена товара</Form.Label>
                                    <Form.Control className='mb-3' type='text' value={price} onChange={onPriceChange} required />
                                    <Form.Label>Категории товара</Form.Label>
                                    {categorySelect()}
                                    <Button type='submit' className='btn login-button mb-3'>Зарегистрировать</Button>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>Описание товара</Form.Label>
                                    <Form.Control as='textarea' rows={5} onChange={onDescriptionChange} value={description} required/>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>Фото товара</Form.Label>
                                    <Form.Control type='file' onChange={onPhotoChange} required />
                                </Form.Group>
                            </Row>
                        </div>
                    </Form>
                </div>
            </div>
        </div>
    );
}

module.exports = NewProductPage;