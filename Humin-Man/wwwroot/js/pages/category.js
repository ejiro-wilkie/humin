var app = angular.module("App", []);
app.directive('ngConfirmClick', [
    function () {
        return {
            link: function (scope, element, attr) {
                var msg = attr.ngConfirmClick || "Are you sure?";
                var clickAction = attr.confirmedClick;
                element.bind('click',
                    function (event) {
                        window.Swal.fire({
                            title: msg,
                            showDenyButton: true,
                            showCancelButton: false,
                            confirmButtonText: `Yes`,
                            denyButtonText: `No`,
                        }).then((result) => {
                            if (result.isConfirmed) {
                                scope.$eval(clickAction);
                            }
                        });
                    });
            }
        };
    }
]);

app.controller("category",
    function ($scope, $http) {
        $scope.init = function () {
            $scope.categories = [];
            $scope.category = {};
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.getCategories();
        };

        $scope.rowHighlighted = function (idSelected) {
            $scope.data.selectedRow = idSelected;
        };

        $scope.deleteCategory = function (item) {
            $http.post(`api/category/${item.id}/delete`).then(function (data, status, headers, config) {
                const index = $scope.categories.indexOf(item);
                $scope.categories.splice(index, 1);
                huminAlert.successToast("deleted successfully");
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.storeCategory = function () {
            $http.post("/api/category", $scope.category).then(function (data, status, headers, config) {
                huminAlert.success("added successfully");
                $scope.reset();
                $scope.getCategories();
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.updateCategory = function () {
            $http.post(`/api/category/${$scope.category.id}/update`, $scope.category).then(
                function (data, status, headers, config) {
                    huminAlert.success("updated successfully");
                    $scope.reset();
                    $scope.getCategories();
                },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.editCategory = function (category) {
            $scope.data.isUpdate = true;
            $scope.category.name = category.name;
            $scope.category.id = category.id;
        };

        $scope.getCategories = function () {
            $http.get("/api/categories").then(function (data, status, headers, config) {
                $scope.categories = data.data;
            },
                function () {
                    huminAlert.errorhuminAlert(error.data.message);
                });
        };

        $scope.reset = function () {
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.category = {};
        };
    });
