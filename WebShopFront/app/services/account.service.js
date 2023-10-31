const config = require('../helpers/config');
const {fulfilledHandler, rejectedHandler} = require('../helpers/response.handler');

/**
 * @returns {Promise<{ token: string } | string>} в случае успеха возвращает объект с токеном, в случае провала строку ошибки 
 */
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

/**
 * @returns {Promise<{ token: string } | string>} в случае успеха возвращает объект с токеном, в случае провала строку ошибки
 */
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