﻿'use strict';

/* Controllers */

var smartToyControllers = angular.module('smartToyControllers', ['smartToyLocalStorage', 'angular-growl']);


smartToyControllers.controller('HomeCtrl', function ($scope, $routeParams) {
    $scope.ID = $routeParams.Id;
});


smartToyControllers.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, $http, LS) {
    $scope.ok = function () {
        $http.defaults.headers.common.Authorization = "Bearer " + LS.getData();

        $http.post(
            config.WebApiEndPoint + config.Methods.AddNewToy,
            {
                Name: $scope.name,
                Uid: $scope.uid
            })
            .then(
            function (res) {
                console.log("удачно");
                $uibModalInstance.close($scope.name, $scope.uid);
            }, function (e) {
                console.log("неудачно");
                $uibModalInstance.close($scope.name, $scope.uid);
            });
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});


smartToyControllers.controller('RightNavButtonsCtrl', ['$scope', '$location', 'LS', 'growl', '$http', '$uibModal',
  function ($scope, $location, LS, growl, $http, $uibModal) {

      $http.defaults.headers.common.Authorization = "Bearer " + LS.getData();

      $http.get(config.WebApiEndPoint + config.Methods.CountOfToys).then(
          function (res) {
              console.log(res);
              $scope.toysCount = "Всего у вас " + res.data + " игрушек";
          }, function (e) {
              console.log("error332");
              $scope.toysCount = "";
          });

      $http.get(config.WebApiEndPoint + config.Methods.Toys).then(
          function (res) {
              console.log(res);
              $scope.toys = res.data;
          }, function (e) {
              console.log("error332");
              $scope.toys = [];
          });

      $scope.buttonText = function() {
          var token = LS.getData();
          return token ? 'Sign Out' : 'Sign In';
      }

      $scope.isLogedIn = function() {
          var token = LS.getData();
          return !!token;
      }

      $scope.buttonClick = function () {
          if (!LS.getData()) {
              $location.path('/signin');
          } else {
              LS.setData("");
              growl.success("You are signed out");
              $location.path('/main');
          }
      }

      $scope.openModal = function () {

          var modalInstance = $uibModal.open({
              animation: false,
              templateUrl: 'myModalContent.html',
              controller: 'ModalInstanceCtrl',
              resolve: {
                  items: function () {
                      return $scope.items;
                  }
              }
          });

          modalInstance.result.then(function (selectedItem) {
              
          }, function () {
              console.log("modal canceled");
          });
      };

  }]);

smartToyControllers.controller('InfoAboutToyCtrl', ['$scope', '$http', 'LS',
  function ($scope, $http, LS) {

      $http.defaults.headers.common.Authorization = "Bearer " + LS.getData();

      $http.get(config.WebApiEndPoint + config.Methods.Info).then(
        function (res) {
            $scope.version = res.data.SoftwareVersion;
            $scope.battery = res.data.Battery;
            $scope.temperature = res.data.Temperature;
        }, function (e) {
            console.log(e);
        });

      //$.ajax(
      //    config.WebApiEndPoint + config.Methods.Info,
      //    {
      //        method: "GET",
      //        headers: { "Authorization": "Bearer " + localStorage.SmartToyWebApiToken },
      //        success: function (res) {
      //            $scope.version = res.data.SoftwareVersion;
      //            $scope.battery = res.data.Battery;
      //            $scope.temperature = res.data.Temperature;
      //        }
      //    }
      //);
  }]);

smartToyControllers.controller('SignInCtrl', ['$scope', '$http', '$location', 'LS', 'growl',
    function($scope, $http, $location, LS, growl) {
        $scope.http = $http;
        $scope.password = "";
        $scope.login = "";
        $scope.buttonClick = function() {
            $.post(
                    config.TokenEndPoint,
                    {
                        grant_type: "password",
                        username: $scope.login,
                        password: $scope.password
                    }
                ).done(function (a) {
                    console.log("Токен пришел");
                    LS.setData(a.access_token);
                    $location.path('/home');
                    growl.success("text");
                })
                .fail(function() {
                    growl.error("error");
                });

        }
    }
  ]);