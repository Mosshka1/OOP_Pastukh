#include "Trans.h"
#include <iostream>
#include <string>

using namespace std;

Trans::Trans() {
	brand = "";
	number = "";
	speed = 0;
}

void Trans::input(){
	cout << " Brand: ";
	getline(cin, brand);
	cout << " Number: ";
	getline(cin, number);
	cout << " Speed: ";
	cin >> speed;
}

void Trans::print() {
	cout << "\nBrand: " << brand << "\nNumber: " << number << "\nSpeed: " << speed
		<< " km per hour ";
}

Trans::~Trans(){}
