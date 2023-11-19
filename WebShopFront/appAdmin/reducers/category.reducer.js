const adminConstants = require('../constants/admin.constants');

let initState = {
    categories: [],
    failed: false,
    error: ""
};

function category(state=initState, action){
    switch(action.type){
        case adminConstants.NEW_CATEGORY_REQUEST:
            return {
                ...state,
                ...action.payload,
                categories: [...action.payload.categories],
            };
        case adminConstants.NEW_CATEGORY_FAILURE:
            return {
                ...state,
                ...action.payload,
                categories: [...action.payload.categories],
            };
        case adminConstants.NEW_CATEGORY_SUCCESS:
            return {
                ...state,
                ...action.payload,
                categories: [...action.payload.categories],
            };
        case adminConstants.CATEGORY_LIST_REQUEST:
            return {
                ...state,
                ...action.payload,
                categories: [...action.payload.categories],
            };
        case adminConstants.CATEGORY_LIST_SUCCESS:
            return {
                ...state,
                ...action.payload,
                categories: [...action.payload.categories],
            };
        case adminConstants.CATEGORY_LIST_FAILURE:
            return {
                ...state,
                ...action.payload,
                categories: [...action.payload.categories],
            };
        default:
            return state;
    }
}

module.exports = category;