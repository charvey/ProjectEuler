/*
Consider the number 6. The divisors of 6 are: 1,2,3 and 6.
Every number from 1 up to and including 6 can be written as a sum of distinct divisors of 6:
1=1, 2=2, 3=1+2, 4=1+3, 5=2+3, 6=6.
A number n is called a practical number if every number from 1 up to and including n can be expressed as a sum of distinct divisors of n.

A pair of consecutive prime numbers with a difference of six is called a sexy pair (since "sex" is the Latin word for "six"). The first sexy pair is (23, 29).

We may occasionally find a triple-pair, which means three consecutive sexy prime pairs, such that the second member of each pair is the first member of the next pair.

We shall call a number n such that :

(n-9, n-3), (n-3,n+3), (n+3, n+9) form a triple-pair, and
the numbers n-8, n-4, n, n+4 and n+8 are all practical,
an engineers’ paradise.
Find the sum of the first four engineers’ paradises.
*/

function Problem263(){
	var p=[2,3];
	var P=function(n){
		while(p[p.length]<n){
			for(var i=p[p.length-1]+2;;i+=2){
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
		}
	}

	for(var n=8;n<1e10;n+=2){
		P(n+9)
		if(p[p.length-1]==n+9 && p[p.length-2]==n+3 &&
			p[p.length-3]==n-3 && p[p.length-4]==n-9){
			console.log(n-9,n-3,n+3,n+9);
			break;
		}
	}
}

//Problem263();


function d(n){
	var r=Math.sqrt(n);
	for(var f=1;f<r;f++){
		if(n%f==0){
			console.log(f,n/f);
		}
	}
	if(n%r==0){
		console.log(r);
	}
}

d(1026);