#pragma once
#include <iostream>
using namespace std;

class Money {
private:
    int nominal;  
    int count;     
    bool isCoin;  

public:
    Money();
    Money(int n, int c, bool coin);

    void input();
    void print();

    int getNominal();
    int getCount();
    bool getIsCoin();
    long long amount();
};
long long totalAmount(Money arr[], int n);
bool canBuy(Money arr[], int n, long long sum);
long long howManyItems(Money arr[], int n, long long price);
