(function () {
    'use strict';

    angular
        .module('App')
        .controller('AssetController', AssetController);

    AssetController.$inject = ['$filter', '$window', 'AssetService','AssetTypeService','EmployeeService'];

    function AssetController($filter, $window, AssetService, AssetTypeService, EmployeeService) {
        var vm = this;

        vm.AssetId;

        vm.Asset;

        vm.Assets = [];
        vm.AssetTypes = [];
        vm.Employees = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;

        vm.Delete = Delete;

        function GoToUpdatePage(assetId) {
            $window.location.href = '../Asset/Update/' + assetId;
        }

        function Initialise() {
            // vm.AssetId = companyId;
            Read();

        }


        function InitialiseDropdown(assetId) {
            vm.AssetId = assetId;
            Read();
        }

        function Read() {
            AssetService.Read()
                .then(function (response) {
                    vm.Assets = response.data;
                    if (vm.AssetId)
                        UpdateAsset();
                    else
                    {
                        ReadAssetType();
                        ReadEmployee();
                    }
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function ReadAssetType() {
            AssetTypeService.Read()
                .then(function (response) {
                    vm.AssetTypes = response.data;
                    UpdateAssetType();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function ReadEmployee() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                    UpdateEmployee();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function UpdateAsset() {
            vm.Asset = $filter('filter')(vm.Assets, { AssetId: vm.AssetId })[0];
        }

        function UpdateAssetType() {
            angular.forEach(vm.Assets, function (asset) {
                asset.AssetType = $filter('filter')(vm.AssetTypes, { AssetTypeId: asset.AssetTypeId })[0];
            });
        }

        function UpdateEmployee() {
            angular.forEach(vm.Assets, function (asset) {
                asset.Employee = $filter('filter')(vm.Employees, { EmployeeId: asset.EmployeeId })[0];
            });
        }


        function Delete(assetId) {
            var conf = window.confirm("Are you sure you want to delete?");
            if (conf == true) {
            AssetService.Delete(assetId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                    });
            }
            else { return; false }
        }

    }
})();