#include "Car.h"
Car::Car() { capacity = 0; }

void Car::input() {
	cout << "\n Passenger car \n";
	Trans::input();
	cout << "Load capacity: ";
	cin >> capacity;
	cin.ignore(1000, '\n');
}
void Car::print() {
	cout << " Type: passenger car";
	Trans::print();
	cout<< "\nCapacity: " << capacity << " kilo " << endl;
}
double Car::cargoCapacity() { return capacity; }
Car::~Car(){}
