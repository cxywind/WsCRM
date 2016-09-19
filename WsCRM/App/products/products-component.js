angular.
  module('crmProducts').
  run(function(editableOptions) {
      editableOptions.theme = 'bs3'; // xeditable
  }).
  component('productList', {
      templateUrl: 'App/products/product.html',
      controller: function ProductListController($scope, utils) {
          var baseUri = 'products/';
          var ws = this;
          $scope.products = {};
          ws.editOrCreate = '';

          //判断产品是否已经存在
          ws.isProductCreated = function (data) {
              var productIndex = utils.findObjectIndexInArray($scope.products, 'ProductId', data.ProductId);
              return $scope.products[productIndex].created;
          };

          $scope.getProducts = function () {
              utils.getApiData(baseUri).then(function (data) {
                  $scope.products = data;
                  //设置是否显示form
                  $scope.products.forEach(function (product) {
                      product.created = true;
                  });
              });
          };

          $scope.saveProduct = function (data, id) {
              data.ProductId = id;
              ws.editOrCreate = ws.isProductCreated(data) ? 'edit' : 'create';
              var uri = baseUri + ws.editOrCreate;
              utils.postApiData(uri, data).then(function () {
                  $scope.getProducts();
              });
          };

          $scope.addProduct = function () {
              var newProduct = {};
              ws.editOrCreate = 'create';
              $scope.products.unshift(newProduct);
          };

          $scope.deleteProduct = function (id) {
              //alert("您没有删除产品的权限");
              var uri = baseUri + 'delete/' + id;
              utils.postApiData(uri).then(function () {
                   $scope.getProducts();
              });

          };

          $scope.cancelEmptyProduct = function () {
              if (ws.editOrCreate === 'create') {
                  $scope.products.shift();
              }
          };

          $scope.checkProductName = function (data) {
              if (!data || data.length<2) {
                  return "产品名字不能为空, 且需要大于2个字符";
              }
          };

          $scope.checkPrice = function (data) {
              if (!data) {
                  return '请输入价格';
              }
          };

          $scope.checkRenewPrice = function (data) {
              if (!data) {
                  return '请输入续费价格';
              }
          };

          $scope.getProducts();
      }
  });