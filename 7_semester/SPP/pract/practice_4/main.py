import os
import shutil

os.makedirs('project', exist_ok=True)
print("Директория 'project' создана.")

with open('project/data.txt', 'w', encoding='utf-8') as file:
    file.write('Это пример текста, записанного в файл.\n')
    file.write('еще текст\n')
    file.write('и еще текст\n')
print("Файл 'data.txt' создан и записан.")

with open('project/data.txt', 'r', encoding='utf-8') as file:
    content = file.read()
print("Содержимое файла:")
print(content)

shutil.copy('project/data.txt', 'project/data_backup.txt')

os.remove('project/data.txt')
print("Файл 'renamed_file.txt' удален.")


os.rename('project/data_backup.txt','project/data.txt')
print("Файл переименован в 'data_backup.txt'.")

'''
from google.colab import files
uploaded = files.upload()

files.download('data.txt')
'''