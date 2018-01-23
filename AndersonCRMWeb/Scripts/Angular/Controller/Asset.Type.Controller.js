(function () {
    'use strict';

    angular
        .module('App')
        .controller('AssetTypeController', AssetTypeController);

    AssetTypeController.$inject = ['$filter','$window', 'AssetTypeService'];

    function AssetTypeController($filter, $window, AssetTypeService) {
        var vm = this;

        vm.AssetTypes = [];

        vm.AssetTypeId;

        vm.AssetType;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;


        vm.Delete = Delete;
        
        function GoToUpdatePage(assetTypeId) {
            $window.location.href = '../AssetType/Update/' + assetTypeId;
        } 

        function Initialise() {
            Read();
        }
        function InitialiseDropdown(assetTypeId) {
            vm.AssetTypeId = assetTypeId;
            Read();
        }

        function Read() {
            AssetTypeService.Read()
                .then(function (response) {
                    vm.AssetTypes = response.data;
                    if (vm.AssetTypeId)
                    {
                        UpdateAssetTypes();
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

        function UpdateAssetTypes() {
            vm.AssetType = $filter('filter')(vm.AssetTypes, { AssetTypeId: vm.AssetTypeId })[0];
        }

        function Delete(assetTypeId) {
            var conf = window.confirm("Are you sure you want to delete?");
            if (conf == true) {
            AssetTypeService.Delete(assetTypeId)
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