const React = require('react');
const {useState, useEffect} = require('react');
const { Card, Form } = require('react-bootstrap');
const NavPanel = require('../shared/nav.panel.jsx');

function NewProductPage(props){

    return (
        <div className="new-product">
            <div className='new-product__body'>
                <NavPanel />
                <div className="new-product__preview">
                    <div className="new-product__header">
                        Добавление нового товара
                    </div>
                    <Card>
    
                    </Card>
                </div>
                <div className="new-product__form">
                    <div className="new-product__header">
    
                    </div>
                    <Form noValidate>
    
                    </Form>
                </div>
            </div>
        </div>
    );
}

module.exports = NewProductPage;