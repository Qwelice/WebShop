const accountActions = require("../actions/account.actions");
const accountService = require("../services/account.service");

function register(email, password) {
  return (dispatch) => {
    dispatch(accountActions.registerRequest(true, false, false, ""));
    accountService.register(email, password).then(
      (response) => {
        const token = response.token;
        if (token) {
          localStorage.setItem("token", token);
          dispatch(accountActions.registerSuccess(false, true, false, ""));
        } else {
          dispatch(
            accountActions.registerFailure(
              false,
              false,
              true,
              "сервер не выдал токен"
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
        const token = response.token;
        if (token) {
          localStorage.setItem("token", token);
          dispatch(accountActions.loginSuccess(false, true, false, ""));
        } else {
          dispatch(
            accountActions.loginFailure(
              false,
              false,
              true,
              "сервер не выдал токен"
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
    localStorage.removeItem("token");
    dispatch(accountActions.logout(false, false, false, ""));
  };
}

function tryLogin() {
  return (dispatch) => {
    const token = localStorage.getItem('token');
    if(token){
        dispatch(accountActions.loginSuccess(false, true, false, ""));
    }else{
        dispatch(accountActions.loginFailure(false, false, false, ""));
    }
  };
}
