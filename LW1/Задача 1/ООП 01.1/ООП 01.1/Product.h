#pragma once
#include <string>
#include <iostream>
#include <iomanip>

using namespace std;  
class Product
{
private:
    string name;   
    int amount;    
    float value; 

public:
    Product();
    Product(const string& n, int a, float v);
    Product(const Product& other);

    ~Product();

    string getName();
    int getAmount();
    float getValue();

    void setName(const string& n);
    void setAmount(int a);
    void setValue(float v);

    void setProduct(const string& n, int a, float v);

    
    void printProduct();
};
