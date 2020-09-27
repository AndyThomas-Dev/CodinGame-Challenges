import sys
import math

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.
min = 9999
posneg = 0
match = 0

n = int(input())  # the number of temperatures to analyse

for i in input().split():

    # t: a temperature expressed as an integer ranging from -273 to 5526
    t = int(i)
    input = t

    print("Debug messages...", t, min, match, file=sys.stderr, flush=True)

    # Negative numbers
    if t < 0:
        original = t
        t = t * -1

        # If pos matches neg
        if (abs(original) == min) & (posneg == 1):
            match = 1
            print("Match H", input, "|", min, file=sys.stderr, flush=True)

        if (t < min):
            min = t
            posneg = 0

    # Positive numbers
    elif (t > 0) & (t <= min):
        min = t
        posneg = 1

        # If the same as 
        if (t == min):
            match = 1
            print("Match", input, "|", min, file=sys.stderr, flush=True)

    print("Debug messages...", "INPUT: ", input, "| MIN", min, "SIGN", posneg, file=sys.stderr, flush=True)

# Write an answer using print
# To debug: print("Debug messages...", file=sys.stderr, flush=True)

# If negatve, show as negative
if posneg == 0:
    min = abs(min) * -1
    
# If there is 
if (match == 1) & (posneg == 1):
    min = abs(min)

# No temperature
if min == -9999:
    min = 0

print(min)

