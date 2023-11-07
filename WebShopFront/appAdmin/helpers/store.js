const redux = require('@reduxjs/toolkit');
const thunkMiddleware = require('redux-thunk').default;

const rootReducer = require('../reducers/root.reducer');

const store = redux.configureStore(rootReducer, thunkMiddleware);

module.exports = store;