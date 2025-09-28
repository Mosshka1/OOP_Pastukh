#include "Product.h"

Product::Product() {
    name = "";
    amount = 0;
    value = 0.0f;
}

Product::Product(const string& n, int a, float v) {
    setProduct(n, a, v);
}

Product::Product(const Product& other) {
    name = other.name;
    amount = other.amount;
    value = other.value;
}

Product::~Product() {
}

string Product::getName() { return name; }
int    Product::getAmount() { return amount; }
float  Product::getValue() { return value; }

void Product::setName(const string& n) {
    name = n;
}

void Product::setAmount(int a) {
    if (a < 0) a = 0;   
    amount = a;
}

void Product::setValue(float v) {
    if (v < 0.0f) v = 0.0f; 
    value = v;
}

void Product::setProduct(const string& n, int a, float v) {
    setName(n);
    setAmount(a);
    setValue(v);
}

void Product::printProduct() {
    cout << fixed << setprecision(2);
    cout << "Product: " << name
        << ", amount: " << amount
        << ", value: " << value
        << ", total: " << (amount * value)
        << endl;
}
