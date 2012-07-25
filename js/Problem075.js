function Valid(l){
	var found = false;

	for(var a=1;3*a<=l;a++){
		for(var b=a,c=(l-a-a);b<=c;b++,c--){
			if(a*a+b*b==c*c){
				if(found)
					return 2;
				else
					found = true;
			}
		}
	}

	return found?1:0;
}

function Problem075(){
	var N = 15000000;
	var fa = new Array(N+1);
	for(var i=1;i<=N;i++)
		fa[i]=true;

	var count = 0;
	
	for(var L=1;L<=N;L++){
		if(fa[L]){
			var v = Valid(L);
			if(v==1){
				count++;
				console.log(L,count);
			}
			else if(v==2){
				for(var n=L;n<=N;n++)
					fa[n] = false;
			}
		}
	}
			
	return count;
}