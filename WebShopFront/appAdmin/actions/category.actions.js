const adminConstants = require('../constants/admin.constants');

const newCategoryRequest = (categories, failed, error) => {
    return {
        type: adminConstants.NEW_CATEGORY_REQUEST,
        payload: {
            categories,
            failed,
            error,
        }
    };
};

const newCategorySuccess = (categories, failed, error) => {
    return {
        type: adminConstants.NEW_CATEGORY_SUCCESS,
        payload: {
            categories,
            failed,
            error,
        }
    }
};

const newCategoryFailure = (categories, failed, error) => {
    return {
        type: adminConstants.NEW_CATEGORY_FAILURE,
        payload: {
            categories,
            failed,
            error,
        }
    }
};

const categoryListRequest = (categories, failed, error) => {
    return {
        type: adminConstants.CATEGORY_LIST_REQUEST,
        payload: {
            categories,
            failed,
            error,
        }
    }
};

const categoryListSuccess = (categories, failed, error) => {
    return {
        type: adminConstants.CATEGORY_LIST_SUCCESS,
        payload: {
            categories,
            failed,
            error,
        }
    };
};

const categoryListFailure = (categories, failed, error) => {
    return {
        type: adminConstants.CATEGORY_LIST_FAILURE,
        payload: {
            categories,
            failed,
            error,
        }
    };
};

module.exports = {newCategoryRequest, newCategorySuccess, newCategoryFailure, categoryListRequest, categoryListSuccess, categoryListFailure};