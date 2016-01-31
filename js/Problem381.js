function Problem381(){
	function isPrime(n){if(n<=2)return true;for(var k=3;k<=Math.sqrt(n);k+=2)if(n%k==0)return false;return true;}

	function S(p){
		var s=0;
		
		var f=1;
		for(var n=1;n<p-5;n++){
			f=(f*n)%p;
		}
		
		for(var n=p-5;n<p;n++){
			f=(f*n)%p;
			s+=f%p;
		}
			
		return s%p;
	}

	
	var N = 100000000;
	
	var sieve = [false,false,true,true,false,true];
	for(var i=4;i<=N;i++)
		sieve[i]=!(i%2==0 || i%3==0 || i%5==0);
	
	var s=4;
	for(var p=7;p<N;p+=2){
		if(sieve[p]){
			console.log(p);
		
			for(var i=p+p;i<N;i+=p){
				sieve[i]=false;
			}
		
			s+=S(p);
		}
	}
	
	return s;
}
Problem381();