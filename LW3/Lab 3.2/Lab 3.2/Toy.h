#pragma once
#include "Goods.h"
#include <iostream>
using namespace std;

class Toy : public Goods
{
protected:
    string material;

public:
    Toy();
    void input();
    void print();
    ~Toy();
};

