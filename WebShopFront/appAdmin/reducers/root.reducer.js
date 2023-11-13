const adminAccountReducer = require('./admin.account.reducer');

const rootReducer = {
    reducer: {
        adminAccount: adminAccountReducer
    }
}

module.exports = rootReducer;