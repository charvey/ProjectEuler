/*
Define f(0)=1 and f(n) to be the number of different ways n can be expressed as a sum of integer powers of 2 using each power no more than twice.

For example, f(10)=5 since there are five different ways to express 10:

1 + 1 + 8
1 + 1 + 4 + 4
1 + 1 + 2 + 2 + 4
2 + 4 + 4
2 + 8

What is f(10^25)?
*/

function Problem169(){
	var f=function(n){
		var p=Math.ceil(Math.log(n+.01)/Math.log(2));
		var m=new Array(p+1);
		for(var i=0;i<=p;i++) m[i]=0;

		var c=0;
		var s=0;
		do{
			for(var i=0;i<=p;i++){
				if(m[i]==2){
					s-=2*Math.pow(2,i);
					m[i]=0;
				}else{
					s+=Math.pow(2,i);
					m[i]++;
					break;
				}
			}

			if(s==n){
				c++;
			}
			console.log(m);
		} while(m[p]<1);

		return c;
	};

	console.log(f(10),5);
	return f(10e25);
}

//Problem169();


function c(n){
	for(var m=Math.floor(Math.log(n)/Math.log(2));m>=0;m--){
		var e=Math.pow(2,m);
		if(n>=e){
			console.log(e);
			n-=e;
		}
	}
}

c(1023);
c(10e25);