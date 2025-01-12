//Program developed by Sam Espana = Date: 9/13/24
#include <stdio.h>
#include <stdlib.h>

#include <stdbool.h> //This way the loop will continue - while (true)

#define SIZE 5

//Function prototype declarations
void udfDisplayArray(int intArr[], int size);

void udfDisplayArray(int intArr[], int size) {
    int i = 0;
    
    printf("Array size (number of elements) = %d", SIZE);
    printf("\nArray items listed below \n");
    
    for (i = 0; i < size; i++) {
        printf("%d\n", intArr[i]);
    }
}

int main() {
    int intArray[SIZE] = {0};
    int i, n, randN, max, sum = 0;
    double average;
    
    //system("cls"); //System call to the operating system
    printf("Program enhanced by Samuel Krinhop. 9/13/24 \n");
    
    while (true) {
        sum = 0; //Resets sum value to ensure the average of the 5 numbers is correct on loop
        
        printf("\nEnter random number maximum value > 0 (type 0 to quit): ");
        scanf("%d", &max);
        
        if (max == 0) {
            printf("Quit value (0) has been chosen.");
            break;
        }
        
        if (max > 0) { //PROCESSING
            for (i = 0; i < SIZE; ++i) {
                randN = rand() % (max + 1);
                intArray[i] = randN;
                sum += intArray[i];
            } //for
        
            udfDisplayArray(intArray, SIZE); //Function call OUTPUT
            average = (double) sum / SIZE;
            
            printf("Average = %.2lf", average);
            average = 0.0;
        } //if
        else {
            printf("Entered value cannot be negative. Try again.");
        }
    } //While
    printf("\n End of program \n");
    
    //System("pause");
    return 0;
    
} //main