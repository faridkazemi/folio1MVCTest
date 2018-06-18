(function () {
  angular.module('app').controller('homeCtrl', ['$scope', 'DTOptionsBuilder', 'classService', 'studentService', '$uibModal',
    function ($scope, DTOptionsBuilder, classService, studentService, $modal) {
			$scope.DataStatus = 'Loading';
			$scope.dtOptions = DTOptionsBuilder.newOptions()
				.withOption('order', [1, 'asc']);

			$scope.SetSelectedClass = setSelectedClass;
			$scope.AddNewClass = addNewClass;
			$scope.Save = save;
			$scope.Cancel = cancel;
			$scope.UpdateClass = updateClass;
      $scope.DeleteCLass = deleteClass;
      $scope.AddNewStudent = addNewStudent;
      $scope.SaveStudent = saveStudent;
      $scope.CancelStudentPopup = cancelStudentPopup;

			getClasses();
		//----------------------  Implementation  ---------------------
		function getClasses() {

			classService.getClasses(function (data) {
				$scope.model = data;
				$scope.DataStatus = "Loaded";
			});
			}

			function setSelectedClass(selectedClass) {

				$scope.selectedClass = selectedClass;
			}
			function addNewClass(ev) {
        $scope.editingClass = {};
			  $scope.popupTitle = "You are adding a new class";
			  openClassModal(ev);
			}

		  function openClassModal(ev) {
		    $scope.editPopup = $modal.open({

		      scope: $scope,
		      templateUrl: 'template/editClass.html',
		      parent: angular.element(document.body),
		      targetEvent: ev,
		      clickOutsideToClose: true,
		      fullscreen: false,
		      windowClass: 'app-modal-window'

		    });
		  }

      function cancel() {
        $scope.editPopup.close();
      }

			function save() {
				if (!$scope.editingClass.Id) {
					$scope.DataStatus = 'Loading';
					$scope.editingClass = {
						Id: 0,
						Name: $scope.editingClass.Name,
						LocationId: $scope.editingClass.LocationId,
						TeacherId: $scope.editingClass.TeacherId,
						Location: null,
						Teacher: null,
						Students: null
					};

					classService.save($scope.editingClass, function (data) {
						$scope.$dismiss('cancel');
						$scope.DataStatus = 'Loaded';
						location.reload();

					});
				}
				else {
					$scope.DataStatus = 'Loading';
					classService.update($scope.editingClass, function (data) {
						$scope.$dismiss('cancel');
						$scope.DataStatus = 'Loaded';
						location.reload();

					});
				}

			}

      function updateClass(ev, selectedClass) {
        $scope.popupTitle = "You are editing " + selectedClass.Name + "class.";
				$scope.editingClass = selectedClass;
			  openClassModal(ev);
			}

			function deleteClass (selectedClass){
				classService.delete(selectedClass.Id, function () {
						//sweetAlert({
						//title: "Done!",
						//text: "The new Class has been deleted successfully",
						//type: "success"
      //      });
				  location.reload();
				});
      }

      function addNewStudent() {
        $scope.studentPopupTitle = "You are adding a new student in class " + $scope.selectedClass.Name;
        studentService.getstudents(function(data) {
          $scope.model.students = data.StudentsList;
          $scope.model.classes = data.ClassesList;
          $scope.editingStudent = { ClassId: $scope.selectedClass.Id}
          opentudentModal();
        });
		  }

		  function opentudentModal(ev) {
		    $scope.studentPopup = $modal.open({
		      scope: $scope,
		      templateUrl: 'template/editStudent.html',
		      parent: angular.element(document.body),
		      targetEvent: ev,
		      clickOutsideToClose: true,
		      fullscreen: false,
		      windowClass: 'app-modal-window'

		    });
      }

      function saveStudent(student) {
        studentService.save(student);
      }

      function cancelStudentPopup() {
        $scope.studentPopup.close();
      }


    }]);
})();