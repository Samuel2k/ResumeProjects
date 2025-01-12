#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

int main(int argc, char *argv[]) {
    char buffer[250];
    char *data;
    int sentinel;
    int sequence;
    int positiveMagnitudeCount;
    double magnitude;
    double sum;        // Sum of magnitudes
    double damageCost;
    double totalDamageCost;

    // Determine the filename and minimum magnitude based on command-line arguments
    char *filename;
    double minMagnitude = -3.0; // Default minimum magnitude

    if (argc == 1) {
        printf("No parameter detected, opening all_month.csv\n");
        filename = "all_month.csv"; // Default file
    } else if (argc == 2 || argc == 3) {
        filename = argv[1]; // Use the provided file
        if (argc == 3) {
            minMagnitude = atof(argv[2]); // Get the minimum magnitude if provided
        }
    } else {
        printf("Usage: %s [<filename>] [<min_magnitude>]\n", argv[0]);
        return -1;
    }

    printf("\n========================================\n");
    printf("Opening file %s with minimum magnitude %.1f...\n", filename, minMagnitude);

    FILE *USGSfile = fopen(filename, "r");

    if (USGSfile == NULL) {
        printf("Error opening file %s.\n", filename);
        return -1;
    }
    printf("The program was able to open the USGS file.\n");

    fgets(buffer, sizeof(buffer), USGSfile);  // Skip header line

    sentinel = 0;
    sum = 0.0;
    sequence = 0;
    positiveMagnitudeCount = 0;
    totalDamageCost = 0;

    while (fgets(buffer, sizeof(buffer), USGSfile)) {
        sentinel += 1;
        if (sentinel == 365) { // Set line count using sentinel here
            break;
        }

        // Parsing the CSV fields
        sequence += 1;

        data = strtok(buffer, ","); // Gets time
        char *time = data;  // Store time

        strtok(NULL, ","); // Skip latitude
        strtok(NULL, ","); // Skip longitude
        strtok(NULL, ","); // Skip depth

        data = strtok(NULL, ","); // Gets magnitude
        magnitude = atof(data);

        if (magnitude < minMagnitude) {
            continue; // Skip entries below the minimum magnitude
        }

        // Calculate damage cost
        damageCost = fabs(magnitude * 1000000);  // Total damage cost
        totalDamageCost += damageCost;

        printf("Time: %s\n", time);
        printf("Magnitude: %.2f\n", magnitude);
        printf("Damage cost: $%.2f\n", damageCost);

        if (magnitude > 0) {
            sum += magnitude; // Sum of all magnitudes
            positiveMagnitudeCount += 1;
        }

        strtok(NULL, ","); // Skip magType
        strtok(NULL, ","); // Skip nst
        strtok(NULL, ","); // Skip gap
        strtok(NULL, ","); // Skip dmin
        strtok(NULL, ","); // Skip rms
        strtok(NULL, ","); // Skip net
        strtok(NULL, ","); // Skip id
        strtok(NULL, ","); // Skip updated

        data = strtok(NULL, ","); // Get the place
        printf("Place: %s\n\n", data); // Display place
    }

    printf("====================================================================\n");
    printf("Sum of magnitudes: %.2f\n", sum);
    printf("Count of positive magnitudes: %d\n", positiveMagnitudeCount);
    if (positiveMagnitudeCount > 0) {
        printf("Average of magnitudes: %.2f\n", (sum / positiveMagnitudeCount));
    } else {
        printf("Average of magnitudes: N/A (no magnitudes meet criteria)\n");
    }
    printf("Average earthquake damage cost: $%.2f\n\n", (totalDamageCost / sentinel));

    printf("Program developed by Sam Espana. Updated by Samuel Krinhop. 12/6/24\n");
    fclose(USGSfile);  // Close the file
    return 0;
}
