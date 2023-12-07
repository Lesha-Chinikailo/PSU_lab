import json, pika

def callback(ch, method, properties, body):
    print('Получено сообщение: ', body.decode('utf-8'))

def monitoring_consumer():
    connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
    channel = connection.channel()
    channel.queue_declare(queue='MonitoringQueue')
    channel.basic_consume(queue='MonitoringQueue', on_message_callback=callback, auto_ack=True)
    print('Ожидание сообщений...')
    channel.start_consuming()
                
monitoring_consumer()