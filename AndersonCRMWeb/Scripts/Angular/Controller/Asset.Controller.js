(function () {
    'use strict';

    angular
        .module('App')
        .controller('AssetController', AssetController);

    AssetController.$inject = ['$filter', '$window', 'AssetService'];

    function AssetController($filter, $window, AssetService) {
        var vm = this;

        vm.AssetId;

        vm.Asset;

        vm.Assets = [];

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