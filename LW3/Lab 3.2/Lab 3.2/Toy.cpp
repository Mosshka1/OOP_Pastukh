#include "Toy.h"

Toy::Toy() : Goods(){material = "";}

void Toy::input()
{
    Goods::input();
    cout << "Material: ";
    getline(cin, material);
}

void Toy::print()
{
    Goods::print();
    cout << "\nMAterial: " << material << endl;
}

Toy::~Toy(){}
