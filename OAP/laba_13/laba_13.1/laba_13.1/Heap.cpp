//
//  Heap.cpp
//  laba_13.1
//
//  Created by Alex Samtsevich on 08.06.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//


#include "Heap.hpp"
#include <iostream>
#include <iomanip>
void AAA::print()
{
  std::cout << x;
}
int AAA::getPriority() const
{
  return x;
}
namespace heap
{
  Heap create(int maxsize, CMP(*f)(void*, void*))
  {
    return *(new Heap(maxsize, f));
  }
  int Heap::left(int ix)
  {
    return (2 * ix + 1 >= size) ? -1 : (2 * ix + 1);
  }
  int Heap::right(int ix)
  {
    return (2 * ix + 2 >= size) ? -1 : (2 * ix + 2);
  }
  int Heap::parent(int ix)
  {
    return (ix + 1) / 2 - 1;
  }
  void Heap::swap(int i, int j)
  {
    void* buf = storage[i];
    storage[i] = storage[j];
    storage[j] = buf;
  }
  void Heap::heapify(int ix)
  {
    int l = left(ix), r = right(ix), irl = ix;
    if (l > 0)
    {
      if (isGreat(storage[l], storage[ix])) irl = l;
      if (r > 0 && isGreat(storage[r], storage[irl]))   irl = r;
      if (irl != ix)
      {
        swap(ix, irl);
        heapify(irl);
      }
    }
  }
  void Heap::insert(void* x)
  {
    int i;
    if (!isFull())
    {
      storage[i = ++size - 1] = x;
      while (i > 0 && isLess(storage[parent(i)], storage[i]))
      {
        swap(parent(i), i);
        i = parent(i);
      }
    }
  }
  void* Heap::extractMax()
  {
    void* rc = nullptr;
    if (!isEmpty())
    {
      rc = storage[0];
      storage[0] = storage[size - 1];
      size--;
      heapify(0);
    } return rc;
  }
  void Heap::scan(int i) const     //Вывод значений элементов на экран
  {
    int probel = 20;
    std::cout << '\n';
    if (size == 0)
      std::cout << "Куча пуста";
    for (int u = 0, y = 0; u < size; u++)
    {
      std::cout << std::setw(probel + 10) << std::setfill(' ');
      ((AAA*)storage[u])->print();
      if (u == y)
      {
        std::cout << '\n';
        if (y == 0)
          y = 2;
        else
          y += y * 2;
      }
      probel /= 2;
    }
    std::cout << '\n';
  }

  void* Heap::extractMin()
  {
    void* rc = nullptr;
    if (!isEmpty())
    {
      int min = 0;
      for (int i = 0; i < size; ++i)
      {
        if (((AAA*)storage[i])->x < ((AAA*)storage[min])->x)min = i;
      }
      rc = storage[min];
      if (size - 1 != min)storage[min] = storage[size - 1];
      else storage[min] = storage[size - 2];
      size--;
      heapify(0);
    } return rc;
  }

  void* Heap::extractForIndex(int ix)
  {
    void* rc = nullptr;
    if (!isEmpty())
    {

      rc = storage[ix];
      storage[ix] = storage[size - 1];
      size--;
      heapify(0);
    } return rc;
  }
  void Heap::marger(Heap b)
  {
    /*function merge(a, b : Heap):
    for i = 0 to b.heapSize - 1
    a.heapSize = a.heapSize + 1
    a[a.heapSize - 1] = b[i]
    a.heapify()*/
    int s = size;
    for (int i = 0; i < b.size; ++i, ++s)
    {
      size++;
      storage[s] = b.storage[i];
    }
    heapify(0);

  }
}
