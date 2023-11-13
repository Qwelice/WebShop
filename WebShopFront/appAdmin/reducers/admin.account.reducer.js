const adminConstants = require("../constants/admin.account.constants");

let initState = {
  requested: false,
  logged: false,
  failed: false,
  error: "",
  email: ""
};

function adminAccount(state = initState, action) {
    switch(action.type){
        case adminConstants.LOGIN_REQUEST:
            return {
                ...state,
                ...action.payload
            };
        case adminConstants.LOGIN_SUCCESS:
            return {
                ...state,
                ...action.payload
            };
        case adminConstants.LOGIN_FAILURE:
            return {
                ...state,
                ...action.payload
            }
        default:
            return state;
    }
}

module.exports = adminAccount;
