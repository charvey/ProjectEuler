#include <iostream>
using namespace std;

unsigned long next_prime(unsigned long n);
bool isPrime(unsigned long n);

unsigned long a(unsigned long n);
unsigned long b(int n);
unsigned long f(unsigned long n);

int main(){
	unsigned long sum;
	const unsigned long MOD = 12345678910111;

	for(int n=1; n<=100000; n++){
		sum += b(n)%MOD;
		cout << n << " " << sum << endl;
	}

	cout << sum << endl;

	return 0;
}

unsigned long a(unsigned long n){
	if(n==1)
		return 100000000000000;

	return next_prime(a(n-1));
}

unsigned long b(int n){
	return f(a(n));
}

unsigned long f(unsigned long n){
	unsigned long a=0;
	unsigned long b=1;
	unsigned long c=0;
	unsigned long i=0;

	while(i<n){
		a = b;
		b = c;
		c = a+b;
		i++;
	}

	return c;
}

unsigned long next_prime(unsigned long n){
	n += n%2+1;

	while(!isPrime(n))
		n+=2;

	return n;
}

bool isPrime(unsigned long n){
	if(n==2)
		return true;
	if(n%2==0 || n==1)
		return false;

	for(int f=3;f*f<=n;f+=2)
		if(n%f==0)
			return false;

	return true;
}
