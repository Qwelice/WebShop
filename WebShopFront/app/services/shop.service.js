const API = require('../helpers/apiConfig');
const {fulfilledHandler, rejectedHandler} = require('../helpers/response.handler');

function getProducts(){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    }

    return fetch(API.BASE_URL + API.PRODUCT_LIST_ENDP, requestOptions).then(fulfilledHandler, rejectedHandler);
}

function getProductsByPage(page){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    }

    return fetch(API.BASE_URL + API.PRODUCT_LIST_ENDP + `/${page}`, requestOptions).then(fulfilledHandler, rejectedHandler);
}

function getProductsByQuery(query){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    }

    return fetch(API.BASE_URL + API.PRODUCT_LIST_ENDP + `/${query}`, requestOptions).then(fulfilledHandler, rejectedHandler);
}

function getProductsByQueryAndPage(query, page){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    }

    return fetch(API.BASE_URL + API.PRODUCT_LIST_ENDP + `/${query}/${page}`, requestOptions).then(fulfilledHandler, rejectedHandler);
}

module.exports = {getProducts, getProductsByPage, getProductsByQuery, getProductsByQueryAndPage};