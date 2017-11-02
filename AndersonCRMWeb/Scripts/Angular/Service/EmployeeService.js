(function () {
    'use strict';

    angular
        .module('App')
        .factory('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['$http'];

    function EmployeeService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Employee/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(employeeId) {
            return $http({
                method: 'DELETE',
                url: '/Employee/Delete/' + employeeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();