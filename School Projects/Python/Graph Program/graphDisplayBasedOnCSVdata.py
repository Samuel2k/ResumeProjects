import pandas as pd
import matplotlib.pyplot as plt

# Load dataset
data = pd.read_csv('Assignments\Assignment 5\data.csv')

# Visualization 1: Line Plot - Significant Strikes Landed

# Convert 'date' column to datetime format
data['date'] = pd.to_datetime(data['date'])

# Sort the data by date (optional, if not already sorted)
data = data.sort_values(by='date')

# Visualization: Line Plot - Significant Strikes Landed over Time
plt.figure(figsize=(8, 12))
plt.plot(data['date'], data['B_avg_SIG_STR_landed'], label='Avg. Blue-corner Sig. Strikes', alpha=0.6, color='blue')
plt.plot(data['date'], data['R_avg_SIG_STR_landed'], label='Avg. Red-corner Sig. Strikes', alpha=0.6, color='red')

plt.title('Average Significant Strikes Landed in UFC by Date (Colored by Corner)', fontsize=14)

plt.xlabel('Date of Fight', fontsize=12)
plt.ylabel('Avg. Sig. Strikes Landed', fontsize=12)

plt.legend()

plt.grid(alpha=0.3)

plt.xticks(rotation=45)  # Rotate x-axis labels for better readability

plt.show()


# Visualization 2: Scatter Plot - Age vs Control Time
plt.figure(figsize=(8, 12))

plt.scatter(data['B_age'], data['B_avg_CTRL_time(seconds)'], label='Blue-corner Fighters', alpha=0.1, color='blue')
plt.scatter(data['R_age'], data['R_avg_CTRL_time(seconds)'], label='Red-corner Fighters', alpha=0.1, color='red')

plt.title('Age vs Fight Control Time (Colored by Corner)', fontsize=14)

plt.xlabel('Age (Years)', fontsize=12)
plt.ylabel('Control Time (Seconds)', fontsize=12)

plt.legend()
plt.grid(alpha=0.3)
plt.show()
