(function () {
	angular.module('app').factory('classService', ['$resource', 'toaster', classService]);

	function classService($resource, toaster) {
		var dataFactory = {};

		dataFactory.getClasses = function (func) {
			$resource('api/Class/Get').get({}, function (data) {
				func(data);
			}, genericError);
		};

		dataFactory.save = function (newEntity, func) {
			var body = newEntity;
			$resource('api/Class/Save').save({},body, function (data) {
				func(data);
			}, genericError);
		};

		dataFactory.update = function (newEntity, func) {
			var body = newEntity;
			$resource('api/Class/update').save({}, body, function (data) {
				func(data);
			}, genericError);
		};

		dataFactory.delete = function (entityId,func) {
			$resource('api/Class/remove').get({ id: entityId}, function (data) {
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