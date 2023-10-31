const accountConstants = require("../constants/account.constants");

const registerRequest = (requested, logged, failed, error) => {
  return {
    type: accountConstants.REGISTER_REQUEST,
    payload: {
      requested,
      logged,
      failed,
      error,
    },
  };
};

const registerSuccess = (requested, logged, failed, error) => {
  return {
    type: accountConstants.REGISTER_SUCCESS,
    payload: {
      requested,
      logged,
      failed,
      error,
    },
  };
};

const registerFailure = (requested, logged, failed, error) => {
  return {
    type: accountConstants.REGISTER_FAILURE,
    payload: {
      requested,
      logged,
      failed,
      error,
    },
  };
};

const loginRequest = (requested, logged, failed, error) => {
  return {
    type: accountConstants.LOGIN_REQUEST,
    payload: {
      requested,
      logged,
      failed,
      error,
    },
  };
};

const loginSuccess = (requested, logged, failed, error) => {
  return {
    type: accountConstants.LOGIN_SUCCESS,
    payload: {
      requested,
      logged,
      failed,
      error,
    },
  };
};

const loginFailure = (requested, logged, failed, error) => {
  return {
    type: accountConstants.LOGIN_FAILURE,
    payload: {
      requested,
      logged,
      failed,
      error,
    },
  };
};

const logout = (requested, logged, failed, error) => {
  return {
    type: accountConstants.LOGOUT,
    payload: {
      requested,
      logged,
      failed,
      error,
    },
  };
};

module.exports = {
  registerRequest,
  registerSuccess,
  registerFailure,
  loginRequest,
  loginFailure,
  loginSuccess,
  logout,
};
