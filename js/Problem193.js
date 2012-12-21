/*
A positive integer n is called squarefree, if no square of a prime divides n, thus 1, 2, 3, 5, 6, 7, 10, 11 are squarefree, but not 4, 8, 9, 12.

How many squarefree numbers are there below 2^50?
*/

function Problem193(){
	var p=[2,3];
	while(p[p.length-1]<Math.sqrt(Math.pow(2,50))){
		for(var i=p[p.length-1]+2;;i+=2){
			var f=true;
			var r=Math.sqrt(i);
			for(var j=0;p[j]<=r;j++){
				if(i%p[j]==0){
					f=false;
					break;
				}
			}
			if(f){
				p.push(i);
				//console.log((i*i)/Math.pow(2,50));
				break;
			}
		}
	}

	return p.length;
}

Problem193();