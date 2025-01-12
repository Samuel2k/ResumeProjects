#ANSWERS FOR PROJECT SHOULD CONTAIN BOTH THE WRITTEN ANSWER AND THE CODE REQUIRED TO FIND IT
#Pandas is not required. Just answer the questions correctly

import pandas as pd

df = pd.read_csv("Week4/vgsales.csv")

'''
# print(df)
# print(df.head())
# print(df.columns)

# df2 = df.head()

# print(type(df))
# print(type(df.columns))

# Series
'''

# value_counts() Returns a series containing counts of unique values.

#Display occurence count in publisher category
'''
df2 = df.Publisher
print(df2.value_counts())
'''

#idxmax() Returns an index of the first occurence of a maximum over requested column
# print(df.idxmax("JP_Sales"))
'''
df_japan = df.JP_Sales
print(df.loc[[df_japan.idxmax()]])
'''





# 1. Which Publisher Had the Most Sales?
'''
publisher_entry_count = df['Publisher'].value_counts() # Count the number of entries (games) for each publisher

# Find the publisher with the most entries
top_publisher_entries = publisher_entry_count.idxmax()
top_entry_count = publisher_entry_count.max()

print(f"The publisher with the most entries in the data is '{top_publisher_entries}' with {top_entry_count} games.") # Print the result

ANSWER: The publisher with the most entries in the data is 'Electronic Arts' with 1351 games.
'''

# 2. Which publisher had the highest global sales total across all their games?
# Sum the Global_Sales for each publisher and identify the publisher with the highest total.
'''
publisher_sales = df.groupby('Publisher')['Global_Sales'].sum() # Group by Publisher and sum the Global_Sales

# Find the publisher with the highest total global sales
top_publisher = publisher_sales.idxmax()
top_sales = publisher_sales.max()

print(f"The publisher with the highest total global sales is {top_publisher} with {top_sales} sales.")

ANSWER: The publisher with the highest total global sales is Nintendo with 1786.56 sales.
'''



# 3. How Many Games Are Available for Each Platform?
'''
platform_games_count = df.groupby('Platform')['Name'].count() # Group by Platform and count the number of games for each platform

print(platform_games_count)

ANSWER:
2600     133
3DO        3
3DS      509
DC        52
DS      2163
GB        98
GBA      822
GC       556
GEN       27
GG         1
N64      319
NES       98
NG        12
PC       960
PCFX       1
PS      1196
PS2     2161
PS3     1329
PS4      336
PSP     1213
PSV      413
SAT      173
SCD        6
SNES     239
TG16       2
WS         6
Wii     1325
WiiU     143
X360    1265
XB       824
XOne     213
'''



# 4. How many games are listed for each platform in the dataset?
# (Count the number of entries (games) for each platform.)
'''
platform_game_count = df['Platform'].value_counts() # Count the number of games for each platform

print(platform_game_count) # Display the count for each platform


ANSWER:
DS      2163
PS2     2161
PS3     1329
Wii     1325
X360    1265
PSP     1213
PS      1196
PC       960
XB       824
GBA      822
GC       556
3DS      509
PSV      413
PS4      336
N64      319
SNES     239
XOne     213
SAT      173
WiiU     143
2600     133
NES       98
GB        98
DC        52
GEN       27
NG        12
SCD        6
WS         6
3DO        3
TG16       2
GG         1
PCFX       1
'''



# Which Game Genre Is the Most Popular?
# 5. Which game genre appears most frequently in the dataset?
# Count how many times each genre appears and identify the most common one.
'''
genre_count = df['Genre'].value_counts() # Count how many times each genre appears

# Get the most frequent genre
most_frequent_genre = genre_count.idxmax()
most_frequent_genre_count = genre_count.max()

# Print the full genre count
print("Genre count for each genre:")
print(genre_count)

print(f"The most frequent genre is {most_frequent_genre}, appearing {most_frequent_genre_count} times in the dataset.")

ANSWER:
Action          3316
Sports          2346
Misc            1739
Role-Playing    1488
Shooter         1310
Adventure       1286
Racing          1249
Platform         886
Simulation       867
Fighting         848
Strategy         681
Puzzle           582

The most frequent genre is Action, appearing 3316 times in the dataset.
'''



# Total Sales in Japan
# 6. What are the total sales in Japan across all games?
# Sum up all the JP_Sales.
'''
total_japan_sales = df['JP_Sales'].sum() # Calculate the total sales in Japan

print(f"The total sales in Japan across all games is {total_japan_sales}.") # Print the total sales in Japan

ANSWER: The total sales in Japan across all games is 1291.0200000000002.
'''

# 7. Average Global Sales
# What is the average global sales figure for all games in the dataset?
# Calculate the average of the Global_Sales column.
'''
average_global_sales = df['Global_Sales'].mean() # Calculate the average global sales

print(f"The average global sales figure for all games in the dataset is {average_global_sales:.2f}.") # Print the average global sales

ANSWER: The average global sales figure for all games in the dataset is 0.54.
'''



# 8. Find the Oldest Game
# What is the oldest game listed in the dataset?
# Identify the game with the earliest year in the Year column.
'''
oldest_game = df.loc[df['Year'].idxmin()] # Find the oldest game in the dataset

print(f"The oldest game listed in the dataset is '{oldest_game['Name']}' released in {oldest_game['Year']}.") # Print the details of the oldest game

ANSWER: The oldest game listed in the dataset is 'Asteroids' released in 1980.0.
'''



# 9. List Games Released After 2000
# How many games were released after the year 2000?
# Filter the dataset for games with a Year greater than 2000 and count them.
'''
games_after_2000 = df[df['Year'] > 2000] # Filter the dataset for games released after 2000

number_of_games_after_2000 = games_after_2000.shape[0] # Count the number of games released after 2000

print(f"The number of games released after the year 2000 is {number_of_games_after_2000}.") # Print the count and list the games

# List the games released after 2000
print("\nList of games released after the year 2000:")
print(games_after_2000[['Name', 'Year']])

ANSWER: The number of games released after the year 2000 is 14004.
List of games released after the year 2000:
                                                   Name    Year
0                                            Wii Sports  2006.0
2                                        Mario Kart Wii  2008.0
3                                     Wii Sports Resort  2009.0
6                                 New Super Mario Bros.  2006.0
7                                              Wii Play  2006.0
...                                                 ...     ...
16593                Woody Woodpecker in Crazy Castle 5  2002.0
16594                     Men in Black II: Alien Escape  2003.0
16595  SCORE International Baja 1000: The Official Game  2008.0
16596                                        Know How 2  2010.0
16597                                  Spirits & Spells  2003.0
'''



# 10. Maximum Sales in North America
# Which game had the highest sales in North America?
'''
highest_na_sales_game = df.loc[df['NA_Sales'].idxmax()] # Find the game with the highest sales in North America

print(f"The game with the highest sales in North America is '{highest_na_sales_game['Name']}' with {highest_na_sales_game['NA_Sales']} sales.") # Print the details of the game with the highest NA sales

ANSWER: The game with the highest sales in North America is 'Wii Sports' with 41.49 sales.
'''