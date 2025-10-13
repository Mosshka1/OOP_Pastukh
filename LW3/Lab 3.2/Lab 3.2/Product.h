#pragma once
#include "Goods.h"
#include <iostream>
using namespace std;

class Product : public Goods
{
protected:
    string expirationDate;

public:
    Product();
    void input();
    void print();
    ~Product();
};

