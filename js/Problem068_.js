
var fact = function(n){return n==0?1:n*fact(n-1);};

var D = 3;
var t = fact(D);

for(var i=0; i<t; i++){
	var a = new Array(D);
	var r = [1,2,3];
	var s= i;
	for(var d=D-1;d>=0;d--){
		var dt = fact(d);
		
		var ri = Math.floor(s/dt);
		
		a[D-1-d] = r.removeAt(ri);
	}
	console.log(a);
}