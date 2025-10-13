#pragma once
#include <string>
#include <iostream>
using namespace std;
class Goods
{
protected:
    string name;
    double price;
public:
    Goods();
    virtual void input();
    virtual void print();
    virtual ~Goods();
};

