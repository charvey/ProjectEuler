
function rad(n){
	var r=1;

	if(n%2==0){
		r*=2;
		do {
			n/=2;
		} while(n%2==0);
	}
	
	for(var i=3;i<=Math.sqrt(n);i+=2){
		if(n%i==0){
			r*=i;
			do {
				n/=i;
			} while(n%i==0);
		}
	}
	
	return r*n;
}

function E(k,n){
	var a = new Array(k);
	for(var i=0;i<k;i++) a[i] = {r:Infinity,n:0};
	
	for(var i=1;i<=n;i++){
		var r = rad(i);
		
		if(r<=a[0].r){
			a.unshift({r:r,n:i});
			a.pop();
		}
		else if(r>=a[k-1].r){
			
		}
		else{
			//todo: replace with binary search
			for(var j=0;j<k;j++)
				if(r<a[j].r){
					a.splice(j,0,{r:r,n:i});
					a.pop();
					break;
				}
		}
	}
	
	return a[k-1].n;
}

console.log(E(10000,100000));