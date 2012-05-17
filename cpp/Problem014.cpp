#include <iostream>
using namespace std;

long Collatzify(long n);
int CountChain(long n);

int main(){
	int maxI=1;
	int max = CountChain(maxI);

	for(long i=2;i<1000000;i++){
		int n = CountChain(i);

		if(n>max){
			max = n;
			maxI = i;
		}
	}

	cout << maxI << endl;

	return 0;
}


long Collatzify(long n){
	return n%2==0?n/2:3*n+1;
}

int CountChain(long n){
	int i=1;

	while(n!=1){
		n=Collatzify(n);
		i++;
	}

	return i;
}
