//
//  Heap.hpp
//  laba_13.1
//
//  Created by Alex Samtsevich on 08.06.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#pragma once
#include <iostream>

struct AAA
{
  int x;
  void print();
  int getPriority() const;
};

namespace heap
{
  enum CMP
  {
    LESS = -1, EQUAL = 0, GREAT = 1
  };
  struct Heap
  {
    int size;
    int maxSize;
    void** storage;              // данные
    CMP(*compare)(void*, void*);
    Heap(int maxsize, CMP(*f)(void*, void*))
    {
      size = 0;
      storage = new void* [maxSize = maxsize];
      compare = f;
    };
    int left(int ix);
    int right(int ix);
    int parent(int ix);
    bool isFull() const
    {
      return (size >= maxSize);
    };
    bool isEmpty() const
    {
      return (size <= 0);
    };
    bool isLess(void* x1, void* x2) const
    {
      return compare(x1, x2) == LESS;
    };
    bool isGreat(void* x1, void* x2) const
    {
      return compare(x1, x2) == GREAT;
    };
    bool isEqual(void* x1, void* x2) const
    {
      return compare(x1, x2) == EQUAL;
    };
    void swap(int i, int j);
    void heapify(int ix);
    void insert(void* x);
    void* extractMax();
    void* extractMin();
    void* extractForIndex(int ix);
    void marger(Heap b);
    void scan(int i) const;
  };
  Heap create(int maxsize, CMP(*f)(void*, void*));
};

