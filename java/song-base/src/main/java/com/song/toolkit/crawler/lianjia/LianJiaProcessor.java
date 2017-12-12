package com.song.toolkit.crawler.lianjia;

import com.song.lang.StringHelper;
import com.song.net.UrlHelper;
import com.song.net.http.HttpHelper;
import com.song.toolkit.crawler.CrawlerProcessor;
import com.song.toolkit.crawler.longnian.LongNianProcessor;
import com.song.util.ListHelper;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;
import org.omg.CosNaming.NamingContextExtPackage.StringNameHelper;
import us.codecraft.webmagic.Page;
import us.codecraft.webmagic.Site;
import us.codecraft.webmagic.Spider;
import us.codecraft.webmagic.processor.PageProcessor;

import java.util.ArrayList;
import java.util.List;

public class LianJiaProcessor extends CrawlerProcessor implements PageProcessor {
    private Site site;

    public LianJiaProcessor() {
        site = Site.me().setRetryTimes(3).setSleepTime(1000);
        site.setUserAgent(HttpHelper.getUserAgent());
        site.addHeader("Connection", "Keep-Alive");
        site.addHeader("Content-Type", "application/x-www-form-urlencoded");
    }

    public Site getSite() {
        return site;
    }

    private List<LianJiaHouse> houses = new ArrayList<LianJiaHouse>();

    public void process(Page page) {
        //添加公用属性
        //page.putField("","");
        //设置是否忽略
        //page.setSkip(true);
        String url = page.getRequest().getUrl();
        Document doc = page.getHtml().getDocument();
        //分析列表页面
        if(url.startsWith(UrlHelper.combine(getDomain(),"ershoufang/pg"))){
            Elements items= doc.select("ul.sellListContent > li");
            if(!ListHelper.isEmpty(items)){
                for (Element item : items) {
                    houses.add(parseLianJiaHouse(item));
                }
            }
        }
    }

    /**
     * 分析房源信息
     * @param item
     * @return
     */
    private LianJiaHouse parseLianJiaHouse(Element item) {
        LianJiaHouse house=new LianJiaHouse();
        Element imgLink=item.select("a.img").first();
        house.setHouseCode(imgLink.attr("data-housecode"));
        house.setDetailsUrl(imgLink.attr("href"));
        house.setTitle(imgLink.select("img.lj-lazy").first().attr("alt"));
        house.setTotalPrice(item.select("div.totalPrice > span").first().text());
        house.setUnitPrice(LianJiaHelper.parseUnitPrice(item.select("div.unitPrice > span").first().text()));

        Element houseInfo=item.select("div.houseInfo").first();
        String[] houseInfoArray = LianJiaHelper.parseHouseInfo(houseInfo.text());
        if(houseInfoArray.length>=4){
            //小区名称
            house.setHouseName(houseInfoArray[0]);
            //户型大小
            house.setHouseType(houseInfoArray[1]);
            //面积
            house.setHouseArea(houseInfoArray[2]);
            //朝向
            house.setOrientation(houseInfoArray[3]);
        }
        //装修情况
        if(houseInfoArray.length>=5){
            house.setDecoration(houseInfoArray[4]);
        }
        //是否有电梯
        if(houseInfoArray.length>=6){
            house.setIsElevator(houseInfoArray[5]);
        }


        return house;
    }

    /**
     * 测试以及运行
     * @param args
     */
    public static void main(String[] args) {
        String domain = "https://cs.lianjia.com";
        LianJiaProcessor processor = new LianJiaProcessor();
        processor.setDomain(domain);
        Spider spider = Spider.create(processor);
        for (int i = 1; i <= 1; i++) {
            String url = UrlHelper.combine(domain, "ershoufang/pg" + i + "/");
            spider.addUrl(url);

        }
        spider.thread(1).run();
    }
}
