//
//  main.cpp
//  laba_3.1
//
//  Created by Alex Samtsevich on 10.03.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include <iostream>
#include <fstream>
using namespace std;

int main() {
  string nameFile1 = "file1.txt";
  string nameFile2 = "file2.txt";
  char text[100];

  ifstream file1(nameFile1);
  ofstream file2(nameFile2);
  
  if(!file1.is_open()) {
    cout << "Error! File is not open!" << endl;
  }
  else {
    while(!file1.eof()) {
      file1.getline(text, 100);
      if (text[0] == 'A' || text[0] == 'a') {
        file2 << text << endl;
      }
    }
  }
  
  file1.close();
  file2.close();
  
  int wordCount = 0;
  char str;
  
  ifstream readFile2(nameFile2);
  while(!readFile2.eof()) {
    str = readFile2.get();
    if(str == ' ' || str == '\n') {
      wordCount++;
    }
  }
  printf("Количество слов в файле: %i\n", wordCount);
  readFile2.close();
}
