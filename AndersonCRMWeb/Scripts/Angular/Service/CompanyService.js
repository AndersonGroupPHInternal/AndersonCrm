(function () {
    'use strict';

    angular
    .module('App')
    .factory('CompanyService', CompanyService);

    CompanyService.$inject = ['$http'];

    function CompanyService($http) {
        return {
            Create: Create,
            List: List,
            Update: Update,
            Delete: Delete
        }

        function Create(company) {
            return $http({
                method: 'POST',
                url: '../Company/Create',
                data: {
                    company: company
                }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../Company/List',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Update(company) {
            return $http({
                method: 'POST',
                url: '../Company/Update',
                data: {
                    company: company
                }
            });
        }
        function Delete(company) {
            return $http({
                method: 'POST',
                url: '../Company/Delete',
                data: {
                    company: company
                },
            })
        }
    }
})();