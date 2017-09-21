(function () {
    'use strict';

    angular
        .module('App')
        .controller('PeripheralHistoryController', PeripheralHistoryController);

    PeripheralHistoryController.$inject = ['PeripheralHistoryService', '$window'];

    function PeripheralHistoryController(PeripheralHistoryService, $window) {
        var vm = this;

        vm.PeripheralHistory;

        vm.PeripheralHistories = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateModal = CreateModal;
        vm.Update = Update;
        vm.UpdateModal = UpdateModal;
        vm.Delete = Delete;
        vm.Details = Details;
        vm.InitialiseDate = InitialiseDate;

        function Create() {
            PeripheralHistoryService.Create(vm.PeripheralHistory)
                .then(function (response) {
                    List();
                    angular.element('#PeripheralHistoryModal').modal('hide');

                    new PNotify({
                        title: 'Success',
                        text: 'Asset History Created',
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

        function CreateModal(peripheralhistory) {
            vm.PeripheralHistory = {
                PeripheralHistoryId: 0,
                PeripheralId: '',
                EmployeeId: '',
                Date: '',
            };
        }

        function InitialiseDate(date) {
            vm.PeripheralHistory = {
                Date: date,
                PeripheralHistoryId: 0,
                PeripheralId: '',
                EmployeeId: '',
                Date: date,
            };
        }

        function List() {
            PeripheralHistoryService.List()
                .then(function (response) {
                    vm.PeripheralHistories = response.data;
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
            PeripheralHistoryService.Update(vm.PeripheralHistory)
                .then(function (response) {
                    List();
                    angular.element('#PeripheralHistoryModal').modal('hide');
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

        function UpdateModal(peripheralhistory) {   
            vm.PeripheralHistory = angular.copy(peripheralhistory);
        }

        function Delete(peripheralhistory) {
            PeripheralHistoryService.Delete(peripheralhistory)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }
        function Details(peripheralhistory) {
            $window.location = '/PeripheralHistory/Details/' + peripheralhistory.PeripheralHistoryId
        }

    }
})();