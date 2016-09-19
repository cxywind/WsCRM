angular.
  module('crmOrders').
  run(function(editableOptions) {
      editableOptions.theme = 'bs3'; // xeditable
  }).
  component('orderList', {
      templateUrl: 'App/orders/order.html',
      controller: function OrderListController($scope, $rootScope, utils) {
          var baseUri = 'orders/';
          var ws = this;
          $scope.orders = {};
          $scope.orderStatus = [
              { value: 0, text: '只付定金' },
              { value: 1, text: '已付全款' },
              { value: 2, text: '无效' },
              { value: 3, text: '退款' },
              { value: 4, text: '过期' }
          ];

          $scope.marketingWay = [
              {value:0, text:'FOB'},
              {value:1, text:'Baidu'},
              {value:2, text:'老客户'},
              {value: 3, text: '朋友介绍'},
              {value:4, text:'其它'}
          ];

          $scope.getOrders = function () {
              utils.getApiData(baseUri).then(function (data) {
                  $scope.orders = data;
                  //设置日期
                  utils.setObjectDateToJS($scope.orders, 'OrderDate');
                  //设置订单状态
                  utils.indexToAttribute($scope.orders, 'OrderStatus', $scope.orderStatus);
                  //设置客户来源
                  utils.indexToAttribute($scope.orders, 'MarketingWay', $scope.marketingWay);
                  //设置是否显示form
                  $scope.orders.forEach(function (order) {
                      order.created = true;
                  });
              });
          };

          //Prepare one single order value to Modal
          $scope.toModalObject = function (order) {
              var orderToModal = [
                      { title: 'Domain', variableName: 'Domain', value: (order ?  order.Domain : ''), type: 'text', validateon: { minLen:2, errorText:'* 请输入正确的域名' } },
                      {title: 'Email', variableName: 'Email', value: (order ?  order.Email : ''), type: 'email' },
                      {title: 'Phone', variableName: 'Phone', value: (order ?  order.Phone : ''), type: 'tel' },
                      { title: 'QQ', variableName: 'QQ', value: (order ?  order.QQ : ''), type: 'text', validateon: { minLen: 2, maxLen:10, errorText: '* 请输入正确的QQ' } },
                      {title: 'Order Status', variableName: 'OrderStatus', value: (order ?  order.OrderStatus : 0), type: 'select', selectEnum: $scope.orderStatus },
                      {title: 'Order Date', variableName: 'OrderDate', value: (order ?  order.OrderDate :  new Date()), type: 'date' },
                      { title: 'Marketing Way', variableName: 'MarketingWay', value:  (order ?  order.MarketingWay : 0) , type: 'select', selectEnum: $scope.marketingWay },
                      {title:'Product Name', variableName: 'ProductName', value:  (order ?  order.ProductName :  ''), type: 'text' },
                      { title: 'Description', variableName: 'Description', value:  (order ?  order.Description :  ''), type: 'textarea' }
              ];
              
              return orderToModal;
          };

          //Prepare one single order value to Modal
          $scope.createOrder = function (order) {

              var modalOption = {
                  modalTitle: 'Create Order',
                  controller: 'orders', 
                  action: 'create',
                  idVariable: 'OrderId', 
              };

              $scope.$broadcast('showModelEvent', [$scope.toModalObject(order), modalOption]);
          };
          
          $scope.showDetail = function (id) {
              var orderIndex = utils.findObjectIndexInArray($scope.orders, 'OrderId', id);
              var order = $scope.orders[orderIndex];


              var modalOption = {
                  modalTitle: 'Order Detail',
                  controller: 'orders', // corrsponding to .net controller
                  action: 'index', // index, edit and create, corrsponding to .net backend action
                  idVariable: 'OrderId', // Id variale 
                  id: id// the id of the entity, when create new, keep empty
              };

              $scope.$broadcast('showModelEvent', [$scope.toModalObject(order), modalOption]);
          };
         
          //$scope.deleteProduct = function (id) {
          //    alert("您没有删除产品的权限");
          //    //var uri = baseUri + 'delete/' + id;
          //    //utils.postApiData(uri).then(function () {
          //    //     $scope.getProducts();
          //    //});
             
          //}

          $scope.getOrders();

      }
  });