(function () {
    'use strict';

    angular
        .module('App')
        .controller('PeripheralController', PeripheralController);

    PeripheralController.$inject = ['$filter','$window', 'PeripheralService'];

    function PeripheralController($window, PeripheralService) {
        var vm = this;

        vm.PeripheralId;

        vm.Peripheral;

        vm.Peripherals = [];


        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;
        
        vm.Delete = Delete;

        function GoToUpdatePage(peripheralId) {
            $window.location.href = '../Peripheral/Update/' + peripheralId;
        }

        function Initialise() {
            Read();
        }

        function InitialiseDropdown(peripheralId) {
            vm.PeripheralId = peripheralId;
            Read();
        }

        function Read() {
            PeripheralService.Read()
                .then(function (response) {
                    vm.Peripherals = response.data;
                    if (vm.PeripheralId)
                        UpdatePeripheral();
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

        function UpdatePeripheral() {
            vm.Peripheral = $filter('filter')(vm.Peripherals, { PeripheralId: vm.PeripheralId })[0];
        }

        function Delete(peripheralId) {
            PeripheralService.Delete(peripheralId)
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