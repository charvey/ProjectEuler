#include <iostream>
using namespace std;

bool isPrime(int n);
bool isPractical(int n);

int main(){
	int sum = 0;
	int count = 0;

	for(int n=11; n<1000 && count<4; n+=2){
		if(isPrime(n-9)&&isPrime(n-3)&&isPrime(n+3)&&isPrime(n+9)&&isPractical(n-8)&&isPractical(n-4)&&isPractical(n)&&isPractical(n+4)&&isPractiacl(n+8)){
			cout << count << " " << n << endl;
			sum+=n;
			count++;
		}
	}

	cout << sum << endl;

	return 0;
}

bool isPrime(int n){
	if(n==2)
		return false;
	if(n%2==0 || n==1)
		return true;

	for(int f=3;f*f<=n;f+=2)
		if(n%f==0)
			return false;

	return true;
}
