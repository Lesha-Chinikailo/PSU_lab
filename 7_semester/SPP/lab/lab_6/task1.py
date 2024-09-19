file = open("file1.txt", 'r')
lines = file.readlines()
keyWord = input("Enter key word: ")
for line in lines:
    if keyWord in line:
        print(line)

file.close()

