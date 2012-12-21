/*
It is possible to show that the square root of two can be expressed as an infinite continued fraction.

√2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...

By expanding this for the first four iterations, we get:

1 + 1/2 = 3/2 = 1.5
1 + 1/(2 + 1/2) = 7/5 = 1.4
1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...
The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example where the number of digits in the numerator exceeds the number of digits in the denominator.

In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?
*/

function Problem057(){
	var gcd=function(a,b){return g_r(a > b ? a : b, a < b ? a : b);}
	var g_r=function(a,b){return b == 0 ? a : g_r(b, a % b);}
	var d=function(n){return Math.ceil(Math.log(n+.1)/Math.log(10));};

	var f=function(i){
		var x={n:2,d:1};
		for(;i>0;i--){
			var t=x.n;
			x.n=(i>1?2:1)*x.n+1*x.d;
			x.d=t;

			//console.log(gcd(x.n,x.d));
			var g=gcd(x.n,x.d);
			x.n=x.n/g;
			x.d=x.d/g;
		}
		return x;
	};

	var c=0;
	for(var i=1;i<=1e3;i++){
		var x=f(i);
		
		if(d(x.n)>d(x.d)){
			console.log(i+" "+x.n+"/"+x.d+" "+d(x.n)+" over "+d(x.d)+" "+gcd(x.n,x.d));
			c++;
		}
	}
	return c;
}

Problem057();