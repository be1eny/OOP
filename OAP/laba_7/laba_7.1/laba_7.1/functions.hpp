//
//  functions.hpp
//  laba_7.1
//
//  Created by Alex Samtsevich on 18.05.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#ifndef functions_hpp
#define functions_hpp

#include <stdio.h>

struct Stack {
  int data;        //информационный элемент
  Stack *head;     //вершина стека
  Stack *next;     //указатель на следующий элемент
};

void show(Stack *myStk);         //прототип
int pop(Stack *myStk);           //прототип
void push(int x, Stack *myStk);  //прототип
void elemDelete(Stack *myStk);


#endif /* functions_hpp */
