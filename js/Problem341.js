/*
The Golomb's self-describing sequence {G(n)} is the only nondecreasing sequence of natural numbers such that n appears exactly G(n) times in the sequence. The values of G(n) for the first few n are

n	1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	…
G(n)	1	2	2	3	3	4	4	4	5	5	5	6	6	6	6	…
You are given that G(10^3) = 86, G(106) = 6137.
You are also given that ΣG(n^3) = 153506976 for 1 <= n < 10^3.

Find ΣG(n^3) for 1 <= n < 10^6.
*/

function Problem341(){
	var _n=4;

	var _g=4;
	var _h=3;

	var g=[0,1,2,2];
	var G=function(n){
		var s=0;
		for(var i=0;i<1e9;i++){
			if(i>=g.length){
				g[i]=G(i);
			}

			s+=g[i];
			if(s>=n){
				return i;
			}
		}
	};

	for(var i=1;i<=15;i++){
		console.log(i+"\t"+G(i));
	}

	console.log(G(1e9));
	console.log(g);
}

Problem341();

n	G	|	g	h
__________________________
		|	0	0
1	1	|	1	1
2	2	|	2	2
3	2	|	2	
4	3	|	3	
5	3	|		
6	4	|		
7	4	|		
8	4	|		
9	5	|		
10	5	|		
11	5	|		
12	6	|		
13	6	|		
14	6	|		
15	6	|		