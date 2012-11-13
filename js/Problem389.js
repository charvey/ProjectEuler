function Problem389(){
	var d = function(n,d){var s=0;for(var i=0;i<n;i++)s+=Math.floor(Math.random()*d);return s;};

	var e=1;
	var s = [4,6,8,12,20];
	for(var i=0;i<s.length;i++)
		e*=(s[i]+1)/2;
	
	var trials = 1e12;
	var sum = 0;
	for(var i=0;i<trials;i++){
	var T = d(1,04);
	var C = d(T,06);
	var O = d(C,08);
	var D = d(O,12);
	var I = d(D,20);
	
	sum+=Math.pow(I-e,2);
	
	}
	
	console.log(sum/trials);
}

Problem389();