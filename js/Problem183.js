/*
Let N be a positive integer and let N be split into k equal parts, r = N/k, so that N = r + r + ... + r.
Let P be the product of these parts, P = r * r * ... * r = r^k.

For example, if 11 is split into five equal parts, 11 = 2.2 + 2.2 + 2.2 + 2.2 + 2.2, then P = 2.25 = 51.53632.

Let M(N) = Pmax for a given value of N.

It turns out that the maximum for N = 11 is found by splitting eleven into four equal parts which leads to Pmax = (11/4)^4; that is, M(11) = 14641/256 = 57.19140625, which is a terminating decimal.

However, for N = 8 the maximum is achieved by splitting it into three equal parts, so M(8) = 512/27, which is a non-terminating decimal.

Let D(N) = N if M(N) is a non-terminating decimal and D(N) = -N if M(N) is a terminating decimal.

For example, SD(N) for 5 <= N <= 100 is 2438.

Find SD(N) for 5 <= N <= 10000.
*/

function Problem183(){
	var Mk=function(N){
		var m=1;
		for(var k=1;k<=N;k++){
			if(Math.pow(N/k,k)>Math.pow(N/m,m)){
				m=k;
			}
		}
		return m;
	};
	var D=function(N){
		var k=Mk(N);
		var n=Math.pow(N,k),d=Math.pow(k,k);

		var r={};
		var c=0;
		var s="";
		s+=Math.floor(n/d);
		n-=Math.floor(n/d)*d;
		s+=".";
		while(true){
			c++;
		
			n*=10;
			s+=Math.floor(n/d);
			n-=Math.floor(n/d)*d;
			
			if(n==0){
				r=N;
				break;
			}
			if(r[n]!=undefined || c==10000){
				r=-N;
				break;
			}
			r[n]=true;
		}
		
		console.log(N,r,s);
		return r;
	};
	
	//console.log(D(25));
	
	var s=0;
	for(var N=5;N<=100;N++){
		s+=D(N);
	}
	return s;
}

Problem183();