function Problem068(){
	var R = 5;
	var D = R*2;
	var answer = 0;

	var fact = function(n){return n==0?1:n*fact(n-1);};

	var digits = [];
	for(var d=1;d<=D;d++)digits.push(d);

	var t = fact(D);
	for(var i=0;i<t;i++){
		var a = new Array(D);
		var _digits = digits.slice(0);

		var s = i;
		for(var d=D-1;d>=0;d--){
			var fd = fact(d);
			var dt = Math.floor(s/fd);

			a[d] = _digits.splice(dt,1)[0];

			s -= dt*fd;
		}

		var sum = null;
		for(var r=0;r<R;r++){
			var sub = a[2*r]+a[2*r+1]+a[(2*(r+1)+1)%D];

			if(sum==null)
				sum = sub;
			else if(sum==sub)
				continue;
			else{
				sum = null;
				break;
			}
		}

		if(sum!=null){
			var minR=0;
			for(var r=1;r<R;r++)
				if(a[2*r]<a[2*minR])
					minR = r;

			var poss = "";
			for(var r=0;r<R;r++)
				poss += ""+a[2*(r+minR)]+a[2*(r+minR)+1]+a[(2*(r+minR+1)+1)%D];

			if(poss.length==16 && parseInt(poss)>parseInt(answer))
				answer = poss;
		}
	}

	return answer;
}