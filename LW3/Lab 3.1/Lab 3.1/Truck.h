#pragma once
#include "Trans.h"
#include <iostream>
using namespace std;
class Truck : public Trans
{
    double baseCapacity;
    int hasTrailer;
public:
    Truck();
    void input() override;
    void print() override;
    double cargoCapacity();
    ~Truck();
};
