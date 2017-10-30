(function () {
    'use strict';

    angular
        .module('App')
        .controller('TeamController', TeamController);

    TeamController.$inject = ['$window', 'TeamService'];

    function TeamController($window, TeamService) {
        var vm = this;

        vm.Employees = [];
        vm.Teams = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;
        
        function GoToUpdatePage(teamId) {
            $window.location.href = '../Team/Update/' + teamId;
        } 

        function Initialise() {
            Read();
        }

        function ReadEmployees() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Read() {
            TeamService.Read()
                .then(function (response) {
                    vm.Teams = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Delete(teamId) {
            TeamService.Delete(teamId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

    }
})();