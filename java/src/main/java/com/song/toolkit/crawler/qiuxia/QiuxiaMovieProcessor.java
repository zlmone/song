package com.song.toolkit.crawler.qiuxia;import com.song.lang.StringHelper;import com.song.net.http.HttpHelper;import com.song.toolkit.crawler.CrawlerMovie;import com.song.toolkit.web.JsoupHelper;import com.song.util.UUIDHelper;import org.jsoup.nodes.Document;import org.jsoup.nodes.Element;import org.jsoup.select.Elements;import us.codecraft.webmagic.Page;import us.codecraft.webmagic.Site;import us.codecraft.webmagic.processor.PageProcessor;import java.util.ArrayList;import java.util.List;/** * description: * author:          song * createDate:      2017/10/13 */public class QiuxiaMovieProcessor implements PageProcessor {    public String getDomain() {        return domain;    }    public void setDomain(String domain) {        this.domain = domain;    }    private String domain = "";    public QiuxiaMovieProcessor() {        site = Site.me().setRetryTimes(3).setSleepTime(100);        site.addCookie("__cfduid", "db098797a2ca36005831e66d3b46b52f41506819989");        site.setUserAgent(HttpHelper.getUserAgent(true));    }    private Site site;    public Site getSite() {        return site;    }    private List<CrawlerMovie> movies = new ArrayList<CrawlerMovie>();    public List<CrawlerMovie> getMovies() {        return movies;    }    public void process(Page page) {        //分析主页面        if (page.getRequest().getUrl().startsWith(domain)) {            Document doc = page.getHtml().getDocument();            Elements elements = doc.select("#data_list li");            if (!JsoupHelper.isEmpty(elements)) {                for (Element element : elements) {                    Element link = element.select("div.con > a").first();                    Element img = link.select("img").first();                    String href = link.attr("href");                    String[] playids = StringHelper.trimEnd(href, "/").split("/");                    String playid = playids[playids.length - 1];                    String play = domain + "/videos/" + playid + "/play.html?" + playid + "-0-1";                    String title = img.attr("alt");                    //演员                    String des = JsoupHelper.text(element.select("span.sDes").first());                    if (!title.startsWith("極品網絡紅人")) {                        CrawlerMovie movie = new CrawlerMovie(UUIDHelper.next(), play, title, img.attr("src"));                        movie.setPerformer(des);                        movies.add(movie);                       /* //添加子页面链接，分析视频下载的地址                        Request request = new Request(movie.getHref());                        request.putExtra("parentid", movie.getId());                        page.addTargetRequest(request);*/                    }                }            }        } else {          /*  //分析子页面链接            String parentid=page.getRequest().getExtra("parentid").toString();            Document document = page.getHtml().getDocument();            Element link= document.select("a.cur").first();            String downloadUrl=link.attr("href").trim();            for (QiuxiaMovie movie : movies) {                if(movie.getId().equals(parentid)){                    movie.setDownloadUrl(downloadUrl);                    break;                }            }*/        }    }    public static void main(String[] args) {        //分析自拍         /* QiuxiaMovieProcessor qiuxia = new QiuxiaMovieProcessor();        qiuxia.setDomain("http://m.qiuxia.cc.zwblovewln.com");        Spider spider = Spider.create(qiuxia);        spider.addUrl(qiuxia.domain + "/se/tp/index.html");        int pageCount = 13;        for (int i = 2; i <= pageCount; i++) {            spider.addUrl(qiuxia.domain + "/se/tp/index-" + i + ".html");        }        spider.thread(1).run();        List<QiuxiaMovie> movies=qiuxia.getMovies();      */        //分析经典       /* QiuxiaMovieProcessor qiuxia = new QiuxiaMovieProcessor();        qiuxia.setDomain("http://wap.qiuxia77.com");        Spider spider = Spider.create(qiuxia);        spider.addUrl(qiuxia.domain + "/lunli/index.html");        int pageCount = 108;        for (int i = 2; i <= pageCount; i++) {            spider.addUrl(qiuxia.domain + "/lunli/index-" + i + ".html");        }        spider.thread(1).run();        List<QiuxiaMovie> movies=qiuxia.getMovies();       */        /*String filePath = "D:\\Bingosoft\\公安\\项目代码\\广东省公安厅警务云\\source\\01.trunk\\bingo-base-dev\\src\\main\\java\\com\\song\\toolkit\\crawler\\qiuxia\\downloadThree.json";        String imgPath = "D:\\Bingosoft\\公安\\项目代码\\广东省公安厅警务云\\source\\01.trunk\\bingo-base-dev\\src\\main\\java\\com\\song\\toolkit\\crawler\\qiuxia\\threeImage";        try {            String content = FileHelper.getString(filePath);            int count=0;            for (QiuxiaMovie movie : movies) {                String imgName=StringHelper.replaceAll(movie.getTitle(),".","\\s+","/",":")+FileHelper.getExtension(movie.getImg());                String imgFilePath = imgPath + "\\" + imgName;                if(!FileHelper.exists(imgFilePath)) {                    HttpHelper.download(movie.getImg(), imgFilePath);                    System.out.println((count + 1) + " " + imgName);                    count++;                }            }            System.out.println("下载完毕，总数："+movies.size()+"，成功："+count);        } catch (IOException e) {            e.printStackTrace();        }*/    }}