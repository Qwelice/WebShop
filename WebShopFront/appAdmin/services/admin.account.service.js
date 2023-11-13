const {fulfilledHandler, rejectedHandler} = require('../../app/helpers/response.handler');
const API = require('../helpers/api.config');

function login(email, password){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            email: email,
            password: password
        })
    };

    return fetch(API.BASE_URL + API.AUTH_LOGIN_ENDP, requestOptions).then(fulfilledHandler, rejectedHandler);
}

module.exports = {login};