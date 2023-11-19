const shopActions = require("../actions/shop.actions");
const shopService = require("../services/shop.service");

function getProducts() {
  return (dispatch) => {
    dispatch(
      shopActions.productListRequest([], -1, -1, true, false, false, "")
    );
    shopService.getProducts().then(
      (response) => {
        dispatch(
          shopActions.productListSuccess(
            response.products,
            response.pageCount,
            response.currentPage,
            false,
            true,
            false,
            ""
          )
        );
      },
      (error) => {
        dispatch(
          shopActions.productListFailure([], -1, -1, false, false, true, error)
        );
      }
    );
  };
}

function getProductsByPage(page) {
  return (dispatch) => {
    dispatch(
      shopActions.productListRequest([], -1, -1, true, false, false, "")
    );
    shopService.getProductsByPage(page).then(
      (response) => {
        dispatch(
          shopActions.productListSuccess(
            response.products,
            response.pageCount,
            response.currentPage,
            false,
            true,
            false,
            ""
          )
        );
      },
      (error) => {
        dispatch(
          shopActions.productListFailure([], -1, -1, false, false, true, error)
        );
      }
    );
  };
}

function getProductsByQuery(query) {
  return (dispatch) => {
    dispatch(
      shopActions.productListRequest([], -1, -1, true, false, false, "")
    );
    shopService.getProductsByQuery(query).then(
      (response) => {
        dispatch(
          shopActions.productListSuccess(
            response.products,
            response.pageCount,
            response.currentPage,
            false,
            true,
            false,
            ""
          )
        );
      },
      (error) => {
        dispatch(
          shopActions.productListFailure([], -1, -1, false, false, true, error)
        );
      }
    );
  };
}

function getProductsByQueryAndPage(query, page) {
  return (dispatch) => {
    dispatch(
      shopActions.productListRequest([], -1, -1, true, false, false, "")
    );
    shopService.getProductsByQueryAndPage(query, page).then(
      (response) => {
        dispatch(
          shopActions.productListSuccess(
            response.products,
            response.pageCount,
            response.currentPage,
            false,
            true,
            false,
            ""
          )
        );
      },
      (error) => {
        dispatch(
          shopActions.productListFailure([], -1, -1, false, false, true, error)
        );
      }
    );
  };
}

function appendToCart(product, collection) {
  return (dispatch) => {
    const contains =
      collection.filter((item) => item.product.name === product.name).length >
      0;
    if (contains) {
      const newCollection = collection.map((item) => {
        if (item.product.name === product.name) {
          return { ...item, count: item.count + 1 };
        }
        return item;
      });
      dispatch(shopActions.cartAppend(newCollection));
    } else {
      const newCollection = [...collection, { product, count: 1 }];
      dispatch(shopActions.cartAppend(newCollection));
    }
  };
}

function removeFromCart(product, collection) {
  return (dispatch) => {
    const filtered = collection.filter(
      (item) => item.product.name === product.name
    );
    const without = collection.filter(
      (item) => item.product.name !== product.name
    );
    const contains = filtered.length > 0;
    if (contains) {
      const obj = filtered[0];
      if (obj.count > 1) {
        const newCollection = [...without, { ...obj, count: obj.count - 1 }];
        dispatch(shopActions.cartRemove(newCollection));
      } else {
        const newCollection = collection.filter(
          (item) => item.product.name !== product.name
        );
        dispatch(shopActions.cartRemove(newCollection));
      }
    }
  };
}

module.exports = {
  getProducts,
  getProductsByPage,
  getProductsByQuery,
  getProductsByQueryAndPage,
  appendToCart,
  removeFromCart,
};
