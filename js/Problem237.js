function clone(a){return a.slice(0);}

var p=new Array(6);

for(var i=0;i<6;i++){
	p[i]={
		U:(i==0||i==1||i==4),
		D:(i==2||i==3||i==4),
		L:(i==1||i==3||i==5),
		R:(i==0||i==2||i==5),
		S:"└┘┌┐│─"[i],
		I:"┐┘┌└─│"[i],
		B:"╗╝╔╚═║"[i]
	};
}

var S=[
	[4,2,3,4],
	[5,5,3,4],
	[4,2,5,5],
	[5,3,2,5]
];

var M=[];
var x=0;
for(var i in p){
	if(p[i].L){//Wall
		continue;
	}
	for(var j in p){
		if(p[i].R!=p[j].L){//Internal connection
			continue;
		}
		for(var k in p){
			if(p[j].R!=p[k].L){//Internal connection
				continue;
			}
			for(var l in p){
				if(p[k].R!=p[l].L){//Internal connection
					continue;
				}
				if(p[l].R){//Wall
					continue;
				}
				if((i==0&&j==1&&k==2&&l==3)||(i==2&&j==3&&k==0&&l==1)){
					continue;
				}

				var u=(p[i].U?1:0)+(p[j].U?1:0)+(p[k].U?1:0)+(p[l].U?1:0);
				var d=(p[i].D?1:0)+(p[j].D?1:0)+(p[k].D?1:0)+(p[l].D?1:0);

				if(!(u>0 && u%2==0)){
					continue;
				}
				if(!(d>0 && d%2==0)){
					continue;
				}

				x++;
				M.push([i,j,k,l]);
			}
		}
	}
}

var E =[
	[0,1,0,1],
	[0,5,5,1]
];

for(var i in S){
	console.log("S "+(i<9?"0"+(1*i+1):(1*i+1))+" "+p[S[i][0]].S+p[S[i][1]].S+p[S[i][2]].S+p[S[i][3]].S);
}

for(var i in M){
	console.log(M[i]);
	console.log("M "+(i<9?"0"+(1*i+1):(1*i+1))+" "+p[M[i][0]].S+p[M[i][1]].S+p[M[i][2]].S+p[M[i][3]].S);
}

for(var i in E){
	console.log("E "+(i<9?"0"+(1*i+1):(1*i+1))+" "+p[E[i][0]].S+p[E[i][1]].S+p[E[i][2]].S+p[E[i][3]].S);
}

var R={S:new Array(16),M:new Array(16),E:new Array(16)};

for(var i=0;i<16;i++){
	R.S[i]=[];
	R.M[i]=[];
	R.E[i]=[];
}

for(var i in S){
	var s=0;
	var e=0;
	for(var j=0;j<4;j++){
		e+=p[S[i][j]].D?Math.pow(2,j):0;
	}
	R.S[s].push({B:S[i],E:e});
}

for(var i in M){
	var s=0;
	var e=0;
	for(var j=0;j<4;j++){
		s+=p[M[i][j]].U?Math.pow(2,j):0;
		e+=p[M[i][j]].D?Math.pow(2,j):0;
	}
	R.M[s].push({B:M[i],E:e});
}

for(var i in E){
	var s=0;
	var e=0;
	for(var j=0;j<4;j++){
		s+=p[E[i][j]].U?Math.pow(2,j):0;
	}
	R.E[s].push({B:E[i],E:e});
}

/*
for(var s in R.M){
	console.log(s);
	for(var i in R.M[s]){
		console.log("\t"+p[R.M[s][i].B[0]].S+p[R.M[s][i].B[1]].S+p[R.M[s][i].B[2]].S+p[R.M[s][i].B[3]].S);
	}
}
*/

function T(n){
	if(n<2) return;

	var t_m=function(b,s,t,n){
		if(t==n){
			var C=0;
			for(var i in R.E[s]){
				C++;

				b[n-1]=clone(R.E[s][i].B);

				var r='';
				for(var x=0;x<4;x++){
					for(var y=0;y<n;y++){
						r+=p[b[y][x]].B;
					}
					r+='\n';
				}
				console.log(r);
			}
			return C;
		}

		var C=0;
		for(var i in R.M[s]){
			var _s=R.M[s][i].E;
			b[t-1]=clone(R.M[s][i].B);
			C+=t_m(clone(b),_s,t+1,n);
		}
		return C;
	};

	var b=new Array(n);
	var s=0;
	var C=0;
	for(var i in R.S[s]){
		var _s=R.S[s][i].E;
		b[0]=clone(R.S[s][i].B);
		C+=t_m(clone(b),_s,2,n);
	}
	return C;
}

T(4);

//T(10)==2329