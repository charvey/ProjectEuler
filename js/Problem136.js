/*
x^2-y^2-z^2=n

(a+0*b)^2-(a+1*b)^2-(a+2*b)^2=n

a^2-(a^2+2*a*b+b^2)-(a^2+4*a*b+4*b^2)=n
-2*a*b-b*b-a*a-4*a*b-4*b*b=n
-6*a*b-5*b*b-a*a=n
a^2+6ab+5b^2=-n

(a+b)(a+5b)=-n

a+5b-a-b
4b


10,-2
*/

function Problem136(){
	var c=0;
	for(var i=1;i<50e6;i++){
		var r = Math.sqrt(i);
		var found = 0;
		for(var f=1;f<=r;f++){
			if((f-i/f)%4==0){
				found++;
				if(found>1){
					break;
				}
			}
		}
		if(found==1){
			c++;
		}
	}
	return c;
}

Problem136();