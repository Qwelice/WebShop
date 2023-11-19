const adminConstants = require("../constants/admin.constants");

let initState = {
  products: [],
  requested: false,
  succeed: false,
  failed: false,
  error: "",
};

function products(state = initState, action) {
  switch (action.type) {
    case adminConstants.PRODUCT_LIST_REQUEST:
      return {
        ...state,
        ...action.payload,
        products: [...action.payload.products],
      };
    case adminConstants.PRODUCT_LIST_SUCCESS:
      return {
        ...state,
        ...action.payload,
        products: [...action.payload.products],
      };
    case adminConstants.PRODUCT_LIST_FAILURE:
      return {
        ...state,
        ...action.payload,
        products: [...action.payload.products],
      };
    case adminConstants.PRODUCT_LIST_QUERY_REQUEST:
      return {
        ...state,
        ...action.payload,
        products: [...action.payload.products],
      };
    case adminConstants.PRODUCT_LIST_QUERY_SUCCESS:
      return {
        ...state,
        ...action.payload,
        products: [...action.payload.products],
      };
    case adminConstants.PRODUCT_LIST_QUERY_FAILURE:
      return {
        ...state,
        ...action.payload,
        products: [...action.payload.products],
      };

    default:
      return state;
  }
}

module.exports = products;
