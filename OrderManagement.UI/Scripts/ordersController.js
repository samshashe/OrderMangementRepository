
angular.module("app", []).controller("ordersController", function ($scope, $http) {
    $scope.itemsPerPage = 5;
    $scope.currentPage = 0;
    $scope.orders = [];

    $scope.next = function () {
        $scope.currentPage = $scope.currentPage + 1;
        getCurrentData();
    };

    $scope.previous = function () {
        $scope.currentPage = $scope.currentPage - 1;
        getCurrentData();
    };

    var getCurrentData = function() {
        $http.get("http://sampower/OrderManagementApi/Api/Order?pageNumber=" + $scope.currentPage)
        .success(function (response) {
            $scope.orders = response;
        }).error(function (response, status, headers, config) {
            // TO: error logging.
        });
    };
    
    getCurrentData();
});

//angular.module("app", []).controller("ordersController", function ($scope) {
//    $scope.itemsPerPage = 5;
//    $scope.currentPage = 0;
//    $scope.items = [];

//    for (var i = 0; i < 50; i++) {
//        $scope.items.push({
//            id: i, name: "name " + i, description: "description " + i
//        });
//    }

//    $scope.prevPage = function () {
//        if ($scope.currentPage > 0) {
//            $scope.currentPage--;
//        }
//    };

//    $scope.prevPageDisabled = function () {
//        return $scope.currentPage === 0 ? "disabled" : "";
//    };

//    $scope.pageCount = function () {
//        return Math.ceil($scope.items.length / $scope.itemsPerPage) - 1;
//    };

//    $scope.nextPage = function () {
//        if ($scope.currentPage < $scope.pageCount()) {
//            $scope.currentPage++;
//        }
//    };

//    $scope.nextPageDisabled = function () {
//        return $scope.currentPage === $scope.pageCount() ? "disabled" : "";
//    };

//});

//angular.module("app", []).filter('offset', function () {
//    return function (input, start) {
//        start = parseInt(start, 10);
//        return input.slice(start);
//    };
//});

