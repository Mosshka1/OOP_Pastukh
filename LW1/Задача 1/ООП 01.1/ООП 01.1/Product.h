#pragma once
#include <string>
using namespace std;
class Product
{
public:
    string name;
    int amount;
    float value;

public:
    Product();
    Product(const string& name, int amount, float value);
    Product(const Product& other);
    ~Product(void);

    string getName();
    int getAmount();
    float getValue();

    void setProduct(const string& n, int a, float v);
    void setName(const string& n);
    void setAmount(int a);
    void setValue(float v);

    void printProduct();
};

