import math
def iter(n, degree):
    if degree == 0:
        return 1
    result = 1
    for i in range(0, degree):
        result *= n
    return result

def recursive(n, degree):
    if degree == 0:
        return 1
    return n * recursive(n, degree - 1)