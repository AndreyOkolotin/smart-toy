'use strict';

/* Controllers */

var smartToyControllers = angular.module('smartToyControllers', ['smartToyLocalStorage', 'angular-growl']);


smartToyControllers.controller('HomeCtrl', function ($scope, $routeParams, $http, growl, $rootScope, $location) {
    $scope.deleteToy = function() {
        $http.delete(config.WebApiEndPoint + config.Methods.DeleteToy + '/' + $routeParams.toyId).then(
            function(res) {
                growl.success("Removed");
                $location.path('/main');
                $rootScope.updateToys();
            },
            function(e) {
                growl.success("Error, call system administrator");
            });
    }

    $http.get(config.WebApiEndPoint + config.Methods.Info + '/' + $routeParams.toyId).then(
        function(res) {
            console.log(res);
            $scope.Battery = res.data.Battery;
            $scope.FriendlyName = res.data.FriendlyName;
            $scope.Id = res.data.Id;
            $scope.SoftwareVersion = res.data.SoftwareVersion;
            $scope.Temperature = res.data.Temperature;
            $scope.Type = res.data.Type;
            $scope.Uid = res.data.Uid;
        }, function(e) {
            console.log("error332");
            $scope.Battery = "";
            $scope.FriendlyName = "";
            $scope.Id = "";
            $scope.SoftwareVersion = "";
            $scope.Temperature = "";
            $scope.Type = "";
            $scope.Uid = "";
        });
});

smartToyControllers.controller('SettingsCtrl', function ($scope, $routeParams) {
    $scope.Id = $routeParams.toyId;
    $scope.ageModel = '1';
    $scope.volume = 2;
    $scope.night = false;

    $scope.save = function() {
        
    }

});


smartToyControllers.controller('StoriesAndSongsCtrl', function ($scope, $routeParams, growl, $http) {
    $scope.Id = $routeParams.toyId;

    $http.get(config.WebApiEndPoint + config.Methods.GetStoriesAndSongs).then(
    function (res) {
        console.log(res);
        $scope.songs = res.data;

        if ($scope.songs) {
            $scope.songs = $scope.songs.map(function(a) {
                if (a.StoryOrSong == 0) {
                    a.buttonClass = "info";
                } else {
                    a.buttonClass = "danger";
                }
                return a;
            });
        }
    }, function (e) {
        console.log("error332");
    });


});

smartToyControllers.controller('ActionsCtrl', function ($scope, $routeParams, growl, $http) {
    $scope.Id = $routeParams.toyId;

    $http.get(config.WebApiEndPoint + config.Methods.GetActions).then(
    function (res) {
        console.log(res);
        $scope.actions = res.data;

        if ($scope.actions) {
            $scope.actions = $scope.actions.map(function (a) {
                a.Do = function () {
                    growl.success("Success");
                }
                if (!a.Type) {
                    a.Type = "primary";
                }
                return a;
            });
        }
    }, function (e) {
        console.log("error332");
    });

    
});


smartToyControllers.controller('GamesCtrl', function ($scope, $routeParams, growl, $http) {
    $scope.Id = $routeParams.toyId;

    $http.get(config.WebApiEndPoint + config.Methods.GetGames).then(
    function (res) {
        console.log(res);
        $scope.games = res.data;
    }, function (e) {
        console.log("error332");
    });


});

smartToyControllers.controller('RegistrationCtrl', function ($scope, $routeParams, $http, growl, $location) {
    $scope.buttonClick = function() {
        $http.post(config.WebApiEndPoint + config.Methods.Register,
        {
            UserName: $scope.Login,
            Password: $scope.Password,
            ConfirmPassword: $scope.ConfirmPassword
        }).then(
        function (res) {
            growl.success("Success");
            $location.path('/signin');s
        }, function (e) {
            growl.error(e.data.Message);
        });
    }
});


smartToyControllers.controller('StoreGamesCtrl', function ($scope, $routeParams, $http, growl) {
    $scope.updateGames = function () {
        $http.get(config.WebApiEndPoint + config.Methods.GetStoreGames).then(
            function (res) {
                console.log(res);
                $scope.games = res.data;
            }, function (e) {
                console.log("error332");
            });
    }

    $scope.Buy = function (actionId) {
        $http.post(config.WebApiEndPoint + config.Methods.BuyStory + "/" + actionId).then(
        function (res) {
            console.log(res);
            growl.success("Success");
            $rootScope.updateMoney();
            $scope.updateGames();
        }, function (e) {
            console.log("error332");
            growl.error("Error");
            $rootScope.updateMoney();
            $scope.updateGames();
        });
    }

    $scope.updateGames();
});

smartToyControllers.controller('StoreStoriesCtrl', function ($scope, $routeParams, $http, growl, $rootScope) {

    
    $scope.updateStories = function () {
        $http.get(config.WebApiEndPoint + config.Methods.GetStoreStories).then(
            function (res) {
                console.log(res);
                $scope.stories = res.data;
            }, function (e) {
                console.log("error332");
            });
    }

    $scope.Buy = function (actionId) {
        $http.post(config.WebApiEndPoint + config.Methods.BuyStory + "/" + actionId).then(
        function (res) {
            console.log(res);
            growl.success("Success");
            $rootScope.updateMoney();
            $scope.updateStories();
        }, function (e) {
            console.log("error332");
            growl.error("Error");
            $rootScope.updateMoney();
            $scope.updateStories();
        });
    }

    $scope.updateStories();
});


smartToyControllers.controller('StoreSongsCtrl', function ($scope, $routeParams, $http, growl, $rootScope) {


    $scope.updateSongs = function () {
        $http.get(config.WebApiEndPoint + config.Methods.GetStoreSongs).then(
            function (res) {
                console.log(res);
                $scope.songs = res.data;
            }, function (e) {
                console.log("error332");
            });
    }

    $scope.Buy = function (actionId) {
        $http.post(config.WebApiEndPoint + config.Methods.BuySong + "/" + actionId).then(
        function (res) {
            console.log(res);
            growl.success("Success");
            $rootScope.updateMoney();
            $scope.updateSongs();
        }, function (e) {
            console.log("error332");
            growl.error("Error");
            $rootScope.updateMoney();
            $scope.updateSongs();
        });
    }

    $scope.updateSongs();
});


smartToyControllers.controller('StoreActionsCtrl', function ($scope, $routeParams, $http, growl, $rootScope) {
    $scope.updateActions = function() {
        $http.get(config.WebApiEndPoint + config.Methods.GetStoreActions).then(
            function(res) {
                console.log(res);
                $scope.actions = res.data;
            }, function(e) {
                console.log("error332");
            });
    }

    $scope.Buy = function(actionId)
    {
        $http.post(config.WebApiEndPoint + config.Methods.BuyAction + "/" + actionId).then(
        function (res) {
            console.log(res);
            growl.success("Success");
            $rootScope.updateMoney();
            $scope.updateActions();
        }, function (e) {
            console.log("error332");
            growl.error("Error");
            $rootScope.updateMoney();
            $scope.updateActions();
        });
    }

    $scope.updateActions();
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


smartToyControllers.controller('RightNavButtonsCtrl', ['$scope', '$location', 'LS', 'growl', '$http', '$uibModal', '$rootScope',
  function ($scope, $location, LS, growl, $http, $uibModal, $rootScope) {
      

      $scope.selectedToy = -1;

      $scope.setSelectedToy = function (id) {
          $scope.selectedToy = id;
      }

      $http.defaults.headers.common.Authorization = "Bearer " + LS.getData();

      $rootScope.updateMoney = function() {
          $http.get(config.WebApiEndPoint + config.Methods.Money).then(
              function(res) {
                  console.log(res);
                  $scope.money = res.data;
              }, function(e) {
                  console.log("error332");
                  $scope.money = "";
              });
      }

      $scope.updateToys = function () {
          $http.get(config.WebApiEndPoint + config.Methods.Toys).then(
              function (res) {
                  console.log(res);
                  $scope.toys = res.data;
              }, function (e) {
                  console.log("error332");
                  $scope.toys = [];
              });
      }


      $scope.buttonText = function () {
          var token = LS.getData();
          return token ? 'Sign Out' : 'Sign In';
      }

      $scope.isLogedIn = function () {
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

          modalInstance.result.then(function () {
              $scope.updateToys();
          }, function () {
              console.log("modal canceled");
          });
      };


      $scope.updateToys();


      $rootScope.updateToys = function () {
          $scope.updateToys();
      }

      $rootScope.updateMoney();
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

smartToyControllers.controller('SignInCtrl', ['$scope', '$http', '$location', 'LS', 'growl','$rootScope',
    function ($scope, $http, $location, LS, growl, $rootScope) {
        $scope.http = $http;
        $scope.password = "";
        $scope.login = "";
        $scope.buttonClick = function () {
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
                    $rootScope.updateToys();
                })
                .fail(function (e) {
                    console.log(e);
                    growl.error(e.statusText);
                });

        }
    }
]);