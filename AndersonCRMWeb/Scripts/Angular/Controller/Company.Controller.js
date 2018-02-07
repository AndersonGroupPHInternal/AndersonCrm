(function () {
    'use strict';

    angular
        .module('App')
        .controller('CompanyController', CompanyController);

    CompanyController.$inject = ['$filter', '$window', 'CompanyService'];

    function CompanyController($filter, $window, CompanyService) {
        var vm = this;

        vm.CompanyId;

        vm.Company;

        vm.Companies = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;
        vm.InitialiseDropdown = InitialiseDropdown;

        vm.Delete = Delete;
        
        function GoToUpdatePage(companyId) {
            $window.location.href = '../Company/Update/' + companyId;
        } 

        function Initialise() {
            // vm.CompanyId = companyId;
            Read();
           
        }
        

        function InitialiseDropdown(companyId) {
            vm.CompanyId = companyId;
            Read();
        } 

        function Read() {
            CompanyService.Read()
                .then(function (response) {
                    vm.Companies = response.data;
                    if (vm.CompanyId)
                        UpdateCompany();
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

        function UpdateCompany() {
            vm.Company = $filter('filter')(vm.Companies, { CompanyId: vm.CompanyId })[0];
        }


        function Delete(companyId) {
            var conf = window.confirm("Are you sure you want to delete?");
            if (conf == true) {
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
            else { return; false }
        }

    }
})();