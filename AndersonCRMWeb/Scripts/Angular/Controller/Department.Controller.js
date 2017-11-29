(function () {
    'use strict';

    angular
        .module('App')
        .controller('DepartmentController', DepartmentController);

    DepartmentController.$inject = ['$filter', '$window', 'DepartmentService'];

    function DepartmentController($filter, $window, DepartmentService) {
        var vm = this;

        vm.DepartmentId;

        vm.Department;

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

        function InitialiseDropdown(departmentId) {
            vm.DepartmentId = departmentId;
            Read();
        }

        function Read() {
            DepartmentService.Read()
                .then(function (response) {
                    vm.Departments = response.data;
                    if (vm.DepartmentId)
                        UpdateDepartment();
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

        function UpdateDepartment() {
            vm.Department = $filter('filter')(vm.Departments, { DepartmentId: vm.DepartmentId })[0];
        }

        function Delete(departmentId) {
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

    }
})();