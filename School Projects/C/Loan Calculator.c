//Program developed by Sam Espana
//Program enhanced by Samuel M.J Krinhop
//Date 9/6/24

#include <stdio.h>      
int main() {
    //INPUT: Get/Set inputs/data
    float loan = 0.0;
    float interest = 0.0;
    int years = 0;
    printf("Loan Payment Calculator\n");
    printf("Enter loan amount: ");
    scanf("%f", &loan);
    printf("Loan amount = %2.f", loan);
    printf("\nEnter years: ");
    scanf("%d", &years);
    printf("\nEnter interest rate <5/10/15/20/25/30>: ");
    scanf("%f", &interest);
    //PROCESSING: Calculations
    if (years > 0) {
        loan += (loan * interest / 100 * years);
        printf("Loan plus interest = %2.f \n", loan);
        //Display monthly payment
        float monthlyPayment = loan / (years * 12);
        printf("Monthly payment is $%.2f\n", monthlyPayment, years); //OUTPUT
    }
    else //EXCEPTION: handling
    printf("%d Years must be a positive integer \n", years);
    printf("Program enhanced by Samuel M.J Krinhop. Date: 9/6/24");
    return 0;
}
