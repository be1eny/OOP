//
//  main.c
//  hgjhgj
//
//  Created by Alex on 2/25/20.
//  Copyright © 2020 Alex. All rights reserved.
//

#include <stdio.h>

int main(int argc, const char * argv[]) {
  FILE *fA;
  FILE *fB;
  FILE *fC;
  char fileNameA[] = "fA.txt";
  char fileNameB[] = "fB.txt";
  char fileNameC[] = "fC.txt";
  int countColumnA = -1, countColumnB = -1, countColumnC;
  int i;
  int retA, retB;
  int numberA, numberB, numberC;
  
  fA = fopen(fileNameA, "r");
  if (fA == NULL) {
    printf("Can not open file. %s", fileNameA);
    return 1;
  }
  
  fB = fopen(fileNameB, "r");
  if (fB == NULL) {
    printf("Can not open file. %s", fileNameB);
    return 1;
  }
  
  fC = fopen(fileNameC, "w");
  if (fC == NULL) {
    printf("Can not open file. %s", fileNameC);
    return 1;
  }
  
  fscanf(fA, "%d", &countColumnA);
  fscanf(fB, "%d", &countColumnB);
  
  if(countColumnA != countColumnB) {
    printf("Your matrices of different sizes. \n");
  }
  else {
    countColumnC = countColumnA;
    fprintf(fC, "%d\n", countColumnC);
    
    i = 0;
    retA = retB = 0;
    
    do {
      
      if (i % countColumnC == 0 && i != 0) {
        fprintf(fC, "\n");
      }
      
      retA = fscanf(fA, "%d", &numberA);
      retB = fscanf(fB, "%d", &numberB);
      
      if (retA == -1 || retB == -1) break;
      numberC = numberA + numberB;
      
      fprintf(fC, "%d ", numberC);
      i++;
      
    } while(1);
  }
  
  fclose(fA);
  fclose(fB);
  fclose(fC);
}






//  ////////////////////////////////
//
//
//
//
//  do {
//    if (j % countColumnB == 0 && j != 0) {
//      printf("\n");
//    }
//
//    printf("%d ", numberB);
//    j += 1;
//  } while(retB != -1);
//
//  ////////////////////////////////
//
//  fC = fopen(fileNameC, "r");
//  if (fC == NULL) {
//    printf("Can not open file. %s", fileNameC);
//    return 1;
//  }
//
//
//  do {
//    if (j % countColumnB == 0 && j != 0) {
//      frintf(fC, "\n");
//    }
//    retA = fscanf(fA, "%d", &numberA);
//    retB = fscanf(fB, "%d", &numberB);
//    numberC = numberA + numberB;
//    fprintf(fC, "%d ", numberC);
//  } while(retA != -1 && retB != -1);
//
//  ////////////////////////////////
