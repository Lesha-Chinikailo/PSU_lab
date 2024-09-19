file = open("file1.txt", 'r')
with open("file3.txt", 'w') as file3:
    lines = file.readlines()
    for i in range(0, len(lines)):
        if i % 2 == 0:
            file3.write(lines[i])



file.close()