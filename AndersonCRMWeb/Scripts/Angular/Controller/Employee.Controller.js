(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeController', EmployeeController);

    EmployeeController.$inject = ['$filter', '$window', 'CompanyService', 'JobTitleService', 'EmployeeService'];

    function EmployeeController($filter, $window, CompanyService, JobTitleService, EmployeeService) {
        var vm = this;
        
        vm.EmployeeId;

        vm.Employee; 
        vm.EmployeeFilter = {
            IsActive: true,
            IsResigned: false
        }; 

        vm.Employees = [];
        vm.Companies = [];
        vm.JobTitles = [];
        vm.Departments = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;
        vm.ReadFiltered = ReadFiltered;
        
        vm.Delete = Delete; 

        function GoToUpdatePage(employeeId) {
            $window.location.href = '../Employee/Update/' + employeeId;
        }

        function Initialise() {
            ReadFiltered();
        }

        function InitialiseDropdown(employeeId) {
            vm.EmployeeId = employeeId;
            Read();
        }

        function ReadFiltered() {
            //ToDo: this should be done in the business logic
            //var employeeFilter = angular.copy(vm.EmployeeFilter);
            //if (employeeFilter.DateHiredFrom !== undefined) {
            //    employeeFilter.DateHiredFrom = moment(employeeFilter.DateHiredFrom).format('YYYY-MM-DD');
            //    employeeFilter.DateHiredTo = moment(employeeFilter.DateHiredFrom).add(1, 'months').format('YYYY-MM-DD');
            //}
            EmployeeService.ReadFiltered(vm.EmployeeFilter)
                .then(function (response) {
                    vm.Employees = response.data;
                    ReadCompanies();
                    ReadJobTitles();
                    UpdateManager();
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

        function ReadCompanies() {
            CompanyService.Read()
                .then(function (response) {
                    vm.Companies = response.data;
                    UpdateCompany();
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

        function ReadJobTitles() {
            JobTitleService.Read()
                .then(function (response) {
                    vm.JobTitles = response.data;
                    UpdateJobTitles();
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
        
        function UpdateCompany() {
            angular.forEach(vm.Employees, function (employee) {
                employee.Company = $filter('filter')(vm.Companies, { CompanyId: employee.CompanyId })[0];
            });
        }

        function UpdateEmployee() {
            vm.Employee = $filter('filter')(vm.Employees, { EmployeeId: vm.EmployeeId })[0];
        }

        function UpdateJobTitles() {
            angular.forEach(vm.Employees, function (employee) {
                employee.JobTitle = $filter('filter')(vm.JobTitles, { JobTitleId: employee.JobTitleId })[0];
            });
        }

        function UpdateManager() {
            angular.forEach(vm.Employees, function (employee) {
                employee.Manager = $filter('filter')(vm.Employees, { EmployeeId: employee.ManagerEmployeeId })[0];
            });
        }

        function Delete(employeeId) {
            var conf = window.confirm("Are you sure you want to delete?");
            if (conf === true) {
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

    }
})();