/*
Looking at the table below, it is easy to verify that the maximum possible sum of adjacent numbers in any direction (horizontal, vertical, diagonal or anti-diagonal) is 16 (= 8 + 7 + 1).

-2	5	3	2
9	-6	5	1
3	2	7	3
-1	8	-4	8

Now, let us repeat the search, but on a much larger scale:

First, generate four million pseudo-random numbers using a specific form of what is known as a "Lagged Fibonacci Generator":

For 1  k  55, sk = [100003-200003*k + 300007*k^3] (modulo 1000000)-500000.
For 56  k  4000000, sk = [s[k-24] + s[k-55] + 1000000] (modulo 1000000)-500000.

Thus, s10 = 393027 and s100 = 86613.

The terms of s are then arranged in a 2000x2000 table, using the first 2000 numbers to fill the first row (sequentially), the next 2000 numbers to fill the second row, and so on.

Finally, find the greatest sum of (any number of) adjacent entries in any direction (horizontal, vertical, diagonal or anti-diagonal).
*/

/*
function Problem149(){
	var N=2000;

	var t=new Array(N*N);
	for(var k=1;k<=55;k++){
		t[k-1]=((100003-200003*k+300007*Math.pow(k,3))%1000000)-500000;
	}
	for(var k=55;k<=N*N;k++){
		t[k-1]=((t[k-25] + t[k-56] + 1000000)%1000000)-500000;
	}
	//var t=[-2,5,3,2,9,-6,5,1,3,2,7,3,-1,8,-4,8];

	var get=function(x,y){return t[N*x+y];};

	var m=0;
	for(var i=0;i<N;i++){
		for(var j=0;j<N;j++){
			for(var r=-1;r<=1;r++){
				for(var c=-1;c<=1;c++){
					if(r==0&&c==0)
						continue;

					var _m=0;
					for(var x=i,y=j;0<=x&&x<N&&0<=y&&y<N;x+=c,y+=r){
						_m+=get(x,y);
						if(_m>m)
						{
							m=_m;
						}
					}
				}
			}
		}
	}
	return m;
}
*/

function Problem149(){
	var N=2000;

	var t=new Array(N*N);
	for(var k=1;k<=55;k++){
		t[k-1]=((100003-200003*k+300007*Math.pow(k,3))%1000000)-500000;
	}
	for(var k=55;k<=N*N;k++){
		t[k-1]=((t[k-25] + t[k-56] + 1000000)%1000000)-500000;
	}
	//var t=[-2,5,3,2,9,-6,5,1,3,2,7,3,-1,8,-4,8];

	var get=function(x,y){return t[N*x+y];};

	var m=0;
	for(var i=0;i<N;i++){
		
	}
	return m;
}

Problem149();