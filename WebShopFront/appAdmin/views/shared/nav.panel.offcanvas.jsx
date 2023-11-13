const React = require('react');
const { useState, useEffect } = require('react')
const {Offcanvas, ListGroup} = require('react-bootstrap');
const { useNavigate } = require('react-router');

function NavPanelOffcanvas(props) {
    const navigate = useNavigate();

    const navList = {
        addNewProduct: () => navigate('/newProduct'),
        productList: () => navigate('/productList'),
        addNewCategory: () => navigate('/newCategory'),
    }

    return (
        <Offcanvas show={props.navPanelShow} onHide={props.handleNavPanelClose}>
            <Offcanvas.Header closeButton>
                <Offcanvas.Title>Панель навигации</Offcanvas.Title>
            </Offcanvas.Header>
            <Offcanvas.Body>
                <ListGroup>
                    <ListGroup.Item action onClick={navList.productList}>
                        Список товаров
                    </ListGroup.Item>
                    <ListGroup.Item action onClick={navList.addNewCategory}>
                        Добавить новую категорию
                    </ListGroup.Item>
                    <ListGroup.Item action onClick={navList.addNewProduct}>
                        Добавить новый товар
                    </ListGroup.Item>
                </ListGroup>
            </Offcanvas.Body>
        </Offcanvas>
    );
}

module.exports = NavPanelOffcanvas;