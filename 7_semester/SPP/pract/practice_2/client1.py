import socket

client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client_socket.connect(('localhost', 8000))

secret_number = int(input('Client 1, enter the hidden number (from 1 to 100): '))
client_socket.sendall(str(secret_number).encode())

attempts = int(client_socket.recv(1024).decode())
print(f'Client 2 guessed the number in {attempts} attempts')

client_socket.close()