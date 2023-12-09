import requests
import pika

def get_weather(api_key, city):
    url = f'http://api.openweathermap.org/data/2.5/weather?q={city}&appid={api_key}'
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        weather_description = data['weather'][0]['description']
        temperature = data['main']['temp']
        return f'Погода в городе {city}: {weather_description}, Температура: {temperature - 273}°C'
    else:
        return 'Ошибка получения данных о погоде'
def send_weather_message(api_key, city):
    message = get_weather(api_key, city)
    if message == 'Ошибка получения данных о погоде':
        print(message)
        return
    print(message)
    try:
        connection = pika.BlockingConnection(pika.ConnectionParameters(host='localhost'))
        channel = connection.channel()
        channel.queue_declare(queue='222')
        channel.basic_publish(exchange='', routing_key='222', body=message)
        connection.close()
        print('Сообщение успешно отправлено.')
    except pika.exceptions.AMQPConnectionError:
        print('Ошибка, не удалось отправить сообщение.')
api_key = '50bdc11c753481547c61352a79e3d757'
city = 'Navapolatsk'
send_weather_message(api_key, city)