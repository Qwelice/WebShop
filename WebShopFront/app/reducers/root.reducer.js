const accountReducer = require('./account.reducer');
const productsReducer = require('./products.reducer');
const cartReducer = require('./cart.reducer');

const rootReducer = {
    reducer: {
        account: accountReducer,
        products: productsReducer,
        cart: cartReducer,
    }
};

module.exports = rootReducer;