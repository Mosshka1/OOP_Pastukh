#include <iostream>
#include "Money.h"
using namespace std;

int main() {
    setlocale(0, "ukr");
    int n;
    cout << "Кількість різних номіналів: ";
    cin >> n;

    if (n <= 0 || n > 20) {
        cout << "Некоректне n!\n";
        return 0;
    }

    Money wallet[20];

    for (int i = 0; i < n; i++) {
        cout << "\nЕлемент #" << i + 1 << endl;
        wallet[i].input();
    }

    cout << "\nВаш набір грошей:\n";
    for (int i = 0; i < n; i++)
        wallet[i].print();

    long long N;
    cout << "\nСума покупки: ";
    cin >> N;
    if (canBuy(wallet, n, N))
        cout << "Грошей вистачить.\n";
    else
        cout << "Грошей не вистачить.\n";

    long long p;
    cout << "Ціна товару: ";
    cin >> p;
    cout << "Максимум можна купити: "
        << howManyItems(wallet, n, p) << " шт\n";

    cout << "Загальна сума: "
        << totalAmount(wallet, n) << " грн\n";

    return 0;
}
