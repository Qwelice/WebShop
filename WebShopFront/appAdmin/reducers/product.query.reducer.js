const adminConstants = require('../constants/admin.constants');

let initState = {
    results: [],
    requested: false,
    succeed: false,
    failed: false,
    error: ''
}

function query(state=initState, action){
    switch(action.type){
        default:
            return state;
    }
}

module.exports = query;