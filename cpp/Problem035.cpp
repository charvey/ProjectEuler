#include <iostream>
#include <vector>
using namespace std;

int Solve(int n);
bool IsCircularPrime(int n);
bool IsPrime(int n);

int main(){
	cout << Solve(1000000) << endl;

	return 0;
}

int Solve(int n){
	int count = 0;
	vector<bool> sieve (n,true);
	sieve[0] = sieve[1] = false;

	for(int i=0;i<n;i++){
		if(sieve[i]){
			for(int j=i+i;j<n;j+=i)
				sieve[j] = false;
		}
	}

	for(int i=1;i<n;i++){
		bool cp = true;
		int c = i;
		int m = 1;

		while(c>0){
			m*=10;
			c/=10;
		}

		c = i;

		do
		{
			cp = sieve[c];
			c = (c+m*(c%10))/10;
		} while(cp && c!=i);

		if(cp)
			count++;
	}

	return count;
}

bool IsCircularPrime(int n){
	int c = n;
	int m = 1;

	while(c>0)
	{
		m*=10;
		c /= 10;
	}

	c = n;

	do
	{
		if(!IsPrime(c))
			return false;

		c = (c+m*(c%10))/10;
	} while(c!=n);

	return true;
}

bool IsPrime(int n){
	if(n==1)
		return false;

	for(int i=2;i<=n/2;i++)
		if(n%i==0)
			return false;

	return true;
}
