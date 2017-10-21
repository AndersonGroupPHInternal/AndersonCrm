(function () {
    'use strict';

    angular
        .module('App')
        .factory('PeripheralHistoryService', PeripheralHistoryService);

   PeripheralHistoryService.$inject = ['$http'];

    function PeripheralHistoryService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(peripheralhistory) {
            return $http({
                method: 'POST',
                url: '../PeripheralHistory/Create',
                data: {
                    peripheralhistory: peripheralhistory
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../PeripheralHistory/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(peripheralhistory) {
            return $http({
                method: 'POST',
                url: '../PeripheralHistory/Update',
                data: {
                    peripheralhistory: peripheralhistory
                }
            });
        }
        function Delete(peripheralhistory) {
            return $http({
                method: 'POST',
                url: '../PeripheralHistory/Delete',
                data: {
                    peripheralhistory: peripheralhistory
                },
            })
        }

    }
})();