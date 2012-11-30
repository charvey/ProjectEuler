/*
There are some prime values, p, for which there exists a positive integer, n, such that the expression n^3 + n^2*p is a perfect cube.

For example, when p = 19, 83 + 8219 = 123.

What is perhaps most surprising is that for each prime with this property the value of n is unique, and there are only four such primes below one-hundred.

How many primes below one million have this remarkable property?
*/

function Problem131(){
	var p=[2];
	for(var i=3;i<2e1;i+=2){
		var r=Math.sqrt(i);
		var F=true;
		for(var f=0;p[f]<=r;f++){
			if(i%p[f]==0){
				F=false;
				break;
			}
		}
		if(F){
			p.push(i);
		}
	}
	var isCube = function(n){return Math.pow(Math.round(Math.pow(n,1/3)),3)==n;};

	var c=0;
	for(var n=1;n<p[p.length-1];n++){
		for(var i=0;i<p.length;i++){
			if(isCube(n*n*(n+p[i]))){
				c++;
				console.log(c,p[i],n,Math.round(Math.pow(n*n*(n+p[i]),1/3)));
				break;
			}
		}
	}
	return c;
}

Problem131();