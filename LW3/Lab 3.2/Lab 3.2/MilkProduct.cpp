#include "MilkProduct.h"

MilkProduct::MilkProduct() : Product() {fat = 0;}

void MilkProduct::input()
{
    Product::input();
    cout << "Enter fat in per cent: "; cin >> fat;
    cin.ignore(10000, '\n');
}

void MilkProduct::print()
{
    Product::print();
    cout << "\nFat: " << fat << "%" << endl;
}

MilkProduct::~MilkProduct(){}