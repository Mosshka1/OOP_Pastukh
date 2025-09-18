#ifndef MONEY_H
#define MONEY_H

#include <iostream>
#include <string>
using namespace std;

class Money {
private:
    int first;   
    int second; 
public:
    Money(int f = 0, int s = 0);
    Money& operator++();    
    Money operator++(int);  
    Money& operator--();    
    Money operator--(int); 
    bool operator!() const;
    Money operator+(int scalar) const;
    operator string() const;
    static Money fromString(const string& str);
    void print() const;
};

#endif

