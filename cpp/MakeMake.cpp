#include <iostream>
#include <string>
#include <vector>
#include <set>
#include <stdio.h>
#include <stdlib.h>
using namespace std;

const char tab = '\t';

void Flags();
void MakeMakeMakeMake();
void Make(string name, vector<string> dependencies, vector<string> commands);

void BuildFile(string name);
void BuildFile(string sourceName, string outputName);

//PE Specific

void Problem(int n);
void AllProblems(int n);

//

void WriteDependencies();

void Clean();

set<string> Dependencies;

int main(){
	Flags();
	MakeMakeMakeMake();

	AllProblems(374);

	WriteDependencies();
	Clean();

	return 0;
};

void Flags(){
	cout << "CC=g++" << endl;
}

void Make(string name, vector<string> dependencies, vector<string> commands){
	cout << name << ":";
	int l = dependencies.size();
	for(int i=0;i<l;i++)
		cout << " " << dependencies[i];
	cout << endl;
	l = commands.size();
	for(int i=0;i<l;i++)
		cout << tab << commands[i] << endl;
}

void MakeMakeMakeMake(){
	vector<string> dependencies;
	vector<string> commands;

	dependencies.push_back("MakeMake.o");
	Dependencies.insert("MakeMake");
	commands.push_back("./MakeMake.o > makefile");

	Make("make",dependencies,commands);
}

void BuildFile(string name){
	BuildFile(name+".cpp",name+".o");
}

void BuildFile(string sourceName, string outputName){
	vector<string> dependencies;
	vector<string> commands;

	dependencies.push_back(sourceName);
	commands.push_back("$(CC) "+sourceName+" -o "+outputName);

	Make(outputName,dependencies,commands);
}

void WriteDependencies(){
	set<string>::iterator it;

	for(it=Dependencies.begin();it!=Dependencies.end();it++)
		BuildFile(*it);
}

void Clean(){
	vector<string> dependencies;
	vector<string> commands;

	commands.push_back("rm -f *.o");

	Make("clean",dependencies,commands);
}

void AllProblems(int n){
	for(int i=1;i<=n;i++)
		Problem(i);
}

void Problem(int n){
	vector<string> dependencies;
	vector<string> commands;

	char name[10];
	char outputName[12];
	char command[14];

	if(n<10)
		sprintf(name,"Problem00%d",n);
	else if(n<100)
		sprintf(name,"Problem0%d",n);
	else
		sprintf(name,"Problem%d",n);

	sprintf(outputName,"%s.o",name);
	sprintf(command,"./%s",outputName);

	dependencies.push_back(outputName);
	Dependencies.insert(name);
	commands.push_back(command);

	Make(name,dependencies,commands);
}
