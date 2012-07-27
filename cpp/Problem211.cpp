#include <iostream>
using namespace std;

unsigned long sosod(int n);
bool iPS(unsigned long);

int main(){
	const int N = 64000000;
	cout << sosod(N) << endl;
	cout << iPS(N) << endl;

	int s = 1;

	for(int i=2;i<N;i++){
		if(iPS(sosod(i))){
			s+=i;
			cout << i << " " << sosod(i) << endl;
		}
	}

	cout << s << endl;

	return 0;
}

unsigned long sosod(int n){
	unsigned long s = 1;
	unsigned int s2 = 4;

	int i;
	for(i=2;s2<=n;i++,s2=i*i){
		s+=s2;
		if(s2<n)
			s+=(n/i)*(n/i);

	}

	return s+n*n;
}

bool iPS(unsigned long n){
	unsigned long f1 = 1;
	unsigned long f2 = n/f1;

	while(f1<f2){
		f2 = (f1+f2)/2;
		f1 = n/f2;
	}

	return f1==f2;
}
