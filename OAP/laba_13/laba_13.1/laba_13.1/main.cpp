//
//  main.cpp
//  laba_13.1
//
//  Created by Alex Samtsevich on 08.06.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include <iostream>
#include "Heap.hpp"
using namespace std;

heap::CMP cmpAAA(void* a1, void* a2)  //‘ункци€ сравнени€
{
#define A1 ((AAA*)a1)
#define A2 ((AAA*)a2)
  heap::CMP rc = heap::EQUAL;
  if (A1->x > A2->x)
    rc = heap::GREAT;
  else
    if (A2->x > A1->x)
      rc = heap::LESS;
  return rc;
#undef A2
#undef A1
}
//-------------------------------
int main()
{
  setlocale(LC_ALL, "rus");
  int k, choice;
  heap::Heap h1 = heap::create(30, cmpAAA);
  heap::Heap h2 = heap::create(30, cmpAAA);
  AAA* b1 = new AAA; b1->x = 12; h2.insert(b1);
  AAA* b2 = new AAA; b2->x = 3; h2.insert(b2);
  AAA* b3 = new AAA; b3->x = 5; h2.insert(b3);
  AAA* b4 = new AAA; b4->x = 16; h2.insert(b4);
  AAA* b5 = new AAA; b5->x = 9; h2.insert(b5);

  for (;;)
  {
    cout << "1 - вывод кучи на экран" << endl;
    cout << "2 - добавить элемент" << endl;
    cout << "3 - удалить максимальный элемент" << endl;
    cout << "4 - удалить минимальный элемент" << endl;
    cout << "5 - удалить элемент по индексу" << endl;
    cout << "6 - слияние двух куч" << endl;
    cout << "0 - выход" << endl;
    cout << "сделайте выбор" << endl;  cin >> choice;
    switch (choice)
    {
    case 0:  exit(0);
    case 1:  h1.scan(0);
      break;
    case 2: {  AAA* a = new AAA;
      cout << "введите ключ" << endl;   cin >> k;
      a->x = k;
      h1.insert(a);
    }
        break;
    case 3:   h1.extractMax();
      break;
    case 4:
      h1.extractMin();
      break;
    case 5:
      int index;
      cout << "введите индекс:" << endl;
      cin >> index;
      h1.extractForIndex(index);
      break;
    case 6:
      h1.marger(h2);
      break;
    default:  cout << endl << "введена неверная команда!" << endl;
    }
  } return 0;
}
