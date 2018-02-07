(function () {
    'use strict';

    angular
        .module('App')
        .controller('DepartmentController', DepartmentController);

    DepartmentController.$inject = ['$filter', '$window', 'DepartmentService'];

    function DepartmentController($filter, $window, DepartmentService) {
        var vm = this;

        vm.EmployeeId;
        vm.Department;
        vm.EmployeeDepartments = [];
        vm.Departments = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;

        vm.Delete = Delete;

        function GoToUpdatePage(departmentId) {
            $window.location.href = '../Department/Update/' + departmentId;
        }

        function Initialise() {
            Read();
        }

        function InitialiseDropdown(employeeId) {
            vm.EmployeeId = employeeId;
            Read();
        }

        function Read() {
            DepartmentService.Read()
                .then(function (response) {
                    vm.Departments = response.data;
                        ReadSelectedDepartment();
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

        function ReadSelectedDepartment() {
            DepartmentService.ReadSelectedDepartment(vm.EmployeeId)
                .then(function (response) {
                    var employeeDepartments = response.data;
                    angular.forEach(employeeDepartments, function (employeeDepartment) {
                        var employeeDepartment = $filter('filter')(vm.Departments, { DepartmentId: employeeDepartment.DepartmentId })[0];
                        vm.EmployeeDepartments.push(employeeDepartment);
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

        function Delete(departmentId) {
            var conf = window.confirm("Are you sure you want to delete?");
            if (conf == true) {
            DepartmentService.Delete(departmentId)
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