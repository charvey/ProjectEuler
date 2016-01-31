
function Problem091(n){
	var c=0;
	for(var i=1;i<=n;i++){
		c+=2*n;

		c+=n;

		c+=3*Math.min(i,n-i);
	}
	return c;
}

console.log(Problem091(2),14);
console.log(Problem091(50),14234);


/*
 _ _ _ _
|_|_|_|_|
|_|_|_|_|
|_|_|_|_|
|_|_|_|_|

 _ _ 
|_|_|
|_|_|

*/