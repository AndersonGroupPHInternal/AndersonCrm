(function () {
    'use strict';

    angular
        .module('App')
        .factory('JobTitleService', JobTitleService);

    JobTitleService.$inject = ['$http'];

    function JobTitleService($http) {
        return {
            Read: Read,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/JobTitle/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(jobTitleId) {
            return $http({
                method: 'DELETE',
                url: '/JobTitle/Delete/' + jobTitleId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();