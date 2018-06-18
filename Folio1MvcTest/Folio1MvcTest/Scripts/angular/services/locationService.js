(function () {
	angular.module('app').factory('locationService', ['$resource', 'toaster', locationService]);

	function locationService($resource, toaster) {
		var dataFactory = {};

		dataFactory.getLocations = function (func) {
			$resource('api/Location/Get').get({}, function (data) {
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