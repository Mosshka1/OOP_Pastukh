#include "Motorcycle.h"
Motorcycle::Motorcycle() { baseCapacity = 0; hasSidecar = 0; }

void Motorcycle::input() {
	cout << "\n Motorcycle \n";
	Trans::input();
	cout << " Do it have sideCar?(1-yes;2-no): ";
	cin >> hasSidecar;
	cout << " Capacity with sideCar: ";
	cin >> baseCapacity;
	cin.ignore(1000, '\n');
}
void Motorcycle::print() {
	cout << "Type: motocycle";
	Trans::print();
	if (hasSidecar == 1) cout << " sideCar: yes";
	else cout << " sideCar: no";
	cout << "\nCapacity: " << cargoCapacity() << " kilo " << endl;
}
double Motorcycle::cargoCapacity() {
	if (hasSidecar == 1) return baseCapacity;
	else return 0;
}
Motorcycle::~Motorcycle(){}