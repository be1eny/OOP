//
//  functions.cpp
//  laba_7.1
//
//  Created by Alex Samtsevich on 18.05.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include "functions.hpp"

#include <iostream>
#include "functions.hpp"
using namespace std;

void push(int x, Stack *myStk) {
  Stack* e = new Stack;    //выделение памяти для нового элемента
  e->data = x;             //запись элемента x в поле v
  e->next = myStk->head;   //перенос вершины на следующий элемент
  myStk->head = e;         //сдвиг вершины на позицию вперед
}

int pop(Stack *myStk) {
  if (myStk->head == NULL) {
    cout << "Стек пуст!" << endl;
    return -1;               //если стек пуст - возврат -1
  }
  else {
    Stack *e = myStk->head;          //е - переменная для хранения адреса элемента
    int a = myStk->head->data;       //запись числа из поля data в переменную a
    myStk->head = myStk->head->next; //перенос вершины
    delete e;                        //удаление временной переменной
    return a;                        //возврат значения удаляемого элемента
  }
}

void show(Stack *myStk) {
  Stack* e = myStk->head;
  int a;
  if (e == NULL) {
    cout << "Стек пуст!" << endl;
  }
  while (e != NULL) {
    a = e->data;          //запись значения в переменную a
    cout << a << " ";
    e = e->next;
  }
  cout << endl;
}

void elemDelete(Stack *myStk) {
  Stack* e = myStk->head;
  Stack* prev = NULL;
  
  while (e != NULL) {
  if (e->data < 0) {
    if (e == myStk->head) {
      myStk->head = e->next;
      free(e);
      e->data = NULL;
      e->next = NULL;
      break;
    }
    else {
      prev->next = e->next;
      free(e);
      e->data = NULL;
      e->next = NULL;
    }
  }
  prev = e;
  e = e->next;
  }
}
