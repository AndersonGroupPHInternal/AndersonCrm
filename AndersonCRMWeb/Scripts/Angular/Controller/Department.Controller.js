(function () {
    'use strict';

    angular
        .module('App')
        .controller('DepartmentController', DepartmentController);

    DepartmentController.$inject = ['$window', 'DepartmentService'];

    function DepartmentController($window, DepartmentService) {
        var vm = this;
        vm.Departments = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;

        function GoToUpdatePage(departmentId) {
            $window.location.href = '../Department/Update/' + departmentId;
        }

        function Initialise() {
            Read();
        }

        function Read() {
            DepartmentService.Read()
                .then(function (response) {
                    vm.Departments = response.data;
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