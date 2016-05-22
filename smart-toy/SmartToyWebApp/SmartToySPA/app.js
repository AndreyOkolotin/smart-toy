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
                when('/actions/:toyId', {
                    templateUrl: '/Templates/Actions.html',
                    controller: 'ActionsCtrl'
                }).
                when('/storiesAndSongs/:toyId', {
                    templateUrl: '/Templates/StoriesAndSongs.html',
                    controller: 'StoriesAndSongsCtrl'
                }).
                when('/games/:toyId', {
                    templateUrl: '/Templates/Games.html',
                    controller: 'GamesCtrl'
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
                when('/store/actions', {
                     templateUrl: '/Templates/StoreActions.html',
                     controller: 'StoreActionsCtrl'
                }).
                when('/store/stories', {
                    templateUrl: '/Templates/StoreStories.html',
                    controller: 'StoreStoriesCtrl'
                }).
                when('/store/songs', {
                    templateUrl: '/Templates/StoreSongs.html',
                    controller: 'StoreSongsCtrl'
                }).
                when('/registration', {
                    templateUrl: '/Templates/Registration.html',
                    controller: 'RegistrationCtrl'
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