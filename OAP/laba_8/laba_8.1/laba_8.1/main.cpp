////
////  main.cpp
////  laba_8.1
////
////  Created by Alex Samtsevich on 19.05.2020.
////  Copyright © 2020 Alex Samtsevich. All rights reserved.
////

#include <iostream>
#include <fstream>

#include "functions.hpp"
using namespace std;

int main() {
    list *first = NULL;
    int choice = 0;

    while (choice != 7) {
      menu();
      cout << "Выберите нужный пункт: ";
      cin >> choice;
      
      switch (choice) {
          
        case 1:
          insert(first);
          printList(first);
          break;
          
        case 2:
          if (!IsEmpty(first)) {
            if (del(first)) {
              printList(first);
            }
            else {
              cout << "Число не найдено" << endl;
            }
          }
          else {
            cout << "Список пуст" << endl;
          }
          break;
          
        case 3:
          search(first);
          break;
          
        case 4:
          avarage(first);
          break;
          
        case 5:
          toFile(first);
          break;
          
        case 6:
          fromFile(first);
          break;
          
        case 7:
          minMax(first);
          break;

          
        default:
          cout << "Неправильный выбор" << endl;
          menu();
          break;
      }
    }
   cout << "Конец" <<endl;
   return 0;
}
