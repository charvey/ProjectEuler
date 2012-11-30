/*
A positive fraction whose numerator is less than its denominator is called a proper fraction.
For any denominator, d, there will be d-1 proper fractions; for example, with d=12:
1/12 , 2/12 , 3/12 , 4/12 , 5/12 , 6/12 , 7/12 , 8/12 , 9/12 , 10/12 , 11/12 .

We shall call a fraction that cannot be cancelled down a resilient fraction.
Furthermore we shall define the resilience of a denominator, R(d), to be the ratio of its proper fractions that are resilient; for example, R(12) = 4/11 .
In fact, d=12 is the smallest denominator having a resilience R(d) < 4/10 .

Find the smallest denominator d, having a resilience R(d) < 15499/94744 .
*/

function Problem243(){
	var N=15499,D=94744;
	//var N=4,D=10;
	var P=[2,3];
	
	var p=function(n){
		while(P[P.length-1]<n){
			for(var i=P[P.length-1]+2;;i+=2){
				var r=Math.sqrt(i);
				var f=true;
				for(var j=0;P[j]<=r;j++){
					if(i%P[j]==0){
						f=false;
						break;
					}
				}
				if(f){
					P.push(i);
					break;
				}
			}
		}
	};
	
	var R=function(d){
		var r=d-1;
		var N=new Array(d);
		var s=Math.sqrt(d);
		
		p(s);
		
		for(var i=0;P[i]<=s;i++){
			if(d%P[i]==0){
				for(var j=P[i];j<d;j+=P[i]){
					if(!N[j]){
						r--;
					}
					N[j]=true;
				}
			}
		}
		return r;
	};
	
	var m=1;
	for(var d=2;;d++){
		var r=R(d);
		
		if(r/(d-1)<m){
			m=r/(d-1);
			console.log(r+"/"+(d-1)+" "+m+" "+(15499/94744));
		}
		
		if(r*D<N*(d-1)){
			return d;
		}
	}
}

//http://imgur.com/yqpYx
Problem243();