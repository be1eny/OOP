//
//  main.cpp
//  laba_3.2
//
//  Created by Alex Samtsevich on 17.03.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main() {
  fstream file;
  string stroka, group, minGroup;
  int count = 0, min = 100;
  
  cout << "Введите строку из групп цифр: " << endl;
  getline(cin, stroka);
  file.open("file.txt", fstream::out);
  file << stroka << endl;
  file.close();
  
  file.open("file.txt", fstream::in);
  while(!file.eof()) {
    file >> group;
    count = group.size();
    if (count < min) {
      min = count;
      minGroup = group;
    }
  }
  cout << "Самая короткая группа: " << minGroup << endl;
  file.close();
}
