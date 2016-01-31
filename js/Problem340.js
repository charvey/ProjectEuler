/*
For fixed integers a, b, c, define the crazy function F(n) as follows:
F(n) = n - c for all n > b 
F(n) = F(a + F(a + F(a + F(a + n)))) for all n < b.

Also, define S(a, b, c) = f(0..b).

For example, if a = 50, b = 2000 and c = 40, then F(0) = 3240 and F(2000) = 2040.
Also, S(50, 2000, 40) = 5204240.

Find the last 9 digits of S(217, 721, 127).
*/

function Problem340(){
	var F=function(a,b,c,n){
		if(n>b){
			return n-c;
		}

		return F(a + F(a + F(a + F(a + n))));
	};
	var S=function(a,b,c){

	};

	console.log(F(50,2000,40,0),3240);
	console.log(F(50,2000,40,2000),2040);
}

Problem340();