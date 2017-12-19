#龙年快乐电影

import time

import song.config as config
import song.http.jsoup as jsoup
from song.helper import string

now = "2017-12-18"

domain = "http://bbs.my9200.com"
dateFmt = config.fmt.date
url = domain + "/a/zp/index.html"
doc = jsoup.load(url)
detailUrls = []

for item in doc.select("div.mnewest li"):
    link = item.select("span.stitle a")[0]
    href = link.get("href")
    date = item.select("span.wp_time")[0].text
    if string.isEmpty(now):
        now = time.strftime(dateFmt)
    beginDate = time.mktime(time.strptime(now, dateFmt))
    responseDate = time.mktime(time.strptime(date, dateFmt))
    if (responseDate >= beginDate):
        detailUrls.append(domain + href)

for detailUrl in detailUrls:
    detailDoc = jsoup.load(detailUrl)
    pageWrap = detailDoc.select("div.pagecon")[0].text
    downloadUrl = pageWrap.split("：")[1]
    if not string.isEmpty(downloadUrl):
        print(downloadUrl)
