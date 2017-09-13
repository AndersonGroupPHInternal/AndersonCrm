(function () {
    'use strict';

    angular
    .module('App')
    .controller('CompanyController', CompanyController);

    CompanyController.$inject = ['CompanyService', '$window'];

    function CompanyController(CompanyService,$window) {
        var vm = this;
        
        vm.Company;

        vm.Companies = [];

        vm.List = List;
        vm.Create = Create;
        vm.CreateModal = CreateModal;
        vm.Update = Update;
        vm.UpdateModal = UpdateModal;
        vm.Delete = Delete;
        vm.Details = Details;
        
        function Create() {
            CompanyService.Create(vm.Company)
            .then(function (response) {
                List();
                angular.element('#CompanyModal').modal('hide');

                new PNotify({
                    title: 'Success',
                    text: 'Company Created',
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
                //    hide: false,
                //    addclass: "stack-bottomright"
                //});

            });
        }

        function CreateModal(company) {
            vm.Company = {
                CompanyId: 0,
                CompanyName: '',
                CompanyColor: 'ffffff',
            };
        }

        function List() {
            CompanyService.List()
            .then(function (response) {
                vm.Companies = response.data;
            })
            .catch(function (data, status) {
                //new PNotify({
                //    title: 'Error',
                //    text: 'There was an error on loading the list',
                //    type: 'error',
                //    hide: false,
                //    addclass: "stack-bottomright"
                //});

            });
        }

        function Update() {
            CompanyService.Update(vm.Company)
            .then(function (response) {
                List();
                angular.element('#CompanyModal').modal('hide');
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

        function UpdateModal(company) {
            vm.Company = angular.copy(company);
        }

        function Delete(company) {
            CompanyService.Delete(company)
                .then(function (response) {
                    List();
                })
                .catch(function (response) {
                });
        }
        function Details(company) {
                $window.location = '/Company/Details/' + company.CompanyId
            }
        
            

    }
})();