/*
A set of disks numbered 1 through 100 are placed in a line in random order.

What is the probability that we have a partial derangement such that exactly 22 prime number discs are found away from their natural positions?
(Any number of non-prime disks may also be found in or out of their natural positions.)

Give your answer rounded to 12 places behind the decimal point in the form 0.abcdefghijkl.
*/

function Problem239(){
	var p=[2,3];
	for(var i=5;i<=100;i++){
		var f=true;
		for(var j=0;p[j]<=Math.sqrt(i);j++){
			if(i%p[j]==0){
				f=false;
				break;
			}
		}
		if(f){
			p.push(i);
		}
	}

	return p.length;
}

Problem239();

/*
0.001887854841

25 pick 3 * (96 pick 1) * .. * (75 pick 1) * 75!
over
100!

25!*96*..*75*75!
22!*3!*100!

25*24*23*75*74
6*100*99*98*97

23*75
99*98*97

25!
22!*3!

*/