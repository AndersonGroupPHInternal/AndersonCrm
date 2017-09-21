(function () {
    'use strict';

    angular
        .module('App')
        .factory('DepartmentService', DepartmentService);

    DepartmentService.$inject = ['$http'];

    function DepartmentService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(department) {
            return $http({
                method: 'POST',
                url: '../Department/Create',
                data: {
                    department: department
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../Department/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(department) {
            return $http({
                method: 'POST',
                url: '../Department/Update',
                data: {
                    department: department
                }
            });
        }
        function Delete(department) {
            return $http({
                method: 'POST',
                url: '../Department/Delete',
                data: {
                    department: department
                },
            })
        }
    }
})();