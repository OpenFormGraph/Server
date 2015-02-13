angular.module('ofgMobile')
    .controller('QuestionTemplateCtrl', [
        '$http', '$scope', 'FormTemplateService',
        function ($http, $scope, formTemplateService) {
            var self = this;

            self.data = {};
            self.questionTypes = {};

            self.getQuestionTypes = function () {
                self.questionTypes = [
                    { "Name": "Boolean", "Value": "boolean" },
                    { "Name": "Date", "Value": "date" },
                    { "Name": "Date and Time", "Value": "datetime" },
                    { "Name": "Multi Pick", "Value": "multipick" },
                    { "Name": "Number", "Value": "number" },
                    { "Name": "Photo", "Value": "photo" },
                    { "Name": "Single Pick", "Value": "singlepick" },
                    { "Name": "Text", "Value": "text" },
                    { "Name": "Time", "Value": "time" }
                ];
            };

            self.getQuestionTypes();
        }
    ]);