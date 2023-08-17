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
app.directive('greaterThan', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            ngModel.$validators.greaterThan = function (value) {
                return value > scope.product.buyPrice;
            };

            scope.$watch('product.buyPrice', function () {
                ngModel.$validate();
            });
        }
    };
});


app.controller("product",
    function ($scope, $http) {
        $scope.init = function () {
            $scope.categories = [];
            $scope.products = [];
            $scope.product = {};
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.getCategories();
            $scope.getProducts();

        };

        $scope.getCategories = function () {
            $http.get("/api/categories").then(function (data) {
                $scope.categories = data.data;
                console.log("Retrieved categories:", $scope.categories);
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.rowHighlighted = function (idSelected) {
            $scope.data.selectedRow = idSelected;
        };

        $scope.deleteProduct = function (item) {
            $http.post(`/api/product/${item.id}/delete`).then(function (data) {
                const index = $scope.products.indexOf(item);
                $scope.products.splice(index, 1);
                huminAlert.successToast("deleted successfully");
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.storeProduct = function () {
            $http.post("/api/product", $scope.product).then(function (data) {
                huminAlert.success("added successfully");
                $scope.reset();
                $scope.getProducts();
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.updateProduct = function () {
            $http.post(`/api/product/${$scope.product.id}/update`, $scope.product).then(
                function (data) {
                    huminAlert.success("updated successfully");
                    $scope.reset();
                    $scope.getProducts();
                },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.editProduct = function (product) {
            $scope.data.isUpdate = true;
            $scope.product.name = product.name;
            $scope.product.id = product.id;
            $scope.product.categoryId = product.category.id;
        };

        $scope.getProducts = function () {
            $http.get("/api/products").then(function (data) {
                $scope.products = data.data;
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.reset = function () {
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.product = {};
        };
    });