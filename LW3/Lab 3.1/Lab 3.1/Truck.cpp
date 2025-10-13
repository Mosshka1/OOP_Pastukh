#include "Truck.h"
Truck::Truck(){baseCapacity = 0;hasTrailer = 0;}
void Truck::input() {
	cout << "\n Truck \n";
    Trans::input();
    cout << "Do it have trailer?(1-yes;2-no): ";
    cin >> hasTrailer;
    cout << "Base capacity: ";
    cin >> baseCapacity;
    cin.ignore(10000, '\n');
}
void Truck::print() {
    cout << "Type: Truck"; 
    Trans::print();
    if (hasTrailer == 1) cout << " Trailer:yes ";
    else cout << " Trailer:no ";
    cout << "\nCapacity: " << cargoCapacity() << " kilo " << endl;
}
double Truck::cargoCapacity()
{
    if (hasTrailer == 1) return baseCapacity * 2;
    else return baseCapacity;
}

Truck::~Truck(){}