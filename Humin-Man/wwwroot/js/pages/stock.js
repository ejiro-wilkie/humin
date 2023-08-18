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
            $scope.data = { isUpdate: false, isSell: false, selectedRow: null };
            $scope.filteredProducts = [];
            $scope.getProducts();
            $scope.getShops();
            $scope.getStocks();
            $scope.getCategories();

        };

        $scope.getProducts = function () {
            $http.get("/api/products").then(function (data) {
                $scope.products = data.data;
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.getShops = function () {
            $http.get("/api/shops").then(function (data) {
                $scope.shops = data.data;            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.getCategories = function () {
            $http.get("/api/categories").then(function (data) {
                $scope.categories = data.data;
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
                    huminAlert.success("Sold successfully");
                    $scope.reset();
                    $scope.getStocks();
                },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.sellStock = function (stock) {
            $scope.data.isSell = true;
            $scope.stock.id = stock.id;
            $scope.stock.quantity = stock.quantity;
            $scope.stock.shopId = stock.shop.id;
            $scope.stock.categoryId = stock.product.category.id;
            $scope.stock.productId = stock.product.id;
        };

        $scope.getStocks = function () {
            $http.get("/api/stocks").then(function (data) {
                $scope.stocks = data.data;
            },
                function (error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.filterProductsByCategory = function () {
            if ($scope.stock.categoryId) {
                $scope.filteredProducts = $scope.products.filter(product => product.category.id === $scope.stock.categoryId);
            } else {
                $scope.filteredProducts = [];
            }
        };

        $scope.updateShopCapacity = function () {
            let selectedShop = $scope.shops.find(shop => shop.id === $scope.stock.shopId);
            $scope.selectedShopCapacity = selectedShop ? selectedShop.capacity : null;
        };


        $scope.reset = function () {
            $scope.data = { isUpdate: false, isSell: false, selectedRow: null };
            $scope.stock = {};
        };
    });