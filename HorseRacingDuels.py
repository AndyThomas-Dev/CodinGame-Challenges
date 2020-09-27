import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.

# Variables for later use
currentDif = 0
smallestDif = 10000000
lst = []

n = int(input())

# Puts the ints in a list
for i in range(n):
    pi = int(input())
    lst.append(pi)

# Sorts the list
sorted_lst = sorted(lst)

# Finds smallest difference
for i in range(n):

    pi = sorted_lst[i]

    if i == 0:
        first = pi
    else:
        currentDif = abs(pi - first) 
        first = pi

        if currentDif < smallestDif:
            smallestDif = currentDif

    #print("Debug messages...", currentDif, pi, file=sys.stderr, flush=True)

# Write an answer using print
# To debug: print("Debug messages...", file=sys.stderr, flush=True)
print(smallestDif)

