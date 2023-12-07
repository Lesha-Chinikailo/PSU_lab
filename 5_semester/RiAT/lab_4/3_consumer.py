import pika

def callback(ch, method, properties, body):
    print('Получено сообщение: ', body.decode('utf-8'))
def receive_weather_message():
    try:
        connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
        channel = connection.channel()
        channel.queue_declare(queue='weather')
        channel.basic_consume(queue='weather', on_message_callback=callback, auto_ack=True)
        print('Ожидание сообщений...')
        channel.start_consuming()
    except pika.exceptions.AMQPConnectionError:
        print('Ошибка, не удалось подключиться к брокеру сообщений')
receive_weather_message()