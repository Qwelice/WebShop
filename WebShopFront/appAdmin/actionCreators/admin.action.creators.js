const categoryActions = require("../actions/category.actions");
const newProductActions = require("../actions/new.product.actions");
const productListActions = require("../actions/product.list.actions");
const adminService = require("../services/admin.service");

function newCategory(categoryName) {
  return (dispatch) => {
    dispatch(categoryActions.newCategoryRequest([], false, ""));
    adminService.newCategory(categoryName).then(
      (response) => {
        const succeed = response.succeed;
        if (succeed && succeed == true) {
          dispatch(categoryActions.newCategorySuccess([], false, ""));
        } else {
          dispatch(categoryActions.newCategoryFailure([], true, response));
        }
      },
      (error) => {
        dispatch(categoryActions.newCategoryFailure([], true, error));
      }
    );
  };
}

function requestCategories() {
  return (dispatch) => {
    dispatch(categoryActions.categoryListRequest([], false, ""));
    adminService.getCategories().then(
      (response) => {
        const categories = response.categories;
        if (categories) {
          dispatch(categoryActions.categoryListSuccess(categories, false, ""));
        }
      },
      (error) => {
        dispatch(categoryActions.categoryListFailure([], true, error));
      }
    );
  };
}

function productCreation(formData) {
  return (dispatch) => {
    dispatch(newProductActions.newProductRequest(true, false, false, ""));
    adminService.productCreation(formData).then(
      (response) => {
        dispatch(newProductActions.newProducSuccess(false, true, false, ""));
      },
      (error) => {
        dispatch(newProductActions.newProducFailure(false, false, true, error));
      }
    );
  };
}

function requestProductList() {
  return (dispatch) => {
    dispatch(productListActions.productsRequest([], true, false, false, ""));
    adminService.productsRequest().then(
      (response) => {
        const products = response.products;
        if (products) {
          dispatch(
            productListActions.productsSuccess(products, false, true, false, "")
          );
        } else {
          dispatch(
            productListActions.productsFailure(
              [],
              false,
              false,
              true,
              "что-то пошло не так"
            )
          );
        }
      },
      (error) => {
        dispatch(
          productListActions.productsFailure([], false, false, true, error)
        );
      }
    );
  };
}

function requestProductListByQuery(query) {
  return (dispatch) => {
    dispatch(productListActions.productsRequest([], true, false, false, ""));
    adminService.productsRequestByQuery(query).then(
      (response) => {
        const products = response.products;
        if (products) {
          dispatch(
            productListActions.productsSuccess(products, false, true, false, "")
          );
        } else {
          dispatch(
            productListActions.productsFailure(
              [],
              false,
              false,
              true,
              "что-то пошло не так"
            )
          );
        }
      },
      (error) => {
        dispatch(
          productListActions.productsFailure([], false, false, true, error)
        );
      }
    );
  };
}

module.exports = {
  newCategory,
  requestCategories,
  productCreation,
  requestProductList,
  requestProductListByQuery
};
