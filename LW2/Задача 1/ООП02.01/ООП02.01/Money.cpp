#include "Money.h"
#include <sstream>
#include <stdexcept>
Money::Money(int f, int s) : first(f), second(s) {}
Money& Money::operator++() {
    ++first;
    ++second;
    return *this;
}
Money Money::operator++(int) {
    Money temp = *this;
    ++(*this);
    return temp;
}
Money& Money::operator--() {
    --first;
    --second;
    return *this;
}
Money Money::operator--(int) {
    Money temp = *this;
    --(*this);
    return temp;
}
bool Money::operator!() const {
    return second != 0;
}
Money Money::operator+(int scalar) const {
    return Money(first, second + scalar);
}
Money::operator string() const {
    return to_string(first) + " грн " + to_string(second) + " коп";
}
Money Money::fromString(const string& str) {
    int f = 0, s = 0;
    istringstream iss(str);
    if (!(iss >> f >> s)) {
        throw invalid_argument("Невірний формат рядка. Очікується: '<first> <second>'");
    }
    return Money(f, s);
}
void Money::print() const {
    cout << first << " грн " << second << " коп" << endl;
}


