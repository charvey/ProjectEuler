#include <iostream>
using namespace std;

int trunc_l(int n);
int trunc_r(int n);

bool tpr(int n);
bool tpl(int n);

bool IsPrime(int n);

int main(){
	int sum = 0;
	int count = 0;

	for(int i=11; count<11;i++)
		if(IsPrime(i)&&tpr(i)&&tpl(i)){
			sum+=i;
			count++;
		}

	cout << sum << endl;

	return 0;
}

int trunc_l(int n){
	int m = 1;

	while((n/m)>=10){
		m *= 10;
	}

	return n%m;
}

int trunc_r(int n){
	return n/10;
}

bool tpl(int n){
	n = trunc_l(n);

	while(n!=0){
		if(!IsPrime(n))
			return false;
		n = trunc_l(n);
	}

	return true;
}

bool tpr(int n){
	n = trunc_r(n);

	while(n!=0){
		if(!IsPrime(n))
			return false;
		n = trunc_r(n);
	}

	return true;
}

bool IsPrime(int n){
	if(n==2)
		return true;
	if(n%2==0 || n==1)
		return false;

	for(int i=3;i<=n/3;i+=2)
		if(n%i==0)
			return false;

	return true;
}
