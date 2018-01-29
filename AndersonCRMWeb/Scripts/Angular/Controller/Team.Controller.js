(function () {
    'use strict';

    angular
        .module('App')
        .controller('TeamController', TeamController);

    TeamController.$inject = ['$filter', '$window', 'TeamService'];

    function TeamController($filter, $window, TeamService) {
        var vm = this;

        vm.EmployeeId;
        vm.Team;
        vm.EmployeeTeams = [];
        vm.Teams = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;

        vm.Delete = Delete;
        
        function GoToUpdatePage(teamId) {
            $window.location.href = '../Team/Update/' + teamId;
        } 

        function Initialise() {
            Read();
        }

        function InitialiseDropdown(employeeId) {
            vm.EmployeeId = employeeId;
            Read();
        }

        function Read() {
            TeamService.Read()
                .then(function (response) {
                    vm.Teams = response.data;
                    ReadSelectedTeam();
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

        function ReadSelectedTeam() {
            TeamService.ReadSelectedTeam(vm.EmployeeId)
                .then(function (response) {
                    var employeeTeams = response.data;
                    angular.forEach(employeeTeams, function (employeeTeam) {
                        var employeeTeam = $filter('filter')(vm.Teams, { TeamId: employeeTeam.TeamId })[0];
                        vm.EmployeeTeams.push(employeeTeam);
                    });
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
            var conf = window.confirm("Are you sure you want to delete?");
            if (conf == true) {
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
            else { return; false }
        }

    }
})();