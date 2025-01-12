#include <stdio.h>
#define SIZE 3
#define CITY_SIZE 50

int compare(char *s1, char *s2);

int main() {
    int loopProgram = 0;
    printf("Program developed by Sam Espana, Updated by Samuel (M.J) Krinhop. Date: 10/11/24\n");
    while (loopProgram == 0) {
        

        int seq[SIZE] = {1,2,3/*,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20*/}; //1-20

        char *city[SIZE] = {
        "Long Prairie", "New Prague", "St. Vincent"/*, "New Ulm", "Red Lake",
        "Staples", "Bow String", "Detroit Lakes", "Alexandria", "Pipestone",
        "Morris", "Milaca", "Evergreen", "Rush City", "Nisswa",
        "Cottage Grove", "Walker", "Dumont", "Granite Falls", "Brandon"*/
        }; // All cities involved

        char *date[SIZE] = {
        "1860-61", "12/16/1860", "12/28/1880"/*, "2/5/1881", "2/6/17",
        "9/3/17", "12/23/28", "1/28/39", "2/15/50", "9/28/64",
        "7/9/75", "3/5/79", "4/16/79", "4/24/81", "9/27/82",
        "6/4/93", "2/9/94", "4/29/11"*/
        };

        float mag[] = {5, 4.7, 3.6};
        //float cost[] = {10000, 20000, 30000}; NOT NEEDED ON THIS PROJ

        char key[CITY_SIZE];

        printf("#\tName\t\t    Date\t\tMagnitude\tDamage Cost\n");
        for (int i = 0; i < SIZE; i++) {
            printf("%d\t%-20s%-20s%.2f\t\t%.2f\n", seq[i], city[i], date[i], mag[i], (mag[i]*1000000));
        }

        printf("\nEnter city (or type 'q' to quit): ");
        scanf("%49[^\n]%*c", key); //Reads up to 49 characters

        loopProgram = compare("q", key);
        if (loopProgram == 1) {
            printf("Thank you. Goodbye.\n");
            break;
        }

        int found = 0;
        for (int i = 0; i < SIZE; i++) {
            found = compare(city[i], key);
            if (found == 1) {
                printf("%s is found at position %d. Date = %s, the earthquake magnitude = %.2f, earthquake damage cost = %.2f\n\n",
                    key, seq[i], date[i], mag[i], (mag[i]*1000000));
                break;
            }
        }

        if (found == 0) {
            printf("%s is not found in the array\n\n", key);
        }
    }
    return 0;
}

int compare(char *s1, char *s2) {
    int i;
    for (i = 0; s1[i] == s2[i]; i++) {
        if (s1[i] == '\0') {
            return 1;
        }

    }
    return 0;
}