function Problem240(){
	var N = 5;
	var D = 6;
	var T = 3;
	var S = 15;
	
	var d = new Array(T);
	for(var i=0;i<T;i++)d[i]=1;
	var s = T;
	var c=0;
	var done = false;
	
	do{
		if(s==S){
			var m = d[0];
			for(var i=1;i<T;i++)
				if(d[i]<m)
					m = d[i];

			var p = Math.pow(m,N-T);
			
			c+=p;
			console.log(p,d);
		}
		
		done = true;
		for(var i=T-1;i>=0;i--){
			if(d[i]==D){
				d[i]=1;
				s += 1-D;
				continue;
			}
			else{
				d[i]++;
				s++;
				done = false;
				break;
			}
		}
	
	} while(!done);

	return c;
}

Problem240();