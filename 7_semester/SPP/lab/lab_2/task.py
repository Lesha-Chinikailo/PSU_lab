import math


def f(x):
    if x <= -1:
        return -x + 1
    elif x > -1 and x <= 2:
        return math.pow(x, 2) - 1
    else:
        return 3


def task():
    wordBreak = input('Enter word for break: ')
    while True:
        try:
            inputWord = input("Enter a: ")
            a = int(inputWord)
            inputWord = input("Enter b: ")
            b = int(inputWord)
            if a > b:
                print('a must not be ore than b.')
                continue
        except:
            if inputWord == wordBreak:
                break
            else:
                print('you entered the incorrect value. Try again')
                continue
        result = 0
        for i in range(a, b + 1):
            result += f(i)
        print('result: ', result)


if __name__ == '__main__':
    task()
