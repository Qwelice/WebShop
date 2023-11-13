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
                categories: [...state.categories, action.payload.categories],
                ...state,
                ...action.payload
            };
        case adminConstants.NEW_CATEGORY_FAILURE:
            return {
                categories: [...state.categories, action.payload.categories],
                ...state,
                ...action.payload
            };
        case adminConstants.NEW_CATEGORY_SUCCESS:
            return {
                categories: [...state.categories, action.payload.categories],
                ...state,
                ...action.payload
            };
        case adminConstants.CATEGORY_LIST_REQUEST:
            return {
                categories: [...state.categories, action.payload.categories],
                ...state,
                ...action.payload
            };
        case adminConstants.CATEGORY_LIST_SUCCESS:
            return {
                categories: [...state.categories, action.payload.categories],
                ...state,
                ...action.payload
            };
        case adminConstants.CATEGORY_LIST_FAILURE:
            return {
                categories: [...state.categories, action.payload.categories],
                ...state,
                ...action.payload
            };
        default:
            return state;
    }
}

module.exports = category;