(function () {
    'use strict';
    var app = angular.module('angularBookController', ['kendo.directives']);

    app.controller('bookController', ['$scope', '$http', bookController]);
    
    function fillAuthors($scope, $http) {
        $http.get('/api/Author/GetAll').success(function (data) {
            $scope.authorsInfo = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });
    }

    app.filter('unsafe', function ($scope) {
        return function (val) {
            return $scope.trustAsHtml(val);
        };
    });

    function bookController($scope, $http) {
        $scope.loading = true;
        $scope.addMode = false;
        $scope.activeTabId = 0;
        $scope.searchText = "";
        
        fillAuthors($scope, $http);

        $http.get('/api/Book/GetAll').success(function (data) {
            $scope.books = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "An Error has occured while loading books!";
            $scope.loading = false;
        });

        $scope.toggleEdit = function () {
            this.book.editMode = !this.book.editMode;
        };

        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/Book/Manage', this.newbook).success(function (data) {
                $scope.addMode = false;
                $scope.books.push(data);
                fillAuthors($scope, $http);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An error has occured while creating a book!";
                $scope.error = data.ModelState.error;
                $scope.loading = false;
            });
        };

        $scope.save = function () {
            $scope.loading = true;
            var frien = this.book;
            $http.post('/api/Book/Manage', frien).success(function (data) {
                frien.editMode = false;
                fillAuthors($scope, $http);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An error has occured while saving a book!";
                $scope.loading = false;
            });
        };

        $scope.deletebook = function () {
            $scope.loading = true;
            var Id = this.book.Id;
            $http.delete('/api/Book/Delete' + Id).success(function (data) {
                $.each($scope.books, function (i) {
                    if ($scope.books[i].Id === Id) {
                        $scope.books.splice(i, 1);
                        return false;
                    }
                });
                fillAuthors($scope, $http);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An error has occured while deleting a book!";
                $scope.loading = false;
            });
        };
    }
})();