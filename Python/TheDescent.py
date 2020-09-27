import sys
import math

# The while loop represents the game.
# Each iteration represents a turn of the game
# where you are given inputs (the heights of the mountains)
# and where you have to print an output (the index of the mountain to fire on)
# The inputs you are given are automatically updated according to your last actions.

while True:
    max_height = 0
    max_mountain = 0

    for i in range(8):
        height = int(input())
        
        if height > max_height:
            max_height = height
            max_mountain = i

    print(max_mountain)
    print("Debug messages...", max_height, i, max_mountain, file=sys.stderr, flush=True)
