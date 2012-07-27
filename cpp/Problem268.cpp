#include <iostream>
using namespace std;

bool valid(long n);
int p(int n, int x);

int main(){
	cout << valid(210) << endl;
	const long N = 10000000000000000;
	long count = 0;

	for(int n=1;n<N;n++)
		if(valid(n))
			count++;

	cout << count << endl;

	return 0;
}

int p(int n,int x){
	return n%x==0;
}

bool valid(long n){
	int s =
		p(n,02)+p(n,03)+p(n,05)+p(n,07)+p(n,11)+
		p(n,13)+p(n,17)+p(n,19)+p(n,23)+p(n,29)+
		p(n,31)+p(n,37)+p(n,41)+p(n,43)+p(n,47)+
		p(n,53)+p(n,59)+p(n,61)+p(n,67)+p(n,71)+
		p(n,73)+p(n,79)+p(n,83)+p(n,89)+p(n,97);

	return s>=4;
}
