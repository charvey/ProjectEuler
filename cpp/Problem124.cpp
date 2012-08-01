#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int rad(int n);
int Solve(int n, int k);
void swap(int& a, int& b);

struct n_r_pair {
	int n;
	int r;
};

bool comp(n_r_pair a,n_r_pair b);

int main(){
	cout << (rad(504)==42) << " " << Solve(10,4) << " "  << (Solve(10,4)==8) << endl;

	cout << Solve(100000,10000) << endl;

	return 0;
}

int rad(int n){
	int r;

	if(n%2==0){
		r=2;
		do{n/=2;} while(n%2==0);
	}
	else
		r=1;

	for(int i=3;i<=n;i+=2)
		if(n%i==0){
			r*=i;
			do{n/=i;} while(n%i==0);
		}

	return r;
}

int Solve(int n, int k){
	vector<n_r_pair> pairs;

	for(int i=1;i<=n;i++){
		n_r_pair p;
		p.n=i;
		p.r=rad(i);

		pairs.push_back(p);
//		pairs[i].n=i;
//		pairs[i].r=rad(i);
	}

	sort(pairs.begin(),pairs.end(),comp);

	for(int i=0;i<n;i++)
		cout << (i+1) << " " << pairs[i].n << " " << pairs[i].r << " " << (pairs[i].n==pairs[i].r) << endl;

	return pairs[k-1].n;
}

void swap(int& a, int& b){
	int t(a);
	a=b;
	b=t;
}

bool comp(n_r_pair a,n_r_pair b){
	return a.r < b.r;
}
