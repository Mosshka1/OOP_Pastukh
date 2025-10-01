#ifndef MONEY_H
#define MONEY_H

#include <iostream>
#include <string>
using namespace std;

class Money {
private:
    int first;   
    int second;  
    Money(int f, int s) : first(f), second(s) {}

public:
    Money() = delete; 

    static Money input();

    Money& operator++();       
    Money operator++(int);     
    Money& operator--();       
    Money operator--(int);     
    bool operator!() const;    
    Money operator+(int scalar) const;

    explicit operator string() const;
    void print() const;
};

#endif 
