const adminAccountReducer = require('./admin.account.reducer');
const categoryReducer = require('./category.reducer');

const rootReducer = {
    reducer: {
        adminAccount: adminAccountReducer,
        category: categoryReducer
    }
}

module.exports = rootReducer;