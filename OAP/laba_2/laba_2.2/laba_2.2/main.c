//
//  main.c
//  laba_2.2
//
//  Created by Alex Samtsevich on 01.03.2020.
//  Copyright © 2020 Alex Samtsevich. All rights reserved.
//

#include <stdio.h>

#define MAX_SIZE 1024

int main() {
  FILE *f;
  FILE *g;
  
  char fileNameF[] = "f.txt";
  char fileNameG[] = "g.txt";
  int positiveNumbers[MAX_SIZE], negativeNumbers[MAX_SIZE];
  int numberF, retF = 0;
  int i, j;

  for (i = 0; i < MAX_SIZE; i++) {
    positiveNumbers[i] = 0;
    negativeNumbers[i] = 0;
  }
  
  ///////////////////////////////////
  
  f = fopen(fileNameF, "r");
  if (f == NULL) {
    printf("Can not open file. %s", fileNameF);
    return 1;
  }
  
  g = fopen(fileNameG, "w");
  if (g == NULL) {
    printf("Can not open file. %s", fileNameG);
    return 1;
  }

  ///////////////////////////////////
  
  int iP = 0, iN = 0;
  
  do {
    retF = fscanf(f, "%d", &numberF);
    if (retF == -1) break;
    if (numberF > 0 && iP < MAX_SIZE) {
      positiveNumbers[iP++] = numberF;
    }
    else if (numberF < 0 && iN < MAX_SIZE) {
      negativeNumbers[iN++] = numberF;
    }
  } while (1);
  
  int seqLenght = 5;
  int seqCount = (iP + iN) / (2 * seqLenght);
  
  if ((iP + iN) % (2 * seqLenght) != 0) {
    seqCount += 1;
  }
  
  for (j = 0; j < seqCount; j++) {
    for (i = j * seqLenght; i < j * seqLenght + seqLenght; i++) {
      if (positiveNumbers[i] != 0) {
        fprintf(g, "%d ", positiveNumbers[i]);
      }
      else break;
    }
    for (i = j * seqLenght; i < j * seqLenght + seqLenght; i++) {
      if (negativeNumbers[i] != 0) {
        fprintf(g, "%d ", negativeNumbers[i]);
      }
      else break;
    }
  }
  fclose(f);
  fclose(g);
}
