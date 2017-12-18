(function () {
    'use strict';

    angular
        .module('App')
        .controller('TeamController', TeamController);

    TeamController.$inject = ['$window', 'TeamService'];

    function TeamController($window, TeamService) {
        var vm = this;

        vm.TeamId;
        vm.Team;
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

        function InitialiseDropdown(teamId) {
            vm.TeamId = teamId;
            Read();
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