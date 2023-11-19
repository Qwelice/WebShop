const {fulfilledHandler, rejectedHandler} = require('../../app/helpers/response.handler');
const API = require('../helpers/api.config');

function newCategory(categoryName){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            categoryName
        })
    };

    return fetch(API.BASE_URL + API.ADMIN_NEW_CATEGORY_ENDP, requestOptions).then(fulfilledHandler, rejectedHandler);
}

function getCategories(){
    const requestOptions = {
        method: 'POST'
    };

    return fetch(API.BASE_URL + API.ADMIN_GET_CATEGORIES_ENDP, requestOptions).then(fulfilledHandler, rejectedHandler);
}

function productCreation(formData){
    const requestOptions = {
        method: 'POST',
        body: formData
    }

    return fetch(API.BASE_URL + API.ADMIN_PRODUCT_CREATION_ENDP, requestOptions).then(fulfilledHandler, rejectedHandler);
}

function productsRequest(){
    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' }
    }

    return fetch(API.BASE_URL + API.ADMIN_PRODUCT_LIST_ENDP, requestOptions).then(fulfilledHandler, rejectedHandler);
}

function productsRequestByQuery(query){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    }

    return fetch(API.BASE_URL + API.ADMIN_PRODUCT_LIST_ENDP + `/${query}`, requestOptions).then(fulfilledHandler, rejectedHandler);
}

module.exports = {newCategory, getCategories, productCreation, productsRequest, productsRequestByQuery};