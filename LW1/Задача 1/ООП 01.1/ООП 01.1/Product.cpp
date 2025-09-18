#include "Product.h"
#include <iostream>
#include <iomanip>
#include <algorithm>

using namespace std; 

Product::Product() : name(""), amount(0), value(0.0f) {}

Product::Product(const string& name, int amount, float value) {
    setProduct(name, amount, value);
}

Product::Product(const Product& other)
    : name(other.name), amount(other.amount), value(other.value) {
}

Product::~Product(void) {}

string Product::getName() { return name; }
int    Product::getAmount() { return amount; }
float  Product::getValue() { return value; }

void Product::setProduct(const string& n, int a, float v) {
    setName(n);
    setAmount(a);
    setValue(v);
}

void Product::setName(const string& n) { name = n; }

void Product::setAmount(int a) {
    amount = max(0, a); 
}

void Product::setValue(float v) {
    value = (v < 0.0f) ? 0.0f : v;
}

void Product::printProduct() {
    cout << fixed << setprecision(2);
    cout << "Product: " << name
        << ", amount: " << amount
        << ", value: " << value
        << ", total: " << (amount * value)
        << endl;
}
