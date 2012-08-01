#include <iostream>
using namespace std;

int spf(int n);
long solve(int n, int k);

int main(){
	cout << spf(120) << endl;
	cout << solve(10,3) << endl;

	cout << solve(20000000,15000000) << endl;

	return 0;
}

long solve(int n, int k){
	long s=0;
	long max = k > n-k ? k : n-k;
	long min = k < n-k ? k : n-k;

	for(int i=max+1;i<=n;i++)
		s+=spf(i);
	for(int i=2;i<=min;i++)
		s-=spf(i);


	return s;
}

int spf(int n){
	int s = 0;

	while(n%2==0){
		s+=2;
		n/=2;
	}

	for(int f=3;f<=n;f+=2){
		while(n%f==0){
			s+=f;
			n/=f;
		}
	}

	return s;
}
