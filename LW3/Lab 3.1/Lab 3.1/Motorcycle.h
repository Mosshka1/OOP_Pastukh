#pragma once
#include "Trans.h"
#include <iostream>
using namespace std;
class Motorcycle:public Trans
{
	double baseCapacity;
	int hasSidecar;
public:
	Motorcycle();
	void input() override;
	void print() override;
	double cargoCapacity();
	~Motorcycle();
};

