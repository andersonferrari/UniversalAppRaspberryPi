(function () {
    //'use strict';

    angular
        .module('appx')
        .controller('controller', ['$scope', '$http', controller]);

    //controller.$inject = ['$scope'];

    function controller($scope, $http) {
        alert("11111!");
        $scope.title = 'controller';
        $http.get('/api/testes').success(function (data) {
            $scope.testes = data;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
        });
        activate();
        function activate() { }

        $scope.alerta = function () {
            alert("Alerta teste!");
        }

    }
})();
