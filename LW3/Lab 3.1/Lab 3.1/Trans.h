#pragma once
#include <string>
using namespace std;

class Trans
{
protected:
	string brand;
	string number;
	double speed;
public:
	Trans();
	virtual void input();
	virtual void print();
	virtual double cargoCapacity() = 0;
	virtual ~Trans();
};

