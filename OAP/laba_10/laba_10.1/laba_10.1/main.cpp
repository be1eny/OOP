//
//  main.cpp
//  laba_10.1
//
//  Created by Alex Samtsevich on 03.06.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include <iostream>
using namespace std;

void F(int m, int n) {
  float F;
  int i = 0;
  
  do {
    F = ((m + n + 1) / 2);
    n++;
    i++;
    cout << "F = " << F << endl;
  } while (i < 100);
}

int main() {
  int m, n;
  
  cout << "Введите M: ";
  cin >> m;
  
  cout << "Введите N: ";
  cin >> n;

  if ((n + m) % 2 == 0) {
    if (n > m) {
      cout << "Max = " << n << endl;
     }
    if (m > n) {
      cout << "Max = " << m << endl;
    }
  }
  else {
    F(m, n);
  }
}
