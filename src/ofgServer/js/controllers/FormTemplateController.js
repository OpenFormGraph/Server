angular.module('ofgMobile')
    .controller('FormTemplateCtrl', [
        '$http', '$scope', '$routeParams', '$location', 'FormTemplateService',
        function ($http, $scope, $routeParams, $location, formTemplateService) {
            var self = this;

            self.item = {};
            self.formSubjects = {};

            self.Guid = $routeParams.formtemplateguid;
            self.getFormSubjects = function () {
                formTemplateService.getFormSubjects()
                    .then(function (result) {
                        self.formSubjects = result;
                    });
            };

            self.getFormTemplate = function (guid) {
                formTemplateService.getFormTemplate(guid)
                    .then(function (result) {
                        self.item = result;
                    });
            };

            self.saveFormTemplate = function () {
                self.item.Guid = self.Guid;

                formTemplateService.saveFormTemplate(self.item)
                    .then(function (result) {
                        $location.path("/formtemplates");
                    });
            };

            self.getFormSubjects();

            if (self.Guid != null) {
                self.getFormTemplate(self.Guid);
            }
        }
    ]);
