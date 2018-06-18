(function () {
  angular.module('app').factory('studentService', ['$resource', 'toaster', studentService]);

  function studentService($resource, toaster) {
    var dataFactory = {};

    dataFactory.getstudents = function (func) {
      $resource('api/student/Get').get({}, function (data) {
        func(data);
      }, genericError);
    };

    dataFactory.save = function (newEntity, func) {
      var body = newEntity;
      $resource('api/student/Save').save({}, body, function (data) {
        func(data);
      }, genericError);
    };

    dataFactory.update = function (newEntity, func) {
      var body = newEntity;
      $resource('api/student/update').save({}, body, function (data) {
        func(data);
      }, genericError);
    };

    dataFactory.delete = function (entityId, func) {
      $resource('api/student/remove').get({ id: entityId }, function (data) {
        func(data);
      }, genericError);
    };
    //-------------------- Private Helper methods ----------------------
    function genericError(error) {
      toaster.error({ body: "Operation Failed !" });
    }

    return dataFactory;
  }
})();