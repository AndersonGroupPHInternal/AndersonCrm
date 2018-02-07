(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeController', EmployeeController);

    EmployeeController.$inject = ['$filter', '$window', 'EmployeeService'];

    function EmployeeController($filter, $window, EmployeeService) {
        var vm = this;

        vm.EmployeeId;

        vm.Employee;
       
        vm.Employees = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;

        vm.Delete = Delete;

        function GoToUpdatePage(employeeId) {
            $window.location.href = '../Employee/Update/' + employeeId;
        }

        function Initialise() {
            Read();
        }

        function InitialiseDropdown(employeeId) {
            vm.EmployeeId = employeeId;
            Read();
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

        function UpdateEmployee() {
            vm.Employee = $filter('filter')(vm.Employees, { EmployeeId: vm.EmployeeId })[0];
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