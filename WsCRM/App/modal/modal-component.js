angular.
  module('crmModal').
  run(function(editableOptions) {
      editableOptions.theme = 'bs3'; // xeditable
  }).
  component('cModal', {
      templateUrl: 'App/modal/modal.html',
      controller: function CModalController($scope, $rootScope,$timeout, utils) {
          var ws = this;
          $scope.formShown=false;
          $scope.modalOption = {};
          $scope.modalData = [];

          
          // data is a object array
          $scope.$on('showModelEvent', function (event, data) {
              $scope.modalData = data[0];
              $scope.modalOption = data[1];
              if ($scope.modalOption.action !== 'index') {
                  $timeout(function () {
                      angular.element('#show-form-button').triggerHandler('click');
                      $scope.formShown = true;
                  });
              } else if ($scope.formShown == true) {
                  $timeout(function () {
                      angular.element('#cancel-form-button').triggerHandler('click');
                      $scope.formShown = false;
                  });
              }
          });

          $scope.modalEdit = function () {
              $scope.formShown = true;
          };

          $scope.saveModal = function (data) {
              var uri = ws.modalOption.controller + '/' + ws.modalOption.action;
              if($scope.modalOption.id) {
                  uri += '/' + $scope.modalOption.id;
                  data[$scope.modalOption.idVariable] = $scope.modalOption.id;
              }

              utils.postApiData(uri, data).then(function () {
                  $scope.$emit('modelDone', [orderToModal, modalOption]); //通知上层component,已经完成保存，请刷新数据
              });
          }
         
      },
  });