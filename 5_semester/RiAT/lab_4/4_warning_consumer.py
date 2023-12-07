import json, pika

def callback(ch, method, properties, body):
    print('Получено сообщение: ', body.decode('utf-8'))

def warning_consumer():
    connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
    channel = connection.channel()
    channel.queue_declare(queue='OverheatQueue')
    channel.basic_consume(queue='OverheatQueue', on_message_callback=callback, auto_ack=True)
    print('Ожидание сообщений...')
    channel.start_consuming()
                
warning_consumer()