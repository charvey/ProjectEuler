/*
If a box contains twenty-one coloured discs, composed of fifteen blue discs and six red discs, and two discs were taken at random, it can be seen that the probability of taking two blue discs, P(BB) = (15/21)*(14/20) = 1/2.

The next such arrangement, for which there is exactly 50% chance of taking two blue discs at random, is a box containing eighty-five blue discs and thirty-five red discs.

By finding the first arrangement to contain over 10^12 = 1,000,000,000,000 discs in total, determine the number of blue discs that the box would contain.
*/

/*

(B/n)*((B-1)/(n-1))=1/2
(B^2-B)/(n^2-n)=1/2
2*(B^2-B)=n^2-n
0=2*B^2-2*B+(-n(n+1))

(-b+-sqrt(b^2-4ac))/2a

(2+-sqrt(4-4*2*(n^2-n)))/4

(2+-sqrt(4-8*n^2-8*n))/4

(2+-2sqrt(1-2*n^2-2*n))/4

(1/2) +- (1/2)*sqrt(1-2*(n^2+n))

*/

function Problem100(){

}

Problem100();