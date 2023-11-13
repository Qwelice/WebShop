const API = require('../helpers/apiConfig');
const {fulfilledHandler, rejectedHandler} = require('../helpers/response.handler');

/**
 * @returns {Promise<{ authenticated: boolean } | string>} в случае успеха возвращает объект с токеном, в случае провала строку ошибки 
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

    return fetch(API.BASE_URL + API.AUTH_REGISTER_ENDP, requestOptions).then(fulfilledHandler, rejectedHandler);
}

/**
 * @returns {Promise<{ authenticated: boolean } | string>} в случае успеха возвращает объект с токеном, в случае провала строку ошибки
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

    return fetch(API.BASE_URL + API.AUTH_LOGIN_ENDP, requestOptions).then(fulfilledHandler, rejectedHandler);
}

function logout(){
    const requestOptions = {
        method: 'GET'
    }

    fetch(API.BASE_URL + API.AUTH_LOGOUT_ENDP, requestOptions);
}

module.exports = {register, login, logout};