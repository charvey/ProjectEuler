function Problem077(){
	var p = [3,2];

	for(var i=3;;i++){
		for(var j=p[0]+2;p[0]<=i;j+=2){
			var r=Math.sqrt(j);
			var t=true;
			for(var k=p.length-1;p[k]<=r;k--){
				if(j%p[k]==0){
					t=false;
					break;
				}
			}
			if(t){
				p.unshift(j);
			}
		}

		var a=new Array(p.length);
		for(var j=0;j<p.length;j++) a[j]=0;
		var s=0;
		var c=0;
		do{
			for(var j=(a.length-1);j>=0;j--){
				a[j]++;
				s+=p[j];

				if(s<=i || a[j]==1){
					break;
				}
				else{
					s-=a[j]*p[j];
					a[j]=0;
				}
			}
			if(s==i){
				c++;
			}
		} while(a[0]==0);

		if(c>5000){
			return i;
		}
	}
}