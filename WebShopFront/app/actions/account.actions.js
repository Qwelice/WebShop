const accountConstants = require('../helpers/constants/account.constants');

function registerRequest(user){
    return { type: accountConstants.REGISTER_REQUEST, user };
}

function registerSuccess(){
    return { type: accountConstants.REGISTER_SUCCESS }
}