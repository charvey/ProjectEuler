#include <iostream>
#include <climits>
using namespace std;

typedef int* DigitCount;

int Solve();
DigitCount DigitCounts(int n);
bool DigitCountCompare(DigitCount a, DigitCount b);

int main(){
	cout << Solve() << endl;

	return 0;
}

int Solve(){
	for(int i=1;i<INT_MAX;i++){
		DigitCount count;
		count = DigitCounts(i);

		if(DigitCountCompare(count,DigitCounts(2*i))
		   && DigitCountCompare(count,DigitCounts(3*i))
		   && DigitCountCompare(count,DigitCounts(4*i))
		   && DigitCountCompare(count,DigitCounts(5*i))
		   && DigitCountCompare(count,DigitCounts(6*i)))
			return i;


	}

	return 0;
}

DigitCount DigitCounts(int n){
	int* counts = new int [10];

	while(n>0){
		counts[n%10]++;
		n/=10;
	}

	return counts;
}

bool DigitCountCompare(DigitCount a, DigitCount b){
	for(int i=0;i<=9;i++)
		if(a[i]!=b[i])
			return false;

	return true;
}
