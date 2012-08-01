#include <iostream>
using namespace std;

const int VALUES[] = {200,100,50,20,10,5,2,1};
const int SUM = 200;

int main(){
	int counts[] = {0,0,0,0,0,0,0,0};
	int count = 0;
	int sum = 0;

	while(counts[0]<SUM/VALUES[0]){
		for(int p=7;p>=0;p--){
			if(sum>SUM || counts[p]==SUM/VALUES[p]){
				sum -= counts[p]*VALUES[p];
				counts[p] = 0;
			}
			else{
				sum += VALUES[p];
				counts[p]++;
				p = 0;
			}
		}

		if(sum==SUM)
			count++;
	}

	cout << count << endl;

	return 0;
}
