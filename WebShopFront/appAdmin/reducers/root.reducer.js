const adminAccountReducer = require('./admin.account.reducer');
const categoryReducer = require('./category.reducer');
const newProductReducer = require('./new.product.reducer');
const productListReducer = require('./product.list.reducer');

const rootReducer = {
    reducer: {
        adminAccount: adminAccountReducer,
        category: categoryReducer,
        newProduct: newProductReducer,
        products: productListReducer,
    }
}

module.exports = rootReducer;