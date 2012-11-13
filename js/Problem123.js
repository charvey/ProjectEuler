function Problem123(){
	var nextPrime = function(n){
		for(n+=2;;n+=2){
			var r=Math.sqrt(n);
			for(var f=3;f<=r;f+=2){
				if(n%f==0)
					break;
			}
			return n;
		}
	};

	for(var n=2,p=3;;n++,p=nextPrime(p)){
		var r = (Math.pow(p-1,n)+Math.pow(p+1,n))%Math.pow(p,2);
		console.log(n,p,r);

		if(r>1e9)
			return n;

		if(n==7038)
			return false;
	}
}

Problem123();
