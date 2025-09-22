#include "Money.h"

Money::Money() {
    nominal = 0;
    count = 0;
    isCoin = true;
}

Money::Money(int n, int c, bool coin) {
    nominal = n;
    count = c;
    isCoin = coin;
}

void Money::input() {
    char t;
    do {
        cout << "Це монета (m) чи купюра (b)? ";
        cin >> t;
    } while (!(t == 'm' || t == 'M' || t == 'b' || t == 'B'));
    isCoin = (t == 'm' || t == 'M');
    cout << "Дозволені номінали: ";
    if (isCoin)  cout << "1 2 5 10\n";
    else         cout << "20 50 100 200 500 1000\n";

    bool ok = false;
    do {
        cout << "Введіть номінал: ";
        cin >> nominal;
        if (isCoin)
            ok = (nominal == 1 || nominal == 2 || nominal == 5 || nominal == 10);
        else
            ok = (nominal == 20 || nominal == 50 || nominal == 100 ||
                nominal == 200 || nominal == 500 || nominal == 1000);
        if (!ok) cout << "Недопустимий номінал! Спробуйте ще раз.\n";
    } while (!ok);

    do {
        cout << "Введіть кількість: ";
        cin >> count;
        if (count <= 0) cout << "Кількість має бути > 0. Спробуйте ще раз.\n";
    } while (count <= 0);
}

void Money::print() {
    if (isCoin)
        cout << "Монета ";
    else
        cout << "Купюра ";

    cout << nominal << " грн × " << count
        << " = " << amount() << " грн\n";
}

int Money::getNominal() { return nominal; }
int Money::getCount() { return count; }
bool Money::getIsCoin() { return isCoin; }

long long Money::amount() {
    return 1LL * nominal * count;
}

long long totalAmount(Money arr[], int n) {
    long long s = 0;
    for (int i = 0; i < n; i++)
        s += arr[i].amount();
    return s;
}

bool canBuy(Money arr[], int n, long long sum) {
    return totalAmount(arr, n) >= sum;
}

long long howManyItems(Money arr[], int n, long long price) {
    if (price <= 0) return 0;
    return totalAmount(arr, n) / price;
}
