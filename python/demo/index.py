# ['False', 'None', 'True', 'and', 'as', 'assert', 'break', 'class', 'continue', 'def',
# 'del', 'elif', 'else', 'except', 'finally', 'for', 'from', 'global', 'if', 'import',
# 'in', 'is', 'lambda','nonlocal', 'not', 'or', 'pass', 'raise', 'return', 'try', 'while', 'with', 'yield']

import requests
from bs4 import BeautifulSoup
from util import lib

url="http://bbs.my9200.com/a/zp/index.html"
response=requests.get(url)
response.encoding="utf-8"
html=response.text

bf=BeautifulSoup(html,"html.parser")
title=bf.select("title")
titleText=title[0].text
print(titleText)









