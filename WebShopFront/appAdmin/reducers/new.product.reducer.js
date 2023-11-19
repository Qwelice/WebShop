const adminConstants = require("../constants/admin.constants");

let initState = {
  requested: false,
  succeed: false,
  failed: false,
  error: "",
};

function newProduct(state = initState, action) {
  switch (action.type) {
    case adminConstants.PRODUCT_CREATION_REQUEST:
      return {
        ...state,
        ...action.payload,
      };
    case adminConstants.PRODUCT_CREATION_SUCCESS:
      return {
        ...state,
        ...action.payload,
      };
    case adminConstants.PRODUCT_CREATION_FAILURE:
      return {
        ...state,
        ...action.payload,
      };
    default:
      return state;
  }
}

module.exports = newProduct;
