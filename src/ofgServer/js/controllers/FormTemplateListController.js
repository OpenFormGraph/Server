angular.module('ofgMobile')
    .controller('FormTemplateListCtrl', [
        '$http', '$scope', 'FormTemplateService',
        function ($http, $scope, formTemplateService) {
            var self = this;

            self.data = {};

            self.getFormTemplates = function () {
                formTemplateService.getFormTemplates()
                    .then(function (result) {
                        self.data.FormTemplates = result;
                    });
            };

            self.getFormTemplates();
        }
    ]);