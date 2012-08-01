#include <iostream>
using namespace std;

bool isHamming(int n, int t);
bool isPrime(int n);

int main(){
	int count = 0;

	for(int i=1; i<=1000000000; i++)
		if(isHamming(i,100)){
			count++;
			//cout << count << " " << i << endl;
		}

	cout << count << endl;

	return 0;
}

bool isHamming(int n, int t){
	while(n%2==0)
		n/=2;

	for(int f=3; f<=t; f+=2)
		while(n%f==0)
			n/=f;

	return n<=t;
}

bool isPrime(int n){
	if(n%2==0 || n==1)
		return false;
	if(n==2)
		return true;

	for(int i=3;i<=n/3;i+=2)
		if(n%i==0)
			return false;

	return true;
}
