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

module.exports = {newCategory};