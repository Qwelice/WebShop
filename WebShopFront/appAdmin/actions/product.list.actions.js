const adminConstants = require("../constants/admin.constants");

const productsRequest = (products, requested, succeed, failed, error) => {
  return {
    type: adminConstants.PRODUCT_LIST_REQUEST,
    payload: {
      products,
      requested,
      failed,
      error,
      succeed,
    },
  };
};

const productsSuccess = (products, requested, succeed, failed, error) => {
  return {
    type: adminConstants.PRODUCT_LIST_SUCCESS,
    payload: {
      products,
      requested,
      failed,
      error,
      succeed,
    },
  };
};

const productsFailure = (products, requested, succeed, failed, error) => {
  return {
    type: adminConstants.PRODUCT_LIST_FAILURE,
    payload: {
      products,
      requested,
      failed,
      error,
      succeed,
    },
  };
};

module.exports = { productsRequest, productsSuccess, productsFailure };
