#include "Goods.h"

Goods::Goods()
{
    name = "";
    price = 0;
}

void Goods::input()
{
    cout << "Name of the product: ";
    getline(cin, name);
    cout << "Price: ";
    cin >> price;
    cin.ignore(10000, '\n');
}

void Goods::print()
{
    cout << "Name: " << name << "\nPrice: " << price << " UAH";
}
Goods::~Goods(){}
