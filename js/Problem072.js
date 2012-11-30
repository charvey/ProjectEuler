/*
Consider the fraction, n/d, where n and d are positive integers. If n<d and HCF(n,d)=1, it is called a reduced proper fraction.

If we list the set of reduced proper fractions for d  8 in ascending order of size, we get:

1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8

It can be seen that there are 21 elements in this set.

How many elements would be contained in the set of reduced proper fractions for d  1,000,000?

*/


function Problem072(){
	var gcd = function(a,b){return b == 0 ? a : gcd(b, a % b);};
	
	var c=0;
	for(var d=2;d<=1e2;d++){
		c++;
		var o=d%2==1;
		var s=o?1:2;
		for(var n=o?2:3;n<d;n++){
			if(gcd(d,n)==1){
				//console.log(n+"/"+d);
				c++;
			}
		}
		if(d%1e4==0) console.log(d);
	}
	return c;
}

//Problem072();

function Problem072_b(){
	var p=[2,3];
	var F = [[],[]];
	var c=0;
	for(var d=2;d<=1e6;d++){
		var x=d;
		F[d]=[];
		for(var i=0;x!=1;i++){
			if(i==p.length){
				var j=p[p.length-1];
				var found;
				do{
					j+=2;
					found=true;
					var r=Math.sqrt(j);
					for(var f=3;f<=r;f+=2){
						if(j%f==0){
							found=false;
							break;
						}
					}
				} while(!found);
				p.push(j);
			}

			if(x%p[i]==0){
				F[d].push(p[i]);
				do {
					x/=p[i];
				} while(x%p[i]==0);
			}
		}
		c++;
		var o=d%2==1;
		var s=o?1:2;
		for(var n=o?2:3;n<d;n+=s){
			var v=true;
			var a=0,b=0;
			while(a<F[n].length&&b<F[d].length){
				if(F[n][a]==F[d][b]){
					v=false;
					break;
				}
				else if(F[n][a]<F[d][b]){
					a++;
				}
				else{
					b++;
				}
			}
			if(v){
				c++;
			}
		}
	}
	return c;
}

Problem072_b();
