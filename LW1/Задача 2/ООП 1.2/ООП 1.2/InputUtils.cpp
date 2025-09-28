#include "InputUtils.h"
#include <iostream>
using namespace std;

bool isNumber(const string& s) {
    if (s.empty()) return false;
    for (char c : s) {
        if (!isdigit(c)) return false;
    }
    return true;
}

int readIntInRange(const string& prompt, int minVal, int maxVal) {
    string input;
    int value;
    do {
        cout << prompt;
        cin >> input;
        if (isNumber(input)) {
            value = stoi(input);
        }
        else {
            cout << "������ ���� �����!\n";
            value = minVal - 1;
        }
        if (value < minVal || value > maxVal) {
            cout << "�������� �� ���� � ������� �� "
                << minVal << " �� " << maxVal << ".\n";
        }
    } while (value < minVal || value > maxVal);
    return value;
}

long long readPositiveLL(const string& prompt) {
    string input;
    long long value;
    do {
        cout << prompt;
        cin >> input;
        if (isNumber(input)) {
            value = stoll(input);
        }
        else {
            cout << "������ �����\n";
            value = 0;
        }
        if (value <= 0) {
            cout << "�������� �� ���� ����� 0\n";
        }
    } while (value <= 0);
    return value;
}
