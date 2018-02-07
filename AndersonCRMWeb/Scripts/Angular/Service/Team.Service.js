(function () {
    'use strict';

    angular
        .module('App')
        .factory('TeamService', TeamService);

    TeamService.$inject = ['$http'];

    function TeamService($http) {
        return {
            Read: Read,
            ReadSelectedTeam: ReadSelectedTeam,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Team/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadSelectedTeam(employeeId) {
            return $http({
                method: 'POST',
                url: '/Team/ReadSelectedTeam/' + employeeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(teamId) {
            return $http({
                method: 'DELETE',
                url: '/Team/Delete/' + teamId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();