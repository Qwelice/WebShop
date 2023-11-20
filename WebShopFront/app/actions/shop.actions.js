const userConstants = require("../constants/user.constants");

const productListRequest = (
  list,
  pageCount,
  currentPage,
  requested,
  succeed,
  failed,
  error
) => {
  return {
    type: userConstants.PRODUCT_LIST_REQUEST,
    payload: {
      list,
      pageCount,
      currentPage,
      requested,
      succeed,
      failed,
      error,
    },
  };
};

const productListSuccess = (
  list,
  pageCount,
  currentPage,
  requested,
  succeed,
  failed,
  error
) => {
  return {
    type: userConstants.PRODUCT_LIST_SUCCESS,
    payload: {
      list,
      pageCount,
      currentPage,
      requested,
      succeed,
      failed,
      error,
    },
  };
};

const productListFailure = (
  list,
  pageCount,
  currentPage,
  requested,
  succeed,
  failed,
  error
) => {
  return {
    type: userConstants.PRODUCT_LIST_FAILURE,
    payload: {
      list,
      pageCount,
      currentPage,
      requested,
      succeed,
      failed,
      error,
    },
  };
};

const cartAppend = (products) => {
    return {
        type: userConstants.CART_APPEND,
        payload: {
            products,
        }
    };
}

const cartRemove = (products) => {
    return {
        type: userConstants.CART_REMOVE,
        payload: {
            products,
        }
    };
}

const cartNewOrder = (products) => {
  return {
    type: userConstants.CART_NEW_ORDER,
    payload: {
      products,
    }
  }
}

module.exports = { productListRequest, productListSuccess, productListFailure, cartAppend, cartRemove, cartNewOrder };
