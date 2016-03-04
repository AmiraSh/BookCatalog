(function () {
    'use strict';
    var app = angular.module('angularAuthorController', []);

    app.controller('authorController', ['$scope', '$http', authorController]);

    function authorController($scope, $http) {
        $scope.loading = true;
        $scope.addMode = false;
        $scope.searchText = "";
        $scope.filteredAuthors = [];
        $scope.authors = [];

        $http.get('/api/Authors/GetAuthors').success(function (data) {
            $scope.authors = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading authors!";
            $scope.loading = false;
        });

        $scope.toggleEdit = function () {
            this.author.editMode = !this.author.editMode;
        };

        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/Authors/ManageAuthor', this.newauthor).success(function (data) {
                $scope.addMode = false;
                $scope.authors.push(data);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An error has occured while creating an author!";
                $scope.error = data.ModelState.error;
                $scope.loading = false;
            });
        };

        $scope.save = function () {
            $scope.loading = true;
            var frien = this.author;
            $http.post('/api/Authors/ManageAuthor', frien).success(function (data) {
                frien.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An error has occured while saving an author!";
                $scope.loading = false;
            });
        };

        $scope.deletebook = function () {
            $scope.loading = true;
            var Id = this.author.Id;
            $http.delete('/api/Authors/DeleteAuthor' + Id).success(function (data) {
                $.each($scope.authors, function (i) {
                    if ($scope.authors[i].Id === Id) {
                        $scope.authors.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An error has occured while deleting an author!";
                $scope.loading = false;
            });
        };

        //pagination
        $scope.filteredTodos = [];
        $scope.currentPage = 1;
        $scope.numPerPage = 10;
        $scope.maxSize = 5;
        
        $scope.$watch('currentPage + numPerPage', function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage), end = begin + $scope.numPerPage;
            $scope.filteredAuthors = $scope.authors.slice(begin, end);
        });
    }
})();