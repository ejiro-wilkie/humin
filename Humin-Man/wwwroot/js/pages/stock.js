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

app.controller("stock",
    function ($scope, $http) {
        $scope.init = function () {
            $scope.products = [];
            $scope.shops = [];
            $scope.stocks = [];
            $scope.stock = {};
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.getProducts();
            $scope.getShops();
            $scope.getStocks();

        };

        $scope.getProducts = function () {
            $http.get("/api/products").then(function (data) {
                $scope.products = data.data;
                console.log("Retrieved products:", $scope.products);
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.getShops = function () {
            $http.get("/api/shops").then(function (data) {
                $scope.shops = data.data;
                console.log("Retrieved shops:", $scope.shops);
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.rowHighlighted = function (idSelected) {
            $scope.data.selectedRow = idSelected;
        };

        $scope.deleteStock = function (item) {
            $http.post(`/api/stock/${item.id}/delete`).then(function (data) {
                const index = $scope.stocks.indexOf(item);
                $scope.stocks.splice(index, 1);
                huminAlert.successToast("deleted successfully");
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.storeStock = function () {
            $http.post("/api/stock", $scope.stock).then(function (data) {
                huminAlert.success("added successfully");
                $scope.reset();
                $scope.getStocks();
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.updateStock = function () {
            $http.post(`/api/stock/${$scope.stock.id}/update`, $scope.stock).then(
                function (data) {
                    huminAlert.success("updated successfully");
                    $scope.reset();
                    $scope.getStocks();
                },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.editStock = function (stock) {
            $scope.data.isUpdate = true;
            $scope.stock.name = stock.name;
            $scope.stock.id = stock.id;
            $scope.stock.productId = stock.product.id;
            $scope.stock.shopId = stock.shop.id;
        };

        $scope.getStocks = function () {
            $http.get("/api/stocks").then(function (data) {
                $scope.stocks = data.data;
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.reset = function () {
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.stock = {};
        };
    });