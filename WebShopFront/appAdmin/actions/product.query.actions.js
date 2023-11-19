const adminConstants = require('../constants/admin.constants');

const productQueryRequest = (results, succeed, failed, error) => {
    return {
        type: adminConstants.PRODUCT_QUERY_REQUEST,
        payload: {
            
        }
    }
}