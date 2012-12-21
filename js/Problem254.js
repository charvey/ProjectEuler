/*
Define f(n) as the sum of the factorials of the digits of n. For example, f(342) = 3! + 4! + 2! = 32.

Define sf(n) as the sum of the digits of f(n). So sf(342) = 3 + 2 = 5.

Define g(i) to be the smallest positive integer n such that sf(n) = i. Though sf(342) is 5, sf(25) is also 5, and it can be verified that g(5) is 25.

Define sg(i) as the sum of the digits of g(i). So sg(5) = 2 + 5 = 7.

Further, it can be verified that g(20) is 267 and  sg(i) for 1 <= i <= 20 is 156.

What is  sg(i) for 1 <= i <= 150?
*/

function Problem254(){
	var F=[1];
	for(var f=1;f<10;f++) F[f]=f*F[f-1];

	var f=function(n){
		var s=0;
		while(n>0){
			var r=n%10;
			s+=F[r];
			n=(n-r)/10;
		}
		return s;
	};

	var G=[0];
	var g=function(i){
		for(var n=1;;n++){
			if(n==G.length){
				//console.log(n,G);
				G.push(s(f(n)));
			}

			if(G[n]==i){
				return n;
			}
		}
	};

	var s=function(n){
		var s=0;
		while(n>0){
			var r=n%10;
			s+=r;
			n=(n-r)/10;
		}
		return s;
	};

	console.log(f(342),32);
	console.log(s(f(342)),5);
	console.log(s(f(25)),5);
	console.log(g(5),25);
	console.log(s(g(5)),7);
	console.log(g(20),267);

	var t=0;
	for(var i=1;i<=50;i++){
		t+=s(g(i));
	}
	return t;
};

Problem254();