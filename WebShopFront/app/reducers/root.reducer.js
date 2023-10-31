const accountReducer = require('./account.reducer');

const rootReducer = {
    reducer: {
        account: accountReducer
    }
};

module.exports = rootReducer;