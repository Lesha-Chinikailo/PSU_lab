import pika, json, time, random

def produce_smart_home_events():
    i = 0
    connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
    for i in range(0, 100):
        choice = random.choice([0, 1])
        smart_home_event = {
        'device_id': f'thermostat_{i}' if choice else f'monitor_{i}',
        'event_type': 'overheat' if choice else 'monitoring',
        'timestamp': int(time.time())
        }
        i += 1
        channel = connection.channel()
        channel.queue_declare(queue='OverheatQueue' if choice else 'MonitoringQueue')
        channel.basic_publish(exchange='', routing_key='OverheatQueue' if choice else 'MonitoringQueue', body=json.dumps(smart_home_event))
        time.sleep(10) 
    connection.close()  

produce_smart_home_events()
