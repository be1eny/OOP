//
//  functions.hpp
//  laba_8.1
//
//  Created by Alex Samtsevich on 19.05.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#ifndef functions_hpp
#define functions_hpp

#include <stdio.h>

struct list {
  float number;
  list *next;
};



void insert(list *&);
float del(list *&);
void search(list *p);
int IsEmpty(list *);
void printList(list *);
void menu(void);
void avarage(list *);
void toFile(list *&p);
void fromFile(list *&p);
void insertFromFile(list *&p, float value);
void minMax(list *p);

#endif /* functions_hpp */
