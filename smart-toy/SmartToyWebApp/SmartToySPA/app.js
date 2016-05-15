angular.module("smartToyApp", ['ngRoute', 'smartToyControllers', 'smartToyLocalStorage', 'angular-growl', 'ui.bootstrap'])
    .config([
        '$routeProvider',
        '$locationProvider',
        'growlProvider',
        function ($routeProvider, $locationProvider, growlProvider) {
            $routeProvider.
                when('/', {
                    templateUrl: 'Templates/Main.html',
                    controller: ''
                }).
                when('/main', {
                    templateUrl: 'Templates/Main.html',
                    controller: ''
                }).
                when('/signin', {
                    templateUrl: 'Templates/SignIn.html',
                    controller: 'SignInCtrl'
                }).
                when('/info', {
                    templateUrl: 'Templates/InfoAboutToy.html',
                    controller: 'InfoAboutToyCtrl'
                }).
                when('/settings/:toyId', {
                    templateUrl: '/Templates/Settings.html',
                    controller: 'SettingsCtrl'
                }).
                when('/about', {
                    templateUrl: '/Templates/About.html',
                    controller: ''
                }).
                when('/home/:toyId', {
                    templateUrl: '/Templates/Home.html',
                    controller: 'HomeCtrl'
                }).
                when('/store/games', {
                    templateUrl: '/Templates/StoreGames.html',
                    controller: 'StoreGamesCtrl'
                }).
                otherwise({
                    redirectTo: '/main'
                });

            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });

            growlProvider.globalPosition('bottom-right');
            growlProvider.globalDisableCloseButton(true);
            growlProvider.globalTimeToLive(4000);
        }
    ]);