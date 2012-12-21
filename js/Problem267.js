/*
You are given a unique investment opportunity.

Starting with £1 of capital, you can choose a fixed proportion, f, of your capital to bet on a fair coin toss repeatedly for 1000 tosses.

Your return is double your bet for heads and you lose your bet for tails.

For example, if f = 1/4, for the first toss you bet £0.25, and if heads comes up you win £0.5 and so then have £1.5. You then bet £0.375 and if the second toss is tails, you have £1.125.

Choosing f to maximize your chances of having at least £1,000,000,000 after 1,000 flips, what is the chance that you become a billionaire?

All computations are assumed to be exact (no rounding), but give your answer rounded to 12 digits behind the decimal point in the form 0.abcdefghijkl.
*/

/*
(1-f)*(1+2*f)
(1-f+2f-2ff)
(1+f-2ff)

(1+af)(1+bf)
1+af+bf+abff

(1+af+bf+abff)(1+cf)
1+af+bf+abff+cf+acff+bcff+abcfff

*/

function Problem267(){
	var e=function(f,c,r,s){
		console.log(c,s);

		if(r==0){
			return c;
		}

		return .5*(e(f,c*(1-f),r-1,s+'W')+e(f,c*(1+2*f),r-1,s+'L'));
	};

	var p=function(f,c,r){
		console.log(f,c,r);

		if(c*Math.pow(1+2*f,r)<1e9){
			return 0;
		}
		if(c*Math.pow(1-f,r)>=1e9){
			return 1;
		}

		return .5*(p(f,c*(1-f),r-1)+p(f,c*(1+2*f),r-1));
	};

	console.log(p(1/4,1,100,''));
}

Problem267();