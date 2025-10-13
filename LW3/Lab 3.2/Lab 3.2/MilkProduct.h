#pragma once
#include "Product.h"
#include <iostream>
using namespace std;

class MilkProduct : public Product
{
protected:
    double fat;

public:
    MilkProduct();
    void input();
    void print();
    ~MilkProduct();
};

