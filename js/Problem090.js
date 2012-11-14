function Problem090(){
	var nextDi = function(d){
		for(var i=0;i<=10;i++){
			if(i==10) return null;
			if(d[i]&&i<4) break;
		}
		var c=d.slice(0);
		if(c[9]){
			var s = 0;
			var f = 0;
			for(var i=9;i>=0;i--){
				if(s==0){
					if(d[i])
						f++;
					else
						s = 1;
				}
				if(s==1){
					if(d[i]){
						c[i] = false;
						for(var j=i+1;j<=9;j++){
							c[j] = j<=(i+f+1);
						}
						return c;
					}
				}
			}
		}
		for(var i=8;i>=0;i--){
			if(c[i]){
				c[i]=false;
				c[i+1]=true;
				return c;
			}
		}
	};
	var extend = function(d){
		var c=d.slice(0);
		if(c[6]) c[9]=true;
		if(c[9]) c[6]=true;
		return c;
	};

	var c=0;
	var a = [];
	for(var i=0;i<=9;i++) a[i]=i<6;
	do{
		var ea = extend(a);
		var b = a.slice(0);
		do{
			var eb = extend(b);

			var all = true;
			for(var s=1;s<=9;s++){
				var s2 = s*s;
				var d1 = s2%10, d2 = Math.floor(s2/10);

				if((ea[d1]&&eb[d2])||(ea[d2]&&eb[d1])){
					continue;
				}
				else {
					all = false;
					break;
				}
			}

			if(all){
				c++;
			}

			b = nextDi(b);
		} while(b!=null);

		a = nextDi(a);
	} while(a!=null);

	return c;
}
