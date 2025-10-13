#include "Goods.h"
#include "Product.h"
#include "MilkProduct.h"
#include "Toy.h"
using namespace std;

int main()
{
    cout << "--Hierarchy--" << endl;
    Goods* db[3];
    for (int i = 0; i < 3; i++)
    {
        cout << "\nChoose type of product #" << i + 1 << endl;
        cout << "1 - Goods" << endl;
        cout << "2 - Product" << endl;
        cout << "3 - Milk product" << endl;
        cout << "4 - Toy" << endl;
        cout << "Your choise: ";
        int t;
        cin >> t;
        cin.ignore(10000, '\n');
        if (t == 1)db[i] = new Goods;
        else if (t == 2)db[i] = new Product;
        else if (t == 3)db[i] = new MilkProduct;
        else db[i] = new Toy;

        cout << "\nEntering info about object #" << i + 1 << endl;
        db[i]->input();
    }

    cout << "\nAll products" << endl;
    for (int i = 0; i < 3; i++)
    {
        db[i]->print();
        cout << endl;
    }

    for (int i = 0; i < 3; i++)
        delete db[i];
}
