var apihost = "http://localhost:8099/";

app.directive('myContextmenu', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element) {
            element.bind('keydown keypress keyup', function (event) {
                if (event.keyCode == 13) {
                    event.preventDefault();
                }
            });
        }
    };
});

app.controller("receivingcreatectrl", function ($scope, $http, $cookies, $cookieStore, $rootScope, Restful, filterFilter) {
    $scope.products = [];
    $scope.getproduct = function(){
        
        if (!$scope.productid) {
            return false;
        }
        var productid = $scope.productid;
        
        Restful.getProduct(productid, function (data) {
            data[0].calculateqty = 1;
            data[0].discount = 0;
            data[0].finalcost = data[0].cost;
            data[0].discountType = "%";
            $scope.products.push(data[0]);
            $scope.productid = "";
            $('#pid').focus();
            //console.log($scope.products);
        });
    }

    $scope.isNumber = function (n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    

    $scope.keydowncheck = function (e) {
        
        var $this = $(e.target);
        var keycode = e.which;
        //alert(keycode);
        if (keycode == 13) {
            $scope.editrow(e);
        }

        if (keycode != 13 && keycode != 9) {
            if (!$scope.isNumber(e.key) && keycode != 39 && keycode != 8 && keycode != 37) {
                if (!$this.hasClass('qty')) {
                    if (keycode != 110 && keycode != 190) {
                        e.preventDefault();
                        return false;
                    }
                }else {
                    e.preventDefault();
                    return false;
                }
            }
            if (keycode != 39 && keycode != 8 && keycode != 37) {
                $tr = $this.closest('tr');
                $tr.addClass('unsave');
            }
        }
    }

    $scope.editrow = function (e) {
        //console.log(angular.element(e));
        console.log($scope.products);
        
        $tr = $(e.target).closest('tr');
        var index = $tr.attr('tr-index');
        var id = $tr.attr('tr-id');

        var cost = $tr.find('.cost').val();
        var current_price = $tr.find('.current_price').val();
        var qty = $tr.find('.qty').val();
        var discount = $tr.find('.discount').val();

        discountcost = 0;
        if ($scope.products[index].discountType == "%") {
            discountcost = cost * discount / 100;
        } else {
            discountcost = discount;
        }

        finalcost = cost - discountcost;
        $scope.products[index].finalcost = finalcost;

        $scope.products[index].cost = cost;
        $scope.products[index].current_price = current_price;
        $scope.products[index].calculateqty = qty;
        $scope.products[index].discount = discount;

        console.log($scope.products);
        
        if ($tr.hasClass('unsave')) {
            $tr.removeClass('unsave');
            $scope.productid = "";
            $('#pid').focus();
        }

        //var now = this.attr('data-id');
        //$this = angular.element(e).attr('attr');
        //alert(now);

        //$tr = $this.closest('tr');
        //alert($tr.hasClass('unsave'));

        //$tr = $(this).closest('tr');
        //alert($tr.__proto__.find('.cost').val());
        //$tr.removeClass('unsave');

    }

    $scope.deleterow = function (index) {
        $scope.products.splice(index, 1);
        return false;
    }

    $scope.total = 0;
    $scope.sumtotal = 0;
    $scope.transportCost = 0;
    $scope.otherFees = 0;

    $scope.overallTax = 0;
    $scope.overallTaxType = "%";
    $scope.overallDiscount = 0;
    $scope.overallDiscountType = "%";

    $scope.getTotal = function () {
        var sumtotal = 0;
        for (var i = 0; i < $scope.products.length; i++) {
            var product = $scope.products[i];
            total = product.cost * product.calculateqty;

            //discounttotal = total * product.discount / 100;
            discounttotal = 0;
            if (product.discountType == "%") {
                discounttotal = total * product.discount / 100;
            } else {
                discounttotal = product.discount * product.calculateqty;
            }
            //alert(product.discount);
            total = total - discounttotal;

            sumtotal = sumtotal + total;
        }
        $scope.total = sumtotal;

        sumtotal = sumtotal + parseFloat($scope.transportCost);
        sumtotal = sumtotal + parseFloat($scope.otherFees);

        discountoverallTax = 0;
        if($scope.overallTaxType == "%"){
            discountoverallTax = sumtotal * parseFloat($scope.overallTax) / 100;
        }else{
            discountoverallTax = parseFloat($scope.overallTax);
        }
        sumtotal = sumtotal + discountoverallTax;

        discountoverallDiscount = 0;
        if ($scope.overallDiscountType == "%") {
            discountoverallDiscount = sumtotal * parseFloat($scope.overallDiscount) / 100;
        } else {
            discountoverallDiscount = parseFloat($scope.overallDiscount);
        }
        sumtotal = sumtotal - discountoverallDiscount;

        $scope.sumtotal = sumtotal;
        return $scope.sumtotal;
    }

    $scope.getonetotal = function (index) {
        var total = $scope.products[index].cost * $scope.products[index].calculateqty;
        //alert($scope.products[index].discount);

        discounttotal = 0;
        if ($scope.products[index].discountType == "%") {
            discounttotal = total * $scope.products[index].discount / 100;
        } else {
            discounttotal = $scope.products[index].discount * $scope.products[index].calculateqty;
        }
        
        total = total - discounttotal;
        return total;
    }

    $scope.changeDtype = function (index, event) {
        if ($scope.products[index].discountType == "%") {
            $scope.products[index].discountType = "$";
            //alert("ei");
        } else {
            $scope.products[index].discountType = "%";
            //alert("ei1");
        }
        $scope.editrow(event);
        //console.log($scope.products);
    }
});

