const accountState = require('../states/account.state');

let initState = accountState();

function account(state=initState, action){
    switch(action.type){
        default:
            return state;
    }
}