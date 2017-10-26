(function () {
    'use strict';

    angular
        .module('App')
        .controller('CompanyController', CompanyController);

    CompanyController.$inject = ['$window', 'CompanyService'];

    function CompanyController($window, CompanyService) {
        var vm = this;

        vm.Employees = [];
        vm.Companys = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;
        
        function GoToUpdatePage(companyId) {
            $window.location.href = '../Company/Update/' + companyId;
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
            CompanyService.Read()
                .then(function (response) {
                    vm.Companys = response.data;
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

        function Delete(companyId) {
            CompanyService.Delete(companyId)
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