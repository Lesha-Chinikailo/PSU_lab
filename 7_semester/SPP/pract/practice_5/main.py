'''

import requests
from PIL import Image
from io import BytesIO


def get_dog_image(breed: str):
    url = f'https://dog.ceo/api/breed/{breed}/images/random'
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        return data['message']
    else:
        return None


def show_dog_image():
    breed = input("Enter breed: ")
    image_url = get_dog_image(breed)
    if image_url:
        response = requests.get(image_url)
        img_data = response.content
        img = Image.open(BytesIO(img_data))
        img.show()
    else:
        print("Ошибка при загрузке изображения:")


if __name__ == "__main__":
    show_dog_image()
'''

import requests
from PIL import Image
from io import BytesIO

def get_dog_image(breed):
    url = f'https://dog.ceo/api/breed/{breed}/images/random'
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        return data['message']
    else:
        return None

def show_dog_image():
    breed = input("Enter breed: ")
    image_url = get_dog_image(breed)
    if image_url:
        response = requests.get(image_url)
        img_data = response.content
        img = Image.open(BytesIO(img_data))
        img.show()
    else:
        print("Ошибка при загрузке изображения:")

if __name__ == "__main__":
    show_dog_image()