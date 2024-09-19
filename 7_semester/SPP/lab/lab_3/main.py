from timeit import timeit

import tasks.RaiseToDegree as task1
import tasks.LineReversal as task2
import tasks.Fib as task3


def task_1():
    print(task1.iter(3, 4))
    print(task1.recursive(3, 4))
    setup_code_iter = 'from tasks.RaiseToDegree import iter'
    stmt_iter = 'iter(3, 4)'
    print("iter: ", timeit(setup=setup_code_iter, stmt=stmt_iter, number=20000))
    setup_code_iter = 'from tasks.RaiseToDegree import recursive'
    stmt_iter = 'recursive(3, 4)'
    print("recursive: ", timeit(setup=setup_code_iter, stmt=stmt_iter, number=20000))


def task_2():
    print(task2.iter('hello'))
    print(task2.recursive('hello'))
    setup_code_iter = 'from tasks.LineReversal import iter'
    stmt_iter = "iter('hello')"
    print("iter: ", timeit(setup=setup_code_iter, stmt=stmt_iter, number=20000))
    setup_code_iter = 'from tasks.LineReversal import recursive'
    stmt_iter = "recursive('hello')"
    print("recursive: ", timeit(setup=setup_code_iter, stmt=stmt_iter, number=20000))


def task_3():
    print(task3.iter(8))
    print(task3.recursive(8))
    setup_code_iter = 'from tasks.Fib import iter'
    stmt_iter = "iter(8)"
    print("iter: ", timeit(setup=setup_code_iter, stmt=stmt_iter, number=20000))
    setup_code_iter = 'from tasks.Fib import recursive'
    stmt_iter = "recursive(8)"
    print("recursive: ", timeit(setup=setup_code_iter, stmt=stmt_iter, number=20000))


if __name__ == '__main__':
    task_1()
    print()
    task_2()
    print()
    task_3()