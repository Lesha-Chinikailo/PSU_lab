from bs4 import BeautifulSoup

path = "website.html"

with open(path, 'r') as file:
    html_content = file.read()

soup = BeautifulSoup(html_content, 'html.parser')

links = soup.find_all('a')

for link in links:
    print(link.get('href'))
