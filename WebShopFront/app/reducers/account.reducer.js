const accountConstants = require("../constants/account.constants");

let initState = {
  requested: false,
  logged: false,
  failed: false,
  error: "",
};

function account(state = initState, action) {
  switch (action.type) {
    case accountConstants.REGISTER_REQUEST:
      return {
        ...state,
        ...action.payload,
      };
    case accountConstants.REGISTER_SUCCESS:
      return {
        ...state,
        ...action.payload,
      };
    case accountConstants.REGISTER_FAILURE:
      return {
        ...state,
        ...action.payload,
      };
    case accountConstants.LOGIN_REQUEST:
      return {
        ...state,
        ...action.payload,
      };
    case accountConstants.LOGIN_SUCCESS:
      return {
        ...state,
        ...action.payload,
      };
    case accountConstants.LOGIN_FAILURE:
      return {
        ...state,
        ...action.payload,
      };
    default:
      return state;
  }
}

module.exports = account;