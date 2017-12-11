package com.song.toolkit.crawler.lianjia;

import com.song.net.UrlHelper;
import com.song.toolkit.crawler.CrawlerMovieProcessor;
import com.song.toolkit.crawler.longnian.LongNianProcessor;
import org.jsoup.nodes.Document;
import us.codecraft.webmagic.Page;
import us.codecraft.webmagic.Site;
import us.codecraft.webmagic.Spider;
import us.codecraft.webmagic.processor.PageProcessor;

public class LianJiaProcessor extends CrawlerMovieProcessor implements PageProcessor {
    private Site site;

    public LianJiaProcessor() {
        site = Site.me().setRetryTimes(3).setSleepTime(1000);
    }

    public Site getSite() {
        return site;
    }
    public void process(Page page) {
        //添加公用属性
        //page.putField("","");
        //设置是否忽略
        //page.setSkip(true);
        String url = page.getRequest().getUrl();
        Document doc = page.getHtml().getDocument();
        String content = doc.text();
        System.out.println(content);
    }

    public static void main(String[] args) {
        String domain = "https://cs.lianjia.com";
        LongNianProcessor processor = new LongNianProcessor();
        processor.setDomain(domain);
        Spider spider = Spider.create(processor);
        String url = UrlHelper.combine(domain, "ershoufang/p3p4/");
        spider.addUrl(url);
        spider.thread(1).run();
    }
}
