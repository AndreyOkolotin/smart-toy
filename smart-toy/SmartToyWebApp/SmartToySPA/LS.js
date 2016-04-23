var smartToyLocalStorage = angular.module('smartToyLocalStorage', []);

smartToyLocalStorage.factory("LS", function ($window) {
    return {
        setData: function (val) {
            $window.localStorage && $window.localStorage.setItem('SmartToyWebApiToken', val);
            return this;
        },
        getData: function () {
            return $window.localStorage && $window.localStorage.getItem('SmartToyWebApiToken');
        }
    };
});