const userConstants = require('../constants/user.constants');

let initState = {
    products: []
}

function cart(state=initState, action){
    switch(action.type){
        case userConstants.CART_APPEND:
            return {
                ...state,
                ...action.payload
            }
        case userConstants.CART_REMOVE:
            return {
                ...state,
                ...action.payload
            }
        
        default:
            return state;
    }
}

module.exports = cart;