def iter(n):
    if n == 1:
        return [1]
    if n == 2:
        return [1, 1]
    fibs = [1, 1]
    for _ in range(2, n):
        fibs.append(fibs[-1] + fibs[-2])
    return fibs

def recursive(n):
    if n <= 1:
        return n
    else:
        return (recursive(n-1) + recursive((n-2)))