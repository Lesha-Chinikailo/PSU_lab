import math

class Circle:
    def __init__(self):
        self.R = int(input("Enter R: "))

    def Square(self):
        return math.pi * math.pow(self.R, 2)
    def Perimetr(self):
        return 2 * math.pi * self.R

class Book:
    count = 0
    def __init__(self):
        Book.count += 1

class Rectangle:
    def __init__(self, a, b):
        self.__a__ = a
        self.__b__ = b

    def Print(self):
        print(self.__a__, self.__b__)

class Figure(Rectangle):
    def getSquare(self):
        return self.__a__ * self.__b__
    def getPerimetr(self):
        return 2 * (self.__a__ + self.__b__)

    def setA(self, a):
        self.__a__ = a
    def setB(self, b):
        self.__b__ = b
    def getA(self, a):
        return self.__a__
    def getB(self, b):
        return self.__b__

if __name__ == '__main__':
    c = Circle()
    print(c.Square())
    print(c.Perimetr())

    print("task2:\n")
    Book()
    print(Book.count)
    Book()
    a = Book()
    print(a.count)

    print("task3:\n")
    f = Figure(2, 4)
    f.Print()
    f.setA(10)
    print(f.getSquare())
    f.setB(5)
    f.Print()
