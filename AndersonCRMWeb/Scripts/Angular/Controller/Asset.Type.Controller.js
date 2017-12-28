(function () {
    'use strict';

    angular
        .module('App')
        .controller('AssetTypeController', AssetTypeController);

    AssetTypeController.$inject = ['$window', 'AssetTypeService'];

    function AssetTypeController($window, AssetTypeService) {
        var vm = this;

        vm.AssetTypes = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;
        
        function GoToUpdatePage(assetTypeId) {
            $window.location.href = '../AssetType/Update/' + assetTypeId;
        } 

        function Initialise() {
            Read();
        }

        function Read() {
            AssetTypeService.Read()
                .then(function (response) {
                    vm.AssetTypes = response.data;
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

        function Delete(assetTypeId) {
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

    }
})();