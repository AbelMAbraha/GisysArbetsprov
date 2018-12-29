var app = angular.module("MyApp", []);
app.controller("HomeController", function ($scope, $http) {
    $http.get('/Home/GetConsultants').then(function (d) {
        $scope.consultantInformation = d.data;
    }, function (error) {
        alert('failed');
    }
    )}
);