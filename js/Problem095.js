function Problem095(){
	var a=new Array(1e6);
	for(var i=1;i<1e6;i++){
		a[i]=1;
		var r = Math.sqrt(i);
		for(var f=2;f<r;f++)
			if(i%f==0)
				a[i]+=f+i/f;
	}
	
	var m = 0;
	var max = 0;
	for(var i=2;i<1e6;i++){
		var n=i,p={},c=0,r=true;
		do{
			if(p[n]!=undefined){
				r=false;
				break;
			}
			p[n]=a[n];
			c++;
			n=a[n];

			if(n==i){
				if(c>max){
					m = i;
					max = c;
				}

				break;
			}
		} while(n<1e6 && n!=0);
		
		if(r){
			var n=i;
			do{
				a[n]=0;
				c--;
			} while(c>0);
		}
	}

	return m;
}
