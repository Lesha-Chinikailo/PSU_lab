import matplotlib.pyplot as plt
import numpy as np
f = open("../IterationTimes.txt")

s = f.read().split(' ')
charNumber = []
for c in s:
    if(c == ''):
        break
    charNumber.append(float(c))
charNumber.pop()
print(charNumber)
countIteration = int(open("../CountIteration.txt").read())
numbers = [f"{i}" for i in range(1, countIteration + 1)]

#numbers = list(range(1, 102))
#numbersStr = []
#for i in numbers:
#    numbersStr.append(str(i))
print(len(numbers))
print(len(charNumber))
plt.bar(numbers, charNumber)
plt.xlabel('number')
plt.ylabel('value')
plt.title('diagram')
plt.show()









