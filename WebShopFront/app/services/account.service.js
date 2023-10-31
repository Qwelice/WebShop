const config = require('../helpers/config');
const {fulfilledHandler, rejectedHandler} = require('../helpers/response.handler');

function register(email, password){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            email,
            password
        })
    };

    return fetch(config.apiUrl() + '/api/users/registration', requestOptions).then(fulfilledHandler, rejectedHandler);
}

function login(email, password){
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            email,
            password
        })
    };

    return fetch(config.apiUrl() + '/api/users/auth', requestOptions).then(fulfilledHandler, rejectedHandler);
}

module.exports = {register, login};