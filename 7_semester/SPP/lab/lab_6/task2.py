file = open("file1.txt", 'r')
file1 = open("file2.txt", 'w')
lines = file.readlines()
keyWord = input("Enter key word: ")
for line in lines:
    line = line.replace(keyWord, "!!!!!")
    file1.write(line)

file.close()
file1.close()