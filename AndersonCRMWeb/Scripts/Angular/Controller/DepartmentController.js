(function () {
    'use strict';

    angular
        .module('App')
        .controller('DepartmentController', DepartmentController);

    DepartmentController.$inject = ['DepartmentService', '$window'];

    function DepartmentController(DepartmentService, $window) {
        var vm = this;

        vm.Department;

        vm.Departments = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateModal = CreateModal;
        vm.Update = Update;
        vm.UpdateModal = UpdateModal;
        vm.Delete = Delete;
        vm.Details = Details;

        function Create() {
            DepartmentService.Create(vm.Department)
                .then(function (response) {
                    List();
                    angular.element('#DepartmentModal').modal('hide');

                    new PNotify({
                        title: 'Success',
                        text: 'Department Created',
                        type: 'success',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                })
                .catch(function (data, status) {
                    //new PNotify({
                    //    title: 'Error',
                    //    text: 'There was an error on loading the list',
                    //    type: 'error',
                    //    hide: true,
                    //    addclass: "stack-bottomright"
                    //});

                });
        }

        function CreateModal(department) {
            vm.Department = {
                DepartmentId: 0,
                Description: '',
               
            };
        }

        function List() {
            DepartmentService.List()
                .then(function (response) {
                    vm.Departments = response.data;
                })
                .catch(function (data, status) {
                    //new PNotify({
                    //    title: 'Error',
                    //    text: 'There was an error on loading the list',
                    //    type: 'error',
                    //    hide: true,
                    //    addclass: "stack-bottomright"
                    //});

                });
        }

        function Update() {
            DepartmentService.Update(vm.Department)
                .then(function (response) {
                    List();
                    angular.element('#DepartmentModal').modal('hide');
                })
                .catch(function (data, status) {
                    //new PNotify({
                    //    title: 'Error',
                    //    text: 'There was an error on loading the list',
                    //    type: 'error',
                    //    hide: true,
                    //    addclass: "stack-bottomright"
                    //});

                });
        }

        function UpdateModal(department) {
            vm.Department = angular.copy(department);
        }

        function Delete(department) {
            DepartmentService.Delete(department)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }
        function Details(department) {
            $window.location = '/Department/Details/' + department.DepartmentId
        }
    }
})();