#include <iostream>
#include "Trans.h"
#include "Car.h"
#include "Motorcycle.h"
#include "Truck.h"
using namespace std;
int main() {
	cout << " -Base of transport- " << endl;
	Trans* db[3];
    for (int i = 0; i < 3; i++)
    {
        cout << "\nChose the type of transport #" << i + 1 << endl;
        cout << "1 - Passenger car" << endl;
        cout << "2 - Motorcycle" << endl;
        cout << "3 - Truck" << endl;
        cout << "Your choice: ";
        int t;
        cin >> t;
        cin.ignore(10000, '\n');
        if (t == 1) db[i] = new Car;
        else if (t == 2) db[i] = new Motorcycle;
        else db[i] = new Truck;
        db[i]->input();
    }
    cout << "\n -All transport- " << endl;
    for (int i = 0; i < 3; i++) db[i]->print();
    cout << "\n Min car Capacity: ";
    double need;
    cin >> need;
    cout << "\nResults" << endl;
    bool found = false;
    for (int i = 0; i < 3; i++)
    {
        if (db[i]->cargoCapacity() >= need)
        {
            db[i]->print();
            found = true;
        }
    }

    if (!found)
        cout << "None found!" << endl;

    for (int i = 0; i < 3; i++)
    {
        delete db[i];
    }
}
