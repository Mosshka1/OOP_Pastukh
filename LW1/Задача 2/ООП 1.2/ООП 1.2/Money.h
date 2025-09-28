#pragma once
#include <iostream>
using namespace std;

namespace AppConstants {
    static const int CoinsArr[4] = { 1, 2, 5, 10 };
    static const int BillsArr[6] = { 20, 50, 100, 200, 500, 1000 };
}

class Money {
private:
    int  nominal;   
    int  count;     
    bool isCoin;    
    bool isValidCoin(int n);
    bool isValidBill(int n);
    void setNominal(int n);  
    void setCount(int c);  

public:
    Money();               
    void input();          
    void print();

    int  getNominal();
    int  getCount();
    bool getIsCoin();

    long long amount();
};

long long totalAmount(Money arr[], int n);
bool       canBuy(Money arr[], int n, long long sum);
long long  howManyItems(Money arr[], int n, long long price);
