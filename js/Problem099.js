var data =[
	[519432,525806],
	[632382,518061],
	[519432,525806]
];

/*
function Problem099(){
	var max=0;

	for(var i=1;i<data.length;i++){
		var a=data[i],b=data[max];
		if(b[1]<a[1]){
			var t=a;
			a=b;
			b=t;
		}

		var m=b[0]/a[0];
		var x=1;
		var j=0;
		for(var j=0;j<b[1];j++){
			x*=(j<a[1])
				? m
				: b[0];
			if(j%1000==0)console.log(x);
		}
		if(x>1){
			console.log(m,x,b[0]);
			max=i;
		}
	}
	return max+1;
}
*/

function Problem099(){
	var max=0;

	for(var i=1;i<data.length;i++){
		var a=data[i],b=data[max];
		if(b[1]<a[1]){
			var t=a;
			a=b;
			b=t;
		}

		
		for(var i=0;i<)
	}
	return max+1;
}

Problem099();