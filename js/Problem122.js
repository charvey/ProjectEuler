/*
The most naive way of computing n15 requires fourteen multiplications:

n * n * ... * n = n15

But using a "binary" method you can compute it in six multiplications:

n * n = n2
n2 * n2 = n4
n4 * n4 = n8
n8 * n4 = n12
n12 * n2 = n14
n14 * n = n15

However it is yet possible to compute it in only five multiplications:

n * n = n2
n2 * n = n3
n3 * n3 = n6
n6 * n6 = n12
n12 * n3 = n15

We shall define m(k) to be the minimum number of multiplications to compute nk; for example m(15) = 5.

For 1 <= k <= 200, find S m(k).
*/

/*
function Problem122(){
	var m = function(k){
		var p={1:true};
		var x=[];
		for(var i=1;((i<4));i++){
			var n={};
			for(var j in p){
				j=parseInt(j);
				for(var l in p){
					l=parseInt(l);
					var m=j+l;
					n[m]=true;
				}
			}
			for(var j in n){
				p[j] = p[j]||n[j];
			}
			console.log(i,'p',p);
			if(p[k]){
				return i;
			}
		}
	};

	console.log('m(15)',m(15));
	
	var s=0;
	for(var k=1;k<=200;k++){
		//s+=m(k);
	}
	return s;
}
*/
function Problem122(){
	var m = function(k){
		var p={1:true};
		var c=[p];
		for(var i=1;((i<4));i++){
			
			
			
		}
	};

	console.log('m(15)',m(15));
	
	var s=0;
	for(var k=1;k<=200;k++){
		//s+=m(k);
	}
	return s;
}

Problem122();