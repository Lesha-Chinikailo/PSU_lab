

def task1():
    numbers = [4, 6, 1, 7, 4, 8]
    print('0 - asc')
    print('1 - desc')
    a = int(input("Enter number: "))
    if a == 0:
        numbers.sort()
    elif a == 1:
        numbers.sort(reverse=True)
    print(numbers)

def task2():
    s = 'abcdbcjdks'
    print(s)
    d = dict()
    while len(s) > 0:
        temp = s[0]
        oldLength = len(s)
        s = s.replace(temp, '')
        newLength = len(s)
        d[temp] = oldLength - newLength
    print(d)

def task3():
    s1 = {1, 2, 3, 4}
    s2 = {1, 6, 7, 2}
    print(s1.intersection(s2))
    print(s1.difference(s2))
    print(s1 - s2)


if __name__ == '__main__':
    print("task1:\n")
    task1()
    print("\ntask2:")
    task2()
    print("\ntask3:")
    task3()
