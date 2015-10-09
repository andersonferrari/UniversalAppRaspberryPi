(function () {
    'use strict';

    angular
        .module('appx')
        .controller('testeController', ['$location', '$scope', testeController]);

    //testeController.$inject = ['$location']; 


    function testeController($location, $scope) {
        /* jshint validthis:true */
        alert("11111!");
        var vm = this;
        vm.title = 'testeController';

        activate();

        function activate() { }

        $scope.alerta = function () {
            alert("Alerta teste!");
        }
    }
})();
