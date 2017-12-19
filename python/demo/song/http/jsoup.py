import requests
from bs4 import BeautifulSoup
from song.config import charset


def load(url):
    libParser="html5lib"
    response = requests.get(url)
    response.encoding = charset.default
    doc = BeautifulSoup(response.text,libParser)
    return doc
