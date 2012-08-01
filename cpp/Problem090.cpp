#include <iostream>
#include <set>
#include <vector>
using namespace std;



int main(){
	vector<set<int>> arrangements;
	set<int> a;

	for(var d1=0;d1<10;d1++)
	for(var d2=d1+1;d2<10;d2++)
	for(var d3=d2+1;d3<10;d3++)
	for(var d4=d3+1;d4<10;d4++)
	for(var d5=d4+1;d5<10;d5++)
	for(var d6=d5+1;d6<10;d6++){
		a.clear();
		a.insert(d1);
		a.insert(d2);
	}


	return 0;
}
