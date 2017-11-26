(function () {
    'use strict';

    angular
        .module('App')
        .factory('PeripheralService', PeripheralService);

    PeripheralService.$inject = ['$http'];

    function PeripheralService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Peripheral/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(peripheralId) {
            return $http({
                method: 'DELETE',
                url: '/Peripheral/Delete/' + peripheralId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();