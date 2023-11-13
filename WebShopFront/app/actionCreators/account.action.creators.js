const accountActions = require("../actions/account.actions");
const accountService = require('../services/account.service');

function register(email, password) {
  return (dispatch) => {
    dispatch(accountActions.registerRequest(true, false, false, ""));
    accountService.register(email, password).then(
      (response) => {
        const authenticated = response.authenticated;
        if (authenticated && authenticated == true) {
          localStorage.setItem("authenticated", "yes");
          dispatch(accountActions.registerSuccess(false, true, false, ""));
        } else {
          localStorage.setItem('authenticated', 'no');
          dispatch(
            accountActions.registerFailure(
              false,
              false,
              true,
              response
            )
          );
        }
      },
      (error) => {
        dispatch(accountActions.registerFailure(false, false, true, error));
      }
    );
  };
}

function login(email, password) {
  return (dispatch) => {
    dispatch(accountActions.loginRequest(true, false, false, ""));
    accountService.login(email, password).then(
      (response) => {
        const authenticated = response.authenticated;
        if (authenticated && authenticated == true) {
          localStorage.setItem("authenticated", "yes");
          dispatch(accountActions.registerSuccess(false, true, false, ""));
        } else {
          localStorage.setItem('authenticated', 'no');
          dispatch(
            accountActions.registerFailure(
              false,
              false,
              true,
              response
            )
          );
        }
      },
      (error) => {
        dispatch(accountActions.loginFailure(false, false, true, error));
      }
    );
  };
}

function logout() {
  return (dispatch) => {
    localStorage.removeItem("authenticated");
    dispatch(accountActions.logout(false, false, false, ""));
  };
}

function tryLogin() {
  return (dispatch) => {
    const authenticated = localStorage.getItem("authenticated");
    if (authenticated && authenticated == "yes") {
      dispatch(accountActions.loginSuccess(false, true, false, ""));
    } else {
      dispatch(accountActions.loginFailure(false, false, false, ""));
    }
  };
}

module.exports = { register, login, logout, tryLogin };
