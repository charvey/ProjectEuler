#include <iostream>
#include <set>
using namespace std;

unsigned long S(int n);
set<unsigned long>* init_dsps(int n=200);
unsigned long* init_dspl(int n=200);
int DigitSum(unsigned long n);

int main(){
	cout << (DigitSum(512)==8) << endl;

	cout << (S(2)==512) << (S(10)==614656) << (S(15)==60466176) << endl;


	cout << S(30) << endl;

	return 0;
}

unsigned long S(int n){
	set<unsigned long>* dsps = init_dsps();
	unsigned long* dspl = init_dspl();

	int count = 0;
	int ds = 0;

	for(unsigned long i=10;;i++){
		if(i%10==0)
			ds = DigitSum(i);
		else
			ds++;

		while(i > dspl[ds])
		{
			dspl[ds] *= ds;
			dsps[ds].insert(dspl[ds]);
		}

		if(dsps[ds].find(i) != dsps[ds].end()){
			count++;
			if(count == n){
//				delete dsps;
//				delete dspl;

				return i;
			}
		}
	}
}

set<unsigned long>* init_dsps(int n){
	set<unsigned long>* dsps = new set<unsigned long>[n];

	dsps[0].insert(-1);
	dsps[1].insert(-1);
	for(int j=2; j<n; j++){
		dsps[j].insert(1);
		dsps[j].insert(-1);
	}

	return dsps;
}

unsigned long* init_dspl(int n){
	unsigned long* dspl = new unsigned long[n];

	dspl[0] = -1;
	dspl[1] = -1;
	for(int j=2; j<n; j++)
		dspl[j] = j;

	return dspl;
}

int DigitSum(unsigned long n){
	return n==0?0:DigitSum(n/10)+n%10;
}
