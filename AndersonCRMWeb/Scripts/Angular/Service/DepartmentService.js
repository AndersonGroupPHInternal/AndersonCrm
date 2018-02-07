(function () {
    'use strict';

    angular
        .module('App')
        .factory('DepartmentService', DepartmentService);

    DepartmentService.$inject = ['$http'];

    function DepartmentService($http) {
        return {
            Read: Read,
            ReadSelectedDepartment: ReadSelectedDepartment,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Department/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadSelectedDepartment(employeeId) {
            return $http({
                method: 'POST',
                url: '/Department/ReadSelectedDepartment/' + employeeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(departmentId) {
            return $http({
                method: 'DELETE',
                url: '/Department/Delete/' + departmentId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();