(function () {
    'use strict';

    angular
        .module('App')
        .controller('JobTitleController', JobTitleController);

    JobTitleController.$inject = ['$filter', '$window', 'JobTitleService'];

    function JobTitleController($filter, $window, JobTitleService) {
        var vm = this;

        vm.JobTitleId;

        vm.JobTitle;

        vm.JobTitles = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;

        vm.Delete = Delete;
        
        function GoToUpdatePage(jobTitleId) {
            $window.location.href = '../JobTitle/Update/' + jobTitleId;
        } 

        function Initialise() {
            Read();
        }

        function InitialiseDropdown(jobTitleId) {
            vm.JobTitleId = jobTitleId;
            Read();
        } 

        function Read() {
            JobTitleService.Read()
                .then(function (response) {
                    vm.JobTitles = response.data;
                    if (vm.JobTitleId)
                        UpdateJobTitle();
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

        function UpdateJobTitle() {
            vm.JobTitle = $filter('filter')(vm.JobTitles, { JobTitleId: vm.JobTitleId })[0];
        }

        function Delete(jobTitleId) {
            var conf = window.confirm("Are you sure you want to delete?");
            if (conf == true) {
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
            else { return; false }
        }

    }
})();