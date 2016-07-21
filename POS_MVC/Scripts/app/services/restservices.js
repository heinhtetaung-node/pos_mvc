var apihost = "http://localhost:8099/";

app.factory('Restful', function($http, $rootScope){
	/*
	function factoryposttest(paras, callback) {
		$http({
			url: baseurl + 'User/factoryposttest',
			method: "POST",
			data: paras
		}).success(function (data, status, headers, config) {
            callback(data); 
        });
    }
	
	function getdatasforselect(paras, callback) {
		$http({
			url: baseurl + 'Crud/getdatasforselect',
			method: "POST",
			data: paras
		}).success(function (data, status, headers, config) {
            callback(data); 
        });
    }
	*/

    function getProduct(id, callback) {
        $http({
            method: 'GET',
            url: apihost + "Products/getProduct/"+id,
            cache: true
        }).success(callback);
    }
	
	function getcategorystatus(callback){
		$http({
			method: 'GET',
			url: apihost+"api/categorystatus",		
			cache: true
		}).success(callback);
	}
	
	function getcategory(callback){
		$http({
			method: 'GET',
			url: apihost+"api/category",		
			cache: true
		}).success(callback);
	}
	
	function getcurrencyprice(callback){
		$http({
			method: 'GET',
			url: apihost+"api/currencyprice",		
			cache: true
		}).success(callback);
	}	
	
	function getstatedivision(callback){
		$http({
			method: 'GET',
			url: apihost+"api/statedivision",		
			cache: true
		}).success(callback);
	}
	
	function gettownship(callback){
		$http({
			method: 'GET',
			url: apihost+"api/township",		
			cache: true
		}).success(callback);
	}
		
	function getlatest(callback){
		$http({
			method: 'GET',
			url: apihost+"api/HomeView",		
			cache: true
		}).success(callback);
	}
	
	function getfeatures(callback){
		$http({
			method: 'GET',
			url: apihost+"api/HomeFeature",		
			cache: true
		}).success(callback);
	}
	
	function getcategoryfilter(categoryid, callback) {
		$http({
			method: 'GET',
			url: apihost+"api/HomeView/"+categoryid,		
			cache: true
		}).success(callback);
	}
	
	function getdetail(property_id, callback){
		$http({
			method: 'GET',
			url: apihost+"api/Detail/"+property_id,		
			cache: true
		}).success(callback);
	}
	
	function getallproperties(para, callback) {
		console.log(para);
		
		var urlink=apihost+"api/browse/?page="+para.page;

		if(para.status!=undefined){
			if(para.status!=''){
				urlink=urlink+"&status="+para.status;
			}
		}	

		if(para.category!=undefined){
			if(para.category!=''){
				urlink=urlink+"&category="+para.category;
			}
		}

		if(para.price!=undefined){
			if(para.price!=''){
				urlink=urlink+"&price="+para.price;
			}
		}

		if(para.state!=undefined){
			if(para.state!=''){
				urlink=urlink+"&state="+para.state;
			}
		}

		if(para.township!=undefined){
			if(para.township!=''){
				urlink=urlink+"&township="+para.township;
			}
		}

		if(para.searchkeyword!=undefined){
			if(para.searchkeyword!=''){
				urlink=urlink+"&searchkey="+para.searchkeyword;
			}
		}

		console.log(urlink);

		
		//&status=Sale&cat=Landed%20House&curprice=%201%20-%203%20LKH&state=Yangon&township=Bogale
	

		$http({
			method: 'GET',
			url: urlink,
			cache: true
		}).success(callback);
		
	}
	
	function getfacilities(callback){
		$http({
			method: 'GET',
			url: apihost+"api/Facility",		
			cache: true
		}).success(callback);
	}

	function saveregister(registerObj, callback){
		/*
		$http({
			method  : "POST",
			url     : "https://mhapi.innovix-solutions.net/api/Register/",
			data    : registerObj,
			headers : { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
			
		}).success(callback);
		*/
		$.ajax({
			dataType : "json",
			type     : "POST",
			url      : apihost+"api/Register/",			
			data     : registerObj,
			headers  : { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
			
		}).success(callback);
	}

	function checklogin(loginObj, callback){
		
		$.ajax({
			dataType : "json",
			type     : "POST",
			url      : apihost+"api/Login/",			
			data     : loginObj,
			headers  : { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
			
		}).success(callback);
	}
	
	
	function propertysave(PropertyObj, callback){
		
		$.ajax({
			dataType : "json",
			type     : "POST",
			url      : apihost+"api/property/",			
			data     : PropertyObj,
			headers  : { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
			
		}).success(callback);
	}
	
	return {
	    getProduct: getProduct
	};
});