/*
Barbara is a mathematician and a basketball player. She has found that the probability of scoring a point when shooting from a distance x is exactly (1 - x/q), where q is a real constant greater than 50.

During each practice run, she takes shots from distances x = 1, x = 2, ..., x = 50 and, according to her records, she has precisely a 2 % chance to score a total of exactly 20 points.

Find q and give your answer rounded to 10 decimal places.
*/

function Problem286(){
	var p=function(q){
		var s=0;
		for(var x=1;x<=50;x++){
			s+=(1-x/q);
		}
		return s;
	};

	console.log(p(50));
	console.log(p(500));
}

Problem286();