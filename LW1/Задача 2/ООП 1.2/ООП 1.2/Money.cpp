#include "Money.h"
#include "InputUtils.h" 

bool Money::isValidCoin(int n) {
    for (int i = 0; i < 4; ++i) {
        if (AppConstants::CoinsArr[i] == n) return true;
    }
    return false;
}
bool Money::isValidBill(int n) {
    for (int i = 0; i < 6; ++i) {
        if (AppConstants::BillsArr[i] == n) return true;
    }
    return false;
}

Money::Money() {
    nominal = 0;
    count = 0;
    isCoin = true; 
}

void Money::setNominal(int n) {
    nominal = n;
}
void Money::setCount(int c) {
    if (c < 0) c = 0;
    count = c;
}
void Money::input() {
    char t;
    do {
        cout << "Це монета (m) чи купюра (b)? ";
        cin >> t;
    } while (!(t == 'm' || t == 'M' || t == 'b' || t == 'B'));
    isCoin = (t == 'm' || t == 'M');

    cout << "Дозволені номінали: ";
    if (isCoin) {
        for (int v : AppConstants::CoinsArr) cout << v << " ";
    }
    else {
        for (int v : AppConstants::BillsArr) cout << v << " ";
    }
    cout << "\n";

    int n;
    bool ok = false;
    do {
        n = (int)readPositiveLL("Введіть номінал: ");
        ok = isCoin ? isValidCoin(n) : isValidBill(n);
        if (!ok) {
            cout << "Недопустимий номінал\n";
        }
    } while (!ok);
    setNominal(n);

    int c;
    do {
        c = (int)readPositiveLL("Введіть кількість: ");
        if (c <= 0) {
            cout << "Кількість має бути більше 0\n";
        }
    } while (c <= 0);
    setCount(c);
}
void Money::print() {
    cout << (isCoin ? "Монета " : "Купюра ")
        << nominal << " грн × " << count
        << " = " << amount() << " грн\n";
}

int  Money::getNominal() { return nominal; }
int  Money::getCount() { return count; }
bool Money::getIsCoin() { return isCoin; }

long long Money::amount() {
    return 1LL * nominal * count;
}

long long totalAmount(Money arr[], int n) {
    long long s = 0;
    for (int i = 0; i < n; ++i) s += arr[i].amount();
    return s;
}
bool canBuy(Money arr[], int n, long long sum) {
    return totalAmount(arr, n) >= sum;
}
long long howManyItems(Money arr[], int n, long long price) {
    if (price <= 0) return 0;
    return totalAmount(arr, n) / price;
}
