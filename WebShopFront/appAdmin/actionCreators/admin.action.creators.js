const categoryActions = require('../actions/category.actions');
const adminService = require('../services/admin.service');

function newCategory(categoryName){
    return (dispatch) => {
        dispatch(categoryActions.newCategoryRequest([], false, ""));
        adminService.newCategory(categoryName).then(
            (response) => {
                const succeed = response.succeed;
                if(succeed && succeed == true){
                    const category = response.category;
                    dispatch(categoryActions.newCategorySuccess([category], false, ""));
                }else{
                    dispatch(categoryActions.newCategoryFailure([], true, response));
                }
            },
            (error) => {
                dispatch(categoryActions.newCategoryFailure([], true, error));
            }
        )
    };
}

module.exports = {newCategory};