#include "Money.h"
#include "InputUtils.h"
#include <iostream>
using namespace std;

int main() {
    setlocale(0, "ukr");

    int n = readIntInRange("Скільки елементів у гаманці? ", 1, 20);

    Money wallet[20];
    for (int i = 0; i < n; ++i) {
        cout << "\nЕлемент #" << i + 1 << ":\n";
        wallet[i].input();
    }

    cout << "\nВаш набір грошей:\n";
    for (int i = 0; i < n; ++i) wallet[i].print();

    long long N = readPositiveLL("\nСума покупки: ");
    cout << (canBuy(wallet, n, N) ? "Грошей вистачить.\n" : "Грошей не вистачить.\n");

    long long p = readPositiveLL("Ціна товару: ");
    cout << "Максимум можна купити: " << howManyItems(wallet, n, p) << " шт\n";

    cout << "Загальна сума: " << totalAmount(wallet, n) << " грн\n";
}
