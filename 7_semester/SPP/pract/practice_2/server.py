import socket

server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind(('localhost', 8000))
server_socket.listen(2)

print('the server is listening...')

client1, addr1 = server_socket.accept()
print(f'Client 1 connected: {addr1}')

client2, addr2 = server_socket.accept()
print(f'Client 2 connected: {addr2}')

secret_number = int(client1.recv(1024).decode())
print(f'the hidden number: {secret_number}')

attempts = 0

while True:
    data = client2.recv(200)
    if not data:
        break
    guess = int(data.decode())
    attempts += 1
    if guess > secret_number:
        client2.sendall('more'.encode())
    elif guess < secret_number:
        client2.sendall('less'.encode())
    else:
        client2.sendall('guess!'.encode())
        break

client1.sendall(str(attempts).encode())

client1.close()
client2.close()
server_socket.close()
