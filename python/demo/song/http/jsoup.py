import requests
from bs4 import BeautifulSoup
from song.config import charset


def load(url):
    libParser="html5lib"
    response = requests.get(url)
    response.encoding = charset.default
    doc = BeautifulSoup(response.text,libParser)
    return doc

def text(list):
    if list and len(list)>0:
        return list[0].text
    return ""

def attr(list,key):
    if list and len(list):
        return list[0].get(key)
    return ""

