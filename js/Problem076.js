function f(n){
	if(n==1) return 0;
	return f_r(n,1);
}

function f_r(n,s){
	if(n==1)
		return 1;
	if(s==n)
		return 1;
	if(s>n)
		return 0;

	var count = 0;
	for(var i=s; i<n; i++){
		count += f_r(n-i,i);
	}
	return count;
}

f(100);