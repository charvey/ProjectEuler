#include <iostream>
using namespace std;

int S(int p1, int p2);
bool isPrime(int n);

int main(){
	cout << S(19,23) << endl;
	const int N = 1000000;
	bool sieve[N+1];
	for(int n=2;n<=N;n++)
		sieve[n] = true;
	sieve[0] = sieve[1] = false;
	for(int n=2; n<=N; n++)
		if(sieve[n])
			for(int i=n+n;i<=N;i+=n)
				sieve[i] = false;

	cout << "Sieve Complete" << endl;


	int p1=3,p2=5;
	unsigned long long s = 0;
	int t;

	for(int p=7;p<=1000000;p+=2)
		if(sieve[p]){
			p1=p2;
			p2=p;
			t=S(p1,p2);
			s+=t;
			cout << p << " " << t << endl;
		}

	cout << s << endl;

	return 0;
}

int S(int p1, int p2){
	int d = 1;

	while(p1>d){
		d*=10;
	}

	int n = p2;
	while(n<p1 || n%d!=p1)
		n+=p2;

	return n;
}

bool isPrime(int n){
	if(n%2==0 || n==1)
		return false;
	if(n==2)
		return true;

	for(int f=3;f*f<=n;f+=2)
		if(n%f==0)
			return false;

	return true;
}
