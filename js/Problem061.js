function Problem061(){
	var N=new Array(1e4);
	for(var n=0;n<1e4;n++){
		N[n]=[false,false,false,false,false,false];
	}
	var e=[
		function(n){return n*(1*n+1)/2;},
		function(n){return n*(1*n+0)/1;},
		function(n){return n*(3*n-1)/2;},
		function(n){return n*(2*n-1)/1;},
		function(n){return n*(5*n-3)/2;},
		function(n){return n*(3*n-2)/1;}
	];
	for(var i=0;i<6;i++){
		for(var n=1;;n++){
			var p=e[i](n);
			if(p>=1e4){
				break;
			}
			N[p][i]=true;
		}
	}

	var f=function(p,r,t){
		if(p[0]%100<10){
			return null;
		}

		if(r.length==0){
			if(Math.floor(t/100)==p[0]%100){
				return p;
			}
			else{
				return null;
			}
		}

		for(var l=0;l<1e2;l++){
			var n=(p[0]%100)*100+l;
			for(var j in r){
				if(N[n][r[j]]){
					var _p=p.slice(0);
					_p.unshift(n);
					var _r=r.slice(0);
					_r.splice(j,1);

					var v=f(_p,_r,t);
					if(v!=null){

						return v;
					}
				}
			}
		}
		return null;
	};

	for(var i=1e3;i<1e4;i++){
		if(N[i][0]){
			var r=f([i],[1,2,3,4,5],i);
			if(r!=null){
				var s=0;
				for(var j in r){
					s+=r[j];
				}
				return s;
			}
		}
	}
}

Problem061();