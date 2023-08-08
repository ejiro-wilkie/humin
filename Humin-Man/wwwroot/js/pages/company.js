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

app.controller("company",
    function($scope, $http) {
        $scope.init = function() {
            $scope.countries = [];
            $scope.companies = [];
            $scope.company = {};
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.getCountries();
            $scope.getCompanies();
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

        $scope.deleteCompany = function(item) {
            $http.post(`api/company/${item.id}/delete`).then(function(data, status, headers, config) {
                    const index = $scope.companies.indexOf(item);
                    $scope.companies.splice(index, 1);
                    huminAlert.successToast("deleted successfully");
                },
                function(error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.storeCompany = function() {
            $http.post("/api/company", $scope.company).then(function(data, status, headers, config) {
                    huminAlert.success("added successfully");
                    $scope.reset();
                    $scope.getCompanies();
                },
                function(error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.updateCompany = function() {
            console.log($scope.company);
            $http.post(`/api/company/${$scope.company.id}/update`, $scope.company).then(
                function(data, status, headers, config) {
                    huminAlert.success("updated successfully");
                    $scope.reset();
                    $scope.getCompanies();
                },
                function(error) {
                    huminAlert.error(error.data.message);
                });
        };

        $scope.editCompany = function(company) {
            $scope.data.isUpdate = true;
            $scope.company.name = company.name;
            $scope.company.id = company.id;
            $scope.company.countryId = company.country.id;
        };

        $scope.getCompanies = function() {
            $http.get("/api/companies").then(function(data, status, headers, config) {
                    $scope.companies = data.data;
                },
                function() {
                    huminAlert.errorhuminAlert(error.data.message);
                });
        };

        $scope.reset = function() {
            $scope.data = { isUpdate: false, selectedRow: null };
            $scope.company = {};
        };
    });