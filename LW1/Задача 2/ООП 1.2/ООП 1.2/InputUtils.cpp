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
            cout << "¬вед≥ть ц≥ле число!\n";
            value = minVal - 1;
        }
        if (value < minVal || value > maxVal) {
            cout << "«наченн€ маЇ бути в д≥апазон≥ в≥д "
                << minVal << " до " << maxVal << ".\n";
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
            cout << "¬вед≥ть число\n";
            value = 0;
        }
        if (value <= 0) {
            cout << "«наченн€ маЇ бути б≥льше 0\n";
        }
    } while (value <= 0);
    return value;
}
