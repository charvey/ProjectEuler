function Problem109(){
	var S=[25];
	for(var i=1;i<=20;i++) S[i]=i;

	var c=0;
	for(var i=0;i<=20;i++){
		if((2*S[i])<100){
			c++;
		}
		for(var j=0;j<=20;j++){
			for(var m=(j==0)?2:3;m>=1;m--){
				if((2*S[i]+m*S[j])<100){
					c++;
				}
				for(var k=j;k<=20;k++){
					for(var n=(j==0)?2:3;n>=1;n--){
						if((2*S[i]+m*S[j]+n*S[k])<100){
							c++;
						}
					}
				}
			}
		}
	}
	return c;
}

Problem109();
//38182