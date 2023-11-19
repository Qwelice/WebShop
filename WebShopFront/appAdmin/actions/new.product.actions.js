const adminConstants = require("../constants/admin.constants");

const newProductRequest = (requested, succeed, failed, error) => {
  return {
    type: adminConstants.PRODUCT_CREATION_REQUEST,
    payload: {
      requested,
      succeed,
      failed,
      error,
    },
  };
};

const newProducSuccess = (requested, succeed, failed, error) => {
  return {
    type: adminConstants.PRODUCT_CREATION_REQUEST,
    payload: {
      requested,
      succeed,
      failed,
      error,
    },
  };
};

const newProducFailure = (requested, succeed, failed, error) => {
  return {
    type: adminConstants.PRODUCT_CREATION_REQUEST,
    payload: {
      requested,
      succeed,
      failed,
      error,
    },
  };
};

module.exports = { newProductRequest, newProducSuccess, newProducFailure };
