const userConstants = require('../constants/user.constants');

let initState = {
    list: [],
    pageCount: -1,
    currentPage: -1,
    requested: false,
    succeed: false,
    failed: false,
    error: ''
};

function products(state=initState, action){
    switch(action.type){
        case userConstants.PRODUCT_LIST_REQUEST:
            return {
                ...state,
                requested: action.payload.requested
            }
        case userConstants.PRODUCT_LIST_SUCCESS:
            return {
                ...state,
                ...action.payload
            }
        case userConstants.PRODUCT_LIST_FAILURE:
            return {
                ...state,
                ...action.payload
            }
        default:
            return state;
    }
}

module.exports = products;