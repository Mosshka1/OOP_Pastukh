#include "Money.h"

int main() {
    setlocale(0, "ukr");
    Money m1(10, 50);

    cout << "Початкове значення: ";
    m1.print();

    ++m1;
    cout << "Після ++: ";
    m1.print();

    m1--;
    cout << "Після --: ";
    m1.print();

    cout << "Перевірка !m1 (чи second != 0): " << (!m1 ? "true" : "false") << endl;

    Money m2 = m1 + 25;
    cout << "Після додавання скаляра +25: ";
    m2.print();

    string s = (string)m2;
    cout << "Як string: " << s << endl;

    Money m3 = Money::fromString("15 75");
    cout << "З рядка '15 75': ";
    m3.print();

    return 0;
}

