'use strict';

angular.
  module('wsCRM').
  config(['$locationProvider', '$routeProvider', '$httpProvider',
    function config($locationProvider, $routeProvider, $httpProvider) {
        //  $locationProvider.hashPrefix('!');

        $routeProvider.
          when('/', { template: '<home></home>' }).
          when('/products', { template: '<product-list></product-list>' }).
          when('/orders', { template: '<order-list></order-list>' }).
          otherwise('/');

        //disable cache in following code
        if (!$httpProvider.defaults.headers.get) {
            $httpProvider.defaults.headers.get = {};
        }

        //disable IE ajax request caching
        $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
        // extra
        $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
        $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';


    }
  ]);
