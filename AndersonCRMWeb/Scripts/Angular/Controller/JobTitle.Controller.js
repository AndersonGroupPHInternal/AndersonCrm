(function () {
    'use strict';

    angular
        .module('App')
        .controller('JobTitleController', JobTitleController);

    JobTitleController.$inject = ['$window', 'JobTitleService'];

    function JobTitleController($window, JobTitleService) {
        var vm = this;

        vm.Employees = [];
        vm.JobTitles = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;
        
        function GoToUpdatePage(jobTitleId) {
            $window.location.href = '../JobTitle/Update/' + jobTitleId;
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
            JobTitleService.Read()
                .then(function (response) {
                    vm.JobTitles = response.data;
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

        function Delete(jobTitleId) {
            JobTitleService.Delete(jobTitleId)
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