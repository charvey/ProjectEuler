function Problem068(){
	var N = 3;
	var D = 6;
	
	var poss = new Array(N*D+1);
	for(var i=0;i<=N*D;i++) poss[i]=[];
	
	var s = [null,null,null];
	for(var i=0;i<Math.pow(D,N);i++){
		var n = i;
		var sum = 0;
		
		for(var j=2;j>=0;j--){
			s[j] = Math.floor(n/Math.pow(D,j));
			n -= s[j]*Math.pow(D,j);
			s[j]++;
			sum+=s[j];
		}
		
		poss[sum].push(s.slice());
	}
	
	var sols = [];
	
	for(var i=1;i<=N*D;i++){
		if(poss[i].length===0)
			continue;
	
		var sol = new Array(N);
		for(var j=0;j<N;j++) sol[j]=0;
				
		for(var j=0;j<N;j++){
			for(var k=0;k<sols[i].length;k++){
				if(sols[i][sols[j]][1]==sols[i][sols[j-1]][2]){
					if(j==N-1 && sols[i][sols[j]][1]==sols[i][sols[j]][2])
						continue;
				}
			}
		}
	}
	
	return poss;
}

Problem068()