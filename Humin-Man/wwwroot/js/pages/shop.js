var app = angular.module("App", []);
app.directive('ngConfirmClick', [
        function() {
            return {
                link: function(scope, element, attr) {
                    var msg = attr.ngConfirmClick || "Are you sure?";
                    var clickAction = attr.confirmedClick;
                    element.bind('click',
                        function(event) {
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

app.controller("shop",
    function($scope, $http) {
        $scope.init = function() {
            $scope.countries = [];
            $scope.shops = [];
            $scope.shop = {};
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.getCountries();
            $scope.getShops();
        };

        $scope.getCountries = function() {
            $http.get("/api/countries").then(function(data, status, headers, config) {
                    $scope.countries = data.data;
                },
                function(error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.rowHighlighted = function(idSelected) {
            $scope.data.selectedRow = idSelected;
        };

        $scope.deleteShop = function(item) {
            $http.post(`api/shop/${item.id}/delete`).then(function(data, status, headers, config) {
                    const index = $scope.shops.indexOf(item);
                    $scope.shops.splice(index, 1);
                    huminAlert.successToast("deleted successfully");
                },
                function(error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.storeShop = function() {
            $http.post("/api/shop", $scope.shop).then(function(data, status, headers, config) {
                    huminAlert.success("added successfully");
                    $scope.reset();
                    $scope.getShops();
                },
                function(error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.updateShop = function() {
            console.log($scope.shop);
            $http.post(`/api/shop/${$scope.shop.id}/update`, $scope.shop).then(
                function(data, status, headers, config) {
                    huminAlert.success("updated successfully");
                    $scope.reset();
                    $scope.getShops();
                },
                function(error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.editShop = function(shop) {
            $scope.data.isUpdate = true;
            $scope.shop.name = shop.name;
            $scope.shop.id = shop.id;
            $scope.shop.countryId = shop.country.id;
            $scope.shop.capacity = shop.capacity;
        };

        $scope.getShops = function() {
            $http.get("/api/shops").then(function(data, status, headers, config) {
                    $scope.shops = data.data;
                },
                function() {
                    huminAlert.errorhuminAlert(error.data.message);
                });
        };

        $scope.reset = function() {
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.shop = {};
        };
    });