const adminAccountConstants = require("../constants/admin.account.constants");

const loginRequest = (requested, logged, failed, error, email) => {
  return {
    type: adminAccountConstants.LOGIN_REQUEST,
    payload: {
      requested,
      logged,
      failed,
      error,
      email,
    },
  };
};

const loginSuccess = (requested, logged, failed, error, email) => {
  return {
    type: adminAccountConstants.LOGIN_SUCCESS,
    payload: {
      requested,
      logged,
      failed,
      error,
      email,
    },
  };
};

const loginFailure = (requested, logged, failed, error, email) => {
    return {
        type: adminAccountConstants.LOGIN_FAILURE,
        payload: {
            requested,
            logged,
            failed, 
            error,
            email,
        }
    }
}

const logout = (requested, logged, failed, error, email) => {
  return {
    type: adminAccountConstants.LOGOUT,
    payload: {
      requested,
      logged,
      failed,
      error,
      email,
    }
  }
}

module.exports = {loginRequest, loginSuccess, loginFailure, logout};