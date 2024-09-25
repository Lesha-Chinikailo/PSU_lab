import socket

# Создание сокета клиента
client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client_socket.connect(('localhost', 8000))

while True:
    guess = int(input('Client 2, enter number: '))
    client_socket.sendall(str(guess).encode())
    response = client_socket.recv(1024).decode()
    if response == 'more':
        print('the hidden number is less')
    elif response == 'less':
        print('the hidden number is more')
    else:
        print('you guessed!')
        break

client_socket.close()