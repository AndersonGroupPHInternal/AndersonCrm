(function () {
    'use strict';

    angular
        .module('App')
        .factory('AssetService', AssetService);

    AssetService.$inject = ['$http'];

    function AssetService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Asset/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(assetId) {
            return $http({
                method: 'DELETE',
                url: '/Asset/Delete/' + assetId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();