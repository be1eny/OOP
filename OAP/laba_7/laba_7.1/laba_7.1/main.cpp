//
//  main.cpp
//  laba_7.1
//
//  Created by Alex Samtsevich on 18.05.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include <iostream>
#include "functions.hpp"
using namespace std;

int main() {
  setlocale(LC_ALL, "Rus");
  int choice;
  Stack *myStk = new Stack; //выделение памяти для стека
  myStk->head = NULL;       //инициализация первого элемента
  
  for (;;) {
    cout << "Выберите команду:" << endl;
    cout << "1 - Добавление элемента в стек" << endl;
    cout << "2 - Извлечение элемента из стека" << endl;
    cout << "3 - Вывод стека" << endl;
    cout << "4 - Удаление элемента" << endl;
    cout << "5 - Выход" << endl;
    cin >> choice;
    
    switch (choice) {
      case 1: cout << "Введите элемент: " << endl;
        cin >> choice;
        push(choice, myStk);
        break;
      case 2: choice = pop(myStk);
        if (choice != -1)
        cout << "Извлеченный элемент: " << choice << endl;
        break;
      case 3: cout << "Весь стек: " << endl;
        show(myStk);
        break;
      case 4:
        elemDelete(myStk);
        break;
      case 5:
        return 0;
        break;
    }
  }
  return 0;
}

