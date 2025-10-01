#include "Money.h"

static bool isAllDigits(const string& s) {
    if (s.empty()) return false;
    for (size_t i = 0; i < s.size(); ++i) {
        char c = s[i];
        if (c < '0' || c > '9') return false;
    }
    return true;
}

static string trimBoth(const string& s) {
    int i = 0;
    int j = (int)s.size() - 1;
    while (i <= j && (s[i] == ' ' || s[i] == '\t' || s[i] == '\r')) ++i;
    while (j >= i && (s[j] == ' ' || s[j] == '\t' || s[j] == '\r')) --j;
    if (i > j) return "";
    return s.substr(i, j - i + 1);
}

static bool parseNonNegInt(const string& s, int& out) {
    try {
        int value = stoi(s);         
        if (value < 0) return false; 
        out = value;
        return true;
    }
    catch (...) {
        return false;                
    }
}

Money Money::input() {
    string line;
    int grn = 0;
    int kop = 0;

    while (true) {
        cout << "������ ����� (����� �����, >= 0): ";
        if (!getline(cin, line)) {
            cout << "������� �����. ��������� �� ���.\n";
            cin.clear();
            continue;
        }
        line = trimBoth(line);
        if (!parseNonNegInt(line, grn)) {
            cout << "������� ������. ������ ���� ����� ��� �����.\n";
            continue;
        }

        break;
    }

    while (true) {
        cout << "������ ������ (0..99): ";
        if (!getline(cin, line)) {
            cout << "������� �����. ��������� �� ���.\n";
            cin.clear();
            continue;
        }
        line = trimBoth(line);
        if (!parseNonNegInt(line, kop)) {
            cout << "������� ������. ������ ���� ����� �� 0 �� 99.\n";
            continue;
        }
        if (kop < 0 || kop > 99) {
            cout << "������ ����� ���� � ����� 0..99.\n";
            continue;
        }
        break;
    }

    return Money(grn, kop);
}

Money& Money::operator++() {
    ++first;
    ++second;
    return *this;
}

Money Money::operator++(int) {
    Money tmp = *this;
    ++(*this);
    return tmp;
}

Money& Money::operator--() {
    --first;
    --second;
    return *this;
}

Money Money::operator--(int) {
    Money tmp = *this;
    --(*this);
    return tmp;
}

bool Money::operator!() const {
    return second != 0;
}

Money Money::operator+(int scalar) const {
    
    return Money(first, second + scalar);
}

explicit Money::operator string() const {
    return to_string(first) + " ��� " + to_string(second) + " ���";
}

void Money::print() const {
    cout << first << " ��� " << second << " ���" << endl;
}
