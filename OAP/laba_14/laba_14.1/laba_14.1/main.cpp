//
//  main.cpp
//  laba_14.1
//
//  Created by Alex Samtsevich on 08.06.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include <iostream>
#include<string>
#include<ctime>
using namespace std;

struct Obj {
  string name = "";

  int getKey() {
    int sum = 0;
    for (int i = 0; i < name.length(); i++) {
      sum += (i + 1) * name[i];
    }
    return sum;
  }
};

struct hashmas {
  int cur_size = 0; // текущий размер
  int size;
  Obj** mas;

  hashmas(int s) {
    size = s;
    mas = new Obj*[size];
    for (int i = 0; i < size; i++)
      mas[i] = nullptr;
  }
  ~hashmas() {// конструктор/ деструктур
    for (int i = 0; i < size; i++)
      delete mas[i];
    delete[]mas;
  }
};

int Hash(int key, int size, int p) {
  int a = 7;
  int b = 3571;
  return ((a*key+p)%b)%size;
}

bool add(hashmas& mas, Obj* obj, int& a) {
  if (mas.size == mas.cur_size)
    return false;
  int p = 0;
  int key1 = Hash(obj->getKey(), mas.size, p++);
  while (mas.mas[key1] != nullptr) {
    key1 = Hash(key1, mas.size, p++);
    a++;
  }
  mas.mas[key1] = obj;
  return true;
}
int search(hashmas& mas, Obj* obj) {
  int p = 0;
  int key1 = Hash(obj->getKey(), mas.size, p++);
  while (mas.mas[key1]->getKey() != obj->getKey()) {
    key1 = Hash(key1, mas.size, p++);
  }
  return key1;
}
void print(hashmas& mas) {
  for (int i = 0; i < mas.size; i++)
    if (mas.mas[i] != nullptr)
      cout << i << " " << mas.mas[i]->getKey() << " " << mas.mas[i]->name << endl;
}

int main() {
  int n = 800;
  int col = 0;
  hashmas mas1(n);
  for (int i = 0; i < n-1; i++) {
    string str = "Alex" + to_string(i);
    Obj* obj = new Obj;
    obj->name = str;
    add(mas1, obj, col);
  }
  string str = "linejka";
  Obj* obj = new Obj;
  obj->name = str;
  add(mas1, obj, col);
  clock_t b = clock();
  int a = search(mas1, obj);
  clock_t e = clock();
  print(mas1);
  cout << "Colisions: " << col << endl;
  cout << a << " " << ((double)(e - b) / CLOCKS_PER_SEC) << endl;


}
