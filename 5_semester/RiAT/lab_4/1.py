import pika

def check_message_broker():
    try:
        connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
        connection.close()
        return True
    except pika.exceptions.AMQPConnectionError:
        return False
def send_message(message):
    if message.strip() == '':
        print('Ошибка, текст сообщения не может быть пустым')
        return
    if not check_message_broker():
        print('Ошибка, брокер сообщений недоступен')
    try:
        connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
        channel = connection.channel()
        channel.queue_declare(queue='111')
        channel.basic_publish(exchange='', routing_key='111', body=message)
        connection.close()
        print('Сообщение успешно отправлено')
    except pika.exceptions.AMQPConnectionError:
        print('Ошибка, не удалось отправить сообщение')
message = input('Введите текст сообщения: ')
send_message(message)