#include "Money.h"
#include <iostream>
using namespace std;

int main() {
    setlocale(0, "ukr");

    cout << "Створюємо Money тільки через введення користувача!\n";
    Money m1 = Money::input();

    cout << "Ви ввели: ";
    m1.print();

    ++m1;
    cout << "Після ++: ";
    m1.print();

    m1--;
    cout << "Після --: ";
    m1.print();

    cout << "Перевірка чи копійки не = 0: " << (!m1 ? "true" : "false") << "\n";

    cout << "Додамо до копійок +25:\n";
    Money m2 = m1 + 25;
    m2.print();

    string s = static_cast<string>(m2); 
    cout << "Як рядок (через змінну): " << s << "\n";

}
