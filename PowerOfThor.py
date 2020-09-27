import sys
import math

def straightLines(light_y, light_x, initial_y, initial_x):
    if (light_y == initial_ty) & (light_x > initial_ty):
        print("E")
    # GO WEST
    if (light_y == initial_ty) & (light_x < initial_ty):
        print("W")
    # GO UP
    if (light_x == initial_tx) & (light_y < initial_ty):
        print("N")
    # GO DOWN
    if (light_x == initial_tx) & (light_y > initial_ty):
        print("S")
    return

# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.
# ---
# Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.

# light_x: the X position of the light of power
# light_y: the Y position of the light of power
# initial_tx: Thor's starting X position
# initial_ty: Thor's starting Y position

# A single line providing the move to be made: N NE E SE S SW W or NW

light_x, light_y, initial_tx, initial_ty = [int(i) for i in input().split()]

thorX = initial_tx
thorY = initial_ty

# game loop
while True:
    remaining_turns = int(input())  # The remaining amount of turns Thor can move. Do not remove this line.

    # Write an action using print
    print("Debug messages...", light_x, light_y,"|", initial_tx, initial_ty,"|", thorX, thorY, file=sys.stderr, flush=True)

    # STRAIGHT LINES
    straightLines(light_y, light_x, initial_ty, initial_tx)    

    # BOUNDARY CHECK
    if (thorX < 40) & (thorY < 17) & (light_y != initial_ty):

        # Go SW
        if (light_x < thorX) & (light_y != thorY):
            print("SW")
            thorY = thorY + 1
            thorX = thorX - 1

        # GO SE
        elif (light_x > thorX) & (light_y != thorY):
            print("SE")
            thorY = thorY + 1
            thorX = thorX + 1

        # GO EAST
        elif (light_y == thorY) & (thorX < light_x):
            print("E")
            thorX = thorX + 1

    else:
        if thorY == 17:
            if thorX > light_x:
                print("W")
                thorX = thorX - 1
            elif (light_y == thorY) & (thorX <= light_x):
                print("E")
                thorX = thorX + 1
