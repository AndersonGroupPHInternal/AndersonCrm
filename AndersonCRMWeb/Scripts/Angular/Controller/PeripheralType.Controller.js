(function () {
    'use strict';

    angular
        .module('App')
        .controller('PeripheralTypeController', PeripheralTypeController);

    PeripheralTypeController.$inject = ['$window', 'PeripheralTypeService'];

    function PeripheralTypeController($window, PeripheralTypeService) {
        var vm = this;

        vm.Employees = [];
        vm.PeripheralTypes = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;
        
        function GoToUpdatePage(peripheralTypeId) {
            $window.location.href = '../PeripheralType/Update/' + peripheralTypeId;
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
            PeripheralTypeService.Read()
                .then(function (response) {
                    vm.PeripheralTypes = response.data;
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

        function Delete(peripheralTypeId) {
            PeripheralTypeService.Delete(peripheralTypeId)
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