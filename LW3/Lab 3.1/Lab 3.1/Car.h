#pragma once
#include "Trans.h"
#include <iostream>
using namespace std;
class Car:public Trans
{
	double capacity;
public:
	Car();
	void input() override;
	void print() override;
	double cargoCapacity();
	~Car();
};

