#include "Product.h"
Product::Product() : Goods(){expirationDate = "";}

void Product::input()
{
    Goods::input();
    cout << "Expiration date: ";
    getline(cin, expirationDate);
}

void Product::print()
{
    Goods::print();
    cout << "\nExpiration date: " << expirationDate;
}

Product::~Product(){}
