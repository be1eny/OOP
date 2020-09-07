//
//  main.cpp
//  laba_10.2
//
//  Created by Alex Samtsevich on 03.06.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include <iostream>
using namespace std;

void rectangle(float a, float b, int count) {

  do {
    if (a > b) {
      a = a - b;
      count++;
    }
    if (a < b) {
      b = b - a;
      count++;
    }
  } while ((a > 0 || b > 0) && a != b);
  
  cout << "Количество квадратов = " << count << endl;
}

int main() {
  float a, b;
  int count = 0;
  
  cout << "Введите А: ";
  cin >> a;

  cout << "Введите B: ";
  cin >> b;

  rectangle(a, b, count);
}
 
