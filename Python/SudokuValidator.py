import sys
import math

# Needs considerable tidying up!

def checkLine(line):

    if len(line) != 9:
        return False

    count = 1

    for i in range(9):
        for x in line:
            if x == count:
                count = count + 1
                # print("Debug messages...", count, file=sys.stderr, flush=True)
                break

    if count == 10:
        return True
    else:
        return False


# Auto-generated code below aims at helping you parse
# the standard input according to the problem statement.
validator = True
validatorSub = True
arraylst = []
subGrids = []

acrossCount = 0
vertCount = 0
count = 0
temp = 0

# Creates list of lists
for i in range(9):
    arraylst.append([])

for i in range(9):
    subGrids.append([])

for i in range(9):

    across = []
    count = 0

    for j in input().split():
        n = int(j)
        arraylst[count].append(n)
        across.append(n)

        count = count + 1

    # Columns
    if i == 8:
        for l in arraylst:
            
            if(checkLine(l) == False):
                validator = False
                print("Debug messages...", l, "FALSE", i, file=sys.stderr, flush=True)
                break
            else:
                print("Debug messages...", l, "TRUE", i, file=sys.stderr, flush=True)
            
    # Rows
    if validator:
        if checkLine(across):
            print("Debug messages...", across, "TRUE", i, file=sys.stderr, flush=True)
            validator = True
            acrossCount = acrossCount + 1

            # If all rows valid, check subgrids
            if acrossCount == 9:

                jump = 0
                jump2 = 0

                for a in range(9):
                    for b in range(3):
                        for g in range(3):
                            subGrids[a].append(arraylst[b+jump2][g+jump])
                            print("SQR...", arraylst[b+jump2][g+jump], b+jump, g+jump2, "SQR", a, file=sys.stderr, flush=True)

                    if a % 3 == 0:
                        jump = 0
                        jump2 = jump2 + 3
                    elif g+jump2 == 8:
                        jump2 = 0
                    else:
                        jump = jump + 3

                    print("SGRD...", subGrids[a], "SGRD", a, file=sys.stderr, flush=True)

                    if checkLine(subGrids[a]) == False:
                        validatorSub = False
                        print("false")
                        break
                
                if validatorSub == True:
                    print("true")
                    break

            print("Debug messages...", n, "SQR", i, file=sys.stderr, flush=True)
        else:
            print("Debug messages...", across, "FALSE", i, file=sys.stderr, flush=True)
            validator = False
            print("false")
            break
    else:
        print("false")
