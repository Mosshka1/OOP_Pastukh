#pragma once
#include <iostream>
using namespace std;

const int max_denom = 10;
class Money {
private:
    int denom[max_denom];
    int count[max_denom];
    int size;             

public:
    Money();
    void readFromKeyboard();
    void setData(int d[], int c[], int n);
    long long getTotal() const;              
    bool canBuy(long long N) const;         
    long long howManyItems(long long p) const; 
    void print() const;
};
