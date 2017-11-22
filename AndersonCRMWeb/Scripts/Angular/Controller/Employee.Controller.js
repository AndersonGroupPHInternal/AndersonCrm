(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeController', EmployeeController);

    EmployeeController.$inject = ['$filter', '$window', 'CompanyService', 'JobTitleService','EmployeeService'];

    function EmployeeController($filter, $window, CompanyService, JobTitleService, EmployeeService) {
        var vm = this;

        vm.EmployeeId;
        vm.Employee;
        vm.Employees = [];
        vm.Companies = [];
        vm.Jobs = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;

        vm.UpdateCompany = UpdateCompany;
        vm.UpdateJobs = UpdateJobs;
        vm.Delete = Delete;

        function GoToUpdatePage(employeeId) {
            $window.location.href = '../Employee/Update/' + employeeId;
        }

        function Initialise() {
            Read();
            ReadCompanies();
            ReadJobs();
        }

        function InitialiseDropdown(employeeId) {
            vm.EmployeeId = employeeId;
            Read();
        } 

        function ReadJobs() {
            JobTitleService.Read()
                .then(function (response) {
                    vm.Jobs = response.data;
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

        function ReadCompanies() {
            CompanyService.Read()
                .then(function (response) {
                    vm.Companies = response.data;
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
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                    if (vm.EmployeeId)
                        UpdateEmployee();
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

        function UpdateCompany(employee) {
            employee.Company = $filter('filter')(vm.Companies, { CompanyId: employee.CompanyId })[0];
        }

        function UpdateEmployee() {
            vm.Employee = $filter('filter')(vm.Employees, { EmployeeId: vm.EmployeeId })[0];
        }

        function UpdateJobs(employee) {
            employee.JobTitle = $filter('filter')(vm.Jobs, { JobTitleId: employee.JobTitleId })[0];
        }

        function Delete(employeeId) {
            EmployeeService.Delete(employeeId)
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