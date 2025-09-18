#include "Product.h"

int main() {
    Product p1;
    p1.setProduct("USB Cable", 5, 12.50f);
    p1.printProduct();

    Product p2("Keyboard", 2, 399.99f);
    p2.printProduct();

    Product p3 = p2; 
    p3.setAmount(3);
    p3.setValue(379.99f);
    p3.printProduct();

  
    Product bad("Test", -10, -5.0f);
    bad.printProduct();

    return 0;
}
