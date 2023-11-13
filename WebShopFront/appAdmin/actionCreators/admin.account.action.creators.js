const adminAccountActions = require("../actions/admin.account.actions");
const adminAccountService = require("../services/admin.account.service");

function login(email, password) {
  return (dispatch) => {
    dispatch(adminAccountActions.loginRequest(true, false, false, "", ""));
    adminAccountService.login(email, password).then(
      (response) => {
        const authenticated = response.authenticated;
        if (authenticated && authenticated == true) {
          localStorage.setItem("authenticated", "yes");
          localStorage.setItem('email', email);
          const email = response.email;
          dispatch(
            adminAccountActions.loginSuccess(false, true, false, "", email)
          );
        } else {
          localStorage.setItem("authenticated", "no");
          dispatch(
            adminAccountActions.loginFailure(false, false, true, response, "")
          );
        }
      },
      (error) => {
        dispatch(
          adminAccountActions.loginFailure(false, false, true, error, "")
        );
      }
    );
  };
}

function logout() {
  return (dispatch) => {
    dispatch(adminAccountActions.logout(false, false, false, "", ""));
    localStorage.removeItem('authenticated');
  };
}

function tryLogin() {
  return (dispatch) => {
    const authenticated = localStorage.getItem("authenticated");
    const email = localStorage.getItem('email');
    if (authenticated && authenticated == "yes" && email) {
      dispatch(accountActions.loginSuccess(false, true, false, "", email));
    } else {
      dispatch(accountActions.loginFailure(false, false, false, "", ""));
    }
  };
}

module.exports = { login, logout, tryLogin };
