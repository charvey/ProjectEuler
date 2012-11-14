function Problem086(){
	var r = 0;
	for(var m1=1;;m1++){
		var m1_2 = m1*m1;
		for(var m2=1;m2<=m1;m2++){
			var m2_2 = m2*m2;
			var m12_2 = Math.pow(m1+m2,2);
			for(var m3=1;m3<=m2;m3++){
				var m3_2 = m3*m3;
				var m13_2 = Math.pow(m1+m3,2);
				var m23_2 = Math.pow(m2+m3,2);

				var d = Math.sqrt(Math.min(m1_2+m23_2,m2_2+m13_2,m3_2+m12_2));

				if(d%1==0){
					r++;
					if(r>1e6){
						return m1;
					}
				}
			}
		}
	}
}
