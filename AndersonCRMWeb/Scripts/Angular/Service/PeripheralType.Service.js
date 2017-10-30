(function () {
    'use strict';

    angular
        .module('App')
        .factory('PeripheralTypeService', PeripheralTypeService);

    PeripheralTypeService.$inject = ['$http'];

    function PeripheralTypeService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/PeripheralType/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(peripheralTypeId) {
            return $http({
                method: 'DELETE',
                url: '/PeripheralType/Delete/' + peripheralTypeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();