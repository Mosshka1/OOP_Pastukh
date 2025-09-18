#include "Money.h"

int main() {
    setlocale(0, "ukr");
    Money wallet;

    wallet.readFromKeyboard();
    wallet.print();

    long long need = 750;
    cout << "Чи вистачить на покупку за " << need << " грн? "
        << (wallet.canBuy(need) ? "Так" : "Ні") << "\n";

    long long price = 120;
    cout << "Скільки товарів по " << price << " грн можна купити? "
        << wallet.howManyItems(price) << "\n";

    int d[3] = { 10, 50, 200 };
    int c[3] = { 3, 2, 1 };
    wallet.setData(d, c, 3);
    wallet.print();

    return 0;
}


