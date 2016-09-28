(function () {
    function formValidation() {
        return {
            require: 'ngModel',
            link: function (scope, elm, attrs, ctrl) {

                ctrl.$validators.formValidation = function (modelValue, viewValue) {
                    // the defalut value is form-validation when the validation is not set
                    if (attrs.formValidation === 'form-validation') {
                        return true;
                    }
                    var valParam = angular.fromJson(attrs.formValidation);
                    var error = false;

                    if (!error && valParam.required) {
                        error = modelValue.length > 0 ? false : true;
                    }

                    if (!error && valParam.minLen) {
                        error = modelValue.length >= valParam.minLen ? false : true;
                    }

                    if (!error && valParam.maxLen) {
                        error= modelValue.length <= valParam.maxLen ? false : true;
                    }

                    return error ? false: true;
                };
            }
        }

    }

    angular.module('wsCRM').directive("formValidation", formValidation);

})();