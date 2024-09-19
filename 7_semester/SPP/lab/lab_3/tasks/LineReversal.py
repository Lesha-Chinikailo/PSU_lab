def iter(s : str):
    result = ''
    for c in ''.join(reversed(s)):
        result += c
    return result

def recursive(s : str):
    if len(s) == 1:
        return s
    if s != '':
        return s[-1] + recursive(s[0:len(s)-1])