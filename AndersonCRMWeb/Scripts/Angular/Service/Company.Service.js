(function () {
    'use strict';

    angular
        .module('App')
        .factory('CompanyService', CompanyService);

    CompanyService.$inject = ['$http'];

    function CompanyService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Company/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(companyId) {
            return $http({
                method: 'DELETE',
                url: '/Company/Delete/' + companyId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();