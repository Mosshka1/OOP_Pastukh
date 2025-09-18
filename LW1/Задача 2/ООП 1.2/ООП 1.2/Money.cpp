#include "Money.h"
#include <iomanip>

Money::Money() : size(0) {
    for (int i = 0; i < max_denom; i++) {
        denom[i] = 0;
        count[i] = 0;
    }
}

void Money::readFromKeyboard() {
    cout << "Скільки різних номіналів (макс " << max_denom << ")? ";
    int n;
    cin >> n;
    if (n < 1 || n > max_denom) {
        cout << "Некоректне значення!\n";
        return;
    }
    size = n;
    for (int i = 0; i < size; i++) {
        cout << "Номінал #" << i + 1 << ": ";
        cin >> denom[i];
        if (denom[i] < 0) denom[i] = 0;

        cout << "Кількість для " << denom[i] << ": ";
        cin >> count[i];
        if (count[i] < 0) count[i] = 0;
    }
}

void Money::setData(int d[], int c[], int n) {
    if (n < 1 || n > max_denom) return;
    size = n;
    for (int i = 0; i < n; i++) {
        denom[i] = (d[i] > 0) ? d[i] : 0;
        count[i] = (c[i] > 0) ? c[i] : 0;
    }
}

long long Money::getTotal() const {
    long long sum = 0;
    for (int i = 0; i < size; i++) {
        sum += 1LL * denom[i] * count[i];
    }
    return sum;
}

bool Money::canBuy(long long N) const {
    return getTotal() >= N;
}

long long Money::howManyItems(long long p) const {
    if (p <= 0) return 0;
    return getTotal() / p;
}

void Money::print() const {
    cout << "----- Кишеня -----\n";
    cout << left << setw(10) << "Nominal" << setw(10) << "Count" << setw(15) << "Subtotal" << "\n";
    for (int i = 0; i < size; i++) {
        long long sub = 1LL * denom[i] * count[i];
        cout << left << setw(10) << denom[i]
            << setw(10) << count[i]
            << setw(15) << sub << "\n";
    }
    cout << "-------------------\n";
    cout << "Total: " << getTotal() << " UAH\n";
}