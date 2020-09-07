#include <iostream>
#include <string>
#include <stdlib.h>
using namespace std;

void allNull();
void input();
void output();
void deleteCityDweller();
void search();


const int numberOfCityDweller = 100;
const int stringSize = 30;
int choise;

struct CityDweller {
  char name[stringSize];
  char address[stringSize];
  unsigned int year : 12;
  unsigned int month : 4;
  unsigned int day : 5;
  int numberOfSex;
};

enum sex {
  male = 1,
  female
};


CityDweller CityDwellerNumber[numberOfCityDweller];
CityDweller deleteCityDwellerNumber;

int main() {
  while (choise != 5) {
    cout << "1 - Ввод информации" << endl;
    cout << "2 - Вывод всей информации" << endl;
    cout << "3 - Удаление" << endl;
    cout << "4 - Поиск" << endl;
    cout << "5 - Выход" << endl;
    cout << "Введите нужный пункт: ";
    cin >> choise;
    switch (choise) {
      case 1: input(); break;
      case 2: output(); break;
      case 3: deleteCityDweller(); break;
      case 4: search(); break;
    }
  }
}

void input() {
  cout << "_________________________________________" << endl;
  int problem = 0;
  int date;
  int i;
  
  cout << "Введите номер жителя которого вы хотите ввести: ";
  cin >> i;
  
  if (i > 0 && i < numberOfCityDweller) {
    cout << i  << " горожанин: " << endl;
    if (problem == 0) {
      cin.getline(CityDwellerNumber[i].name, stringSize);
    }
    cout << "Имя: ";
    cin.getline(CityDwellerNumber[i].name, stringSize);
    
    cout << "Адрес: ";
    cin.getline(CityDwellerNumber[i].address, stringSize);

    
    cout << "Введите пол (1 - мужской, 2 - женский): ";
    cin >> CityDwellerNumber[i].numberOfSex;
    
    cout << "Дата рождения: " << endl;
    cout << "   Год: ";
    cin >> date; CityDwellerNumber[i].year = date;   //внесение даты через
    cout << "   Месяц: ";                                //промежуточную переменную
    cin >> date; CityDwellerNumber[i].month = date;
    cout << "   День: ";
    cin >> date; CityDwellerNumber[i].day = date;
    cout << endl;
  }
  else {
    cout << "Число не из правильного диапазона" << endl;
  }
}

void output() {
  cout << "_________________________________________" << endl << endl;
  
  for (int i = 0; i < numberOfCityDweller; i++) {
    if (CityDwellerNumber[i].year) {
      cout << i  << " горожанин: " << endl;
      
      cout << "Имя: " << CityDwellerNumber[i].name << endl;
      cout << "Адрес: " << CityDwellerNumber[i].address << endl;
      if (CityDwellerNumber[i].numberOfSex == male) {
        cout << "Пол: мужской" << endl;
      }
      else if (CityDwellerNumber[i].numberOfSex == female) {
        cout << "Пол: женский" << endl;
      }
      cout << "Дата рождения: " << CityDwellerNumber[i].day << "." << CityDwellerNumber[i].month << "." << CityDwellerNumber[i].year << endl << endl;
    }
  }
}

void deleteCityDweller() {
  cout << "_________________________________________" << endl << endl;
  int deleteNumber;

  cout << "Какого горожанина удалить? Для удаления всех введите 666" << endl << "Введите: ";
  cin >> deleteNumber;

  if (deleteNumber != 666) {
    CityDwellerNumber[deleteNumber] = deleteCityDwellerNumber;
  }
  if (deleteNumber == 666) {
    for (int i = 0; i < numberOfCityDweller; i++)
    {
      CityDwellerNumber[i] = deleteCityDwellerNumber;
    }
  }
}

void search() {
  cout << "_________________________________________" << endl << endl;
  int year;

  cout << "Введите год рождения: "; cin >> year;
  cout << endl;

  for (int i = 0; i < numberOfCityDweller; i++) {
    if (CityDwellerNumber[i].year == year) {
      cout << i  << "  горожанин: " << endl;
      cout << "Имя: " << CityDwellerNumber[i].name << endl;
      cout << "Адрес: " << CityDwellerNumber[i].address << endl;
      if (CityDwellerNumber[i].numberOfSex == male) {
        cout << "Пол: мужской" << endl;
      }
      else if (CityDwellerNumber[i].numberOfSex == female) {
        cout << "Пол: женский" << endl;
      }
      cout << "Дата рождения: " << CityDwellerNumber[i].day << "." << CityDwellerNumber[i].month << "." << CityDwellerNumber[i].year << endl << endl;
    }
  }
}
