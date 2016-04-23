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
                when('/settings', {
                    templateUrl: 'Templates/Settings.html',
                    controller: ''
                }).
                when('/about', {
                    templateUrl: '/Templates/About.html',
                    controller: ''
                }).
                when('/home/ggg', {
                    templateUrl: '/Templates/Home.html',
                    controller: 'HomeCtrl'
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