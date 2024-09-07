def task_1():
    a = int(input("Enter first number: "))
    b = int(input("Enter second number: "))
    c = int(input("Enter third number: "))
    print(float(a+b+c)/3)

def task_2():
    a = int(input("Enter first number: "))
    b = int(input("Enter second number: "))
    print("+: ", a + b)
    print("subtract: ", a - b)
    print("multy: ", a * b)
    print("divide: ", round(a / b))
    print("divide without a remainder: ", a // b)
    print("remainder: ", a % b)
    print("degrees: ", a ** b)
    print("&: ", a & b)
    print("|: ", a | b)
    print("^: ", a ^ b)
    print("~a: ", ~a)
    print(">>: ", a >> 2)
    print("<<: ", a << 2)

def isNullOrEmpry(s):
    return s is None or s.strip() == ''

def checkValueNullOrEmpry(s, symbol):
    #print(symbol)
    if isNullOrEmpry(s):
        return symbol
    else:
        return s

def task_3_4():
    surname = input("Enter surname: ")
    name = input("Enter name: ")
    patronymic = input("Enter patronymic: ")
    yearOfBirth = int(input("Enter year of birth: "))

    symbolInsteadOfSpace = input("enter symbol instead of space: ")

    info = [
        surname,
        name,
        patronymic,
        yearOfBirth
    ]

    surname.ljust(10)
    name.center(15)
    patronymic.rjust(10)
    #print(surname.ljust(10) + name.center(15) + patronymic.rjust(10))

    left = 15
    center = 20
    right = 15
    print("name".ljust(left) + "type".center(center) + "value".rjust(right))
    variableNames = list(locals().keys())
    print(symbolInsteadOfSpace)
    for i in range(0, len(info)):
        print(variableNames[i].ljust(left) + type(info[i]).__name__.center(center) + str(checkValueNullOrEmpry(str(info[i]), symbolInsteadOfSpace)).rjust(right))

    # print(name)
    # print(patronymic)




if __name__ == '__main__':
    # task_1()
    # task_2()
    task_3_4()