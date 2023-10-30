function accountState(requested=false, logged=false, fail=false, error=''){
    return {
        requested,
        logged,
        fail,
        error,
    }
}

module.exports = accountState;