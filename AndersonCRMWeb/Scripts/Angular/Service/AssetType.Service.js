(function () {
    'use strict';

    angular
        .module('App')
        .factory('AssetTypeService', AssetTypeService);

    AssetTypeService.$inject = ['$http'];

    function AssetTypeService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/AssetType/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(assetTypeId) {
            return $http({
                method: 'DELETE',
                url: '/AssetType/Delete/' + assetTypeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();