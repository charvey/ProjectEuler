/*
We shall define a sqube to be a number of the form, p^2q^3, where p and q are distinct primes.
For example, 200 = 5^2 * 2^3 or 120072949 = 23^2 * 61^3.

The first five squbes are 72, 108, 200, 392, and 500.

Interestingly, 200 is also the first number for which you cannot change any single digit to make a prime; we shall call such numbers, prime-proof. The next prime-proof sqube which contains the contiguous sub-string "200" is 1992008.

Find the 200th prime-proof sqube containing the contiguous sub-string "200".
*/

function Problem200(){
	var _isPrime = {};
	var isPrime = function(n){
		if(n==1) return false;
		if(n==2) return true;
		if(n%2==0) return false;
		if(_isPrime[n]!=undefined){
			return _isPrime[n];
		}
		var r = Math.sqrt(n);
		for(var f=3;f<=r;f+=2){
			if(n%f==0){
				_isPrime[n]=false;
				return _isPrime[n];
			}
		}
		_isPrime[n]=true;
		return _isPrime[n];
	};
	var is200 = function(n)	{return (""+n).indexOf("200")!=-1;}
	var isSqube = function(n){
		var r = Math.sqrt(n);
		for(var p=4;p<=r;p++){
			if(n%p==0){
				var q = n/p;

				var p2 = Math.sqrt(p),
					p3 = Math.pow(p,1/3),
					q2 = Math.sqrt(q),
					q3 = Math.pow(q,1/3);

				if((p2%1==0&&q3%1==0&&p2!=q3&&isPrime(p2)&&isPrime(q3)) ||
					(p3%1==0&&q2%1==0&&p3!=q2&&isPrime(p3)&&isPrime(q2))){
					return true;
				}
			}
		}
		return false;
	};
	var isPrimeProof = function(n){
		var s = ""+n;
		var l = (n%2==0)?1:s.length;
		for(var i=0;i<l;i++){
			var m = Math.pow(10,i);
			var x = n-Math.floor((n%Math.pow(10,i+1))/m)*m;

			for(var j=0;j<10;j++){
				if(isPrime(x+j*m)){
					return false;
				}
			}
		}
		return true;
	};
	
	var c = 0;
	for(var i=0;;i++){
		if(is200(i)){//200 substring
			if(isSqube(i)){//sqube
				if(isPrimeProof(i)){//prime-proof
					c++;
					if(c==2){
						return i;
					}
				}
			}
		}
	}
}

Problem200();