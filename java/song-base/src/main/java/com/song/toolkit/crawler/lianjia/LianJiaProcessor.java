package com.song.toolkit.crawler.lianjia;

import com.song.io.FileHelper;
import com.song.lang.StringHelper;
import com.song.net.UrlHelper;
import com.song.net.http.HttpHelper;
import com.song.toolkit.crawler.CrawlerProcessor;
import com.song.toolkit.crawler.longnian.LongNianProcessor;
import com.song.toolkit.serializer.SerializerFactory;
import com.song.util.ListHelper;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;
import org.omg.CosNaming.NamingContextExtPackage.StringNameHelper;
import us.codecraft.webmagic.Page;
import us.codecraft.webmagic.Site;
import us.codecraft.webmagic.Spider;
import us.codecraft.webmagic.processor.PageProcessor;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class LianJiaProcessor extends CrawlerProcessor implements PageProcessor {
    private Site site;

    public LianJiaProcessor() {
        site = Site.me().setRetryTimes(5).setSleepTime(2000);
        site.setUserAgent(HttpHelper.getUserAgent());
        site.addHeader("Connection", "Keep-Alive");
        site.addHeader("Content-Type", "application/x-www-form-urlencoded");
    }

    public Site getSite() {
        return site;
    }

    private List<LianJiaHouse> houses = new ArrayList<LianJiaHouse>();

    public List<LianJiaHouse> getHouses() {
        return houses;
    }

    public void process(Page page) {
        //添加公用属性
        //page.putField("","");
        //设置是否忽略
        //page.setSkip(true);
        String url = page.getRequest().getUrl();
        Document doc = page.getHtml().getDocument();
        //分析列表页面
        if (url.startsWith(UrlHelper.combine(getDomain(), "ershoufang/pg"))) {
            Elements items = doc.select("ul.sellListContent > li");
            if (!ListHelper.isEmpty(items)) {
                for (int i = 0; i < items.size(); i++) {
                    houses.add(parseLianJiaHouse(items.get(i), i));
                }
            }
        }
    }

    /**
     * 分析房源信息
     *
     * @param item
     * @return
     */
    private LianJiaHouse parseLianJiaHouse(Element item, int index) {
        LianJiaHouse house = new LianJiaHouse();
        house.setSeqno(index);
        Element imgLink = item.select("a.img").first();
        house.setHouseCode(imgLink.attr("data-housecode"));
        house.setDetailsUrl(imgLink.attr("href"));
        house.setTitle(imgLink.select("img.lj-lazy").first().attr("alt"));

        house.setTotalPrice(item.select("div.totalPrice > span").first().text());
        house.setUnitPrice(LianJiaHelper.parseUnitPrice(item.select("div.unitPrice > span").first().text()));

        Element houseInfo = item.select("div.houseInfo").first();
        String[] houseInfoArray = LianJiaHelper.parseHouseInfo(houseInfo.text());
        if (houseInfoArray != null) {
            if (houseInfoArray.length >= 4) {
                //小区名称
                house.setHouseName(houseInfoArray[0].trim());
                //户型大小
                house.setHouseType(houseInfoArray[1].trim());
                //面积
                house.setHouseArea(houseInfoArray[2].trim().replace("平米", ""));
                //朝向
                house.setOrientation(houseInfoArray[3].trim());
            }
            //装修情况
            if (houseInfoArray.length >= 5) {
                house.setDecoration(houseInfoArray[4].trim());
            }
            //是否有电梯
            if (houseInfoArray.length >= 6) {
                house.setIsElevator(houseInfoArray[5].trim());
            }
        }

        //地铁线路，站名，距离
        Elements subwaySpan = item.select("span.subway");
        if (subwaySpan.size() > 0) {
            String[] subwayInfo = LianJiaHelper.parseSubway(subwaySpan.first().text());
            if (subwayInfo != null && subwayInfo.length == 3) {
                house.setSubwayLine(subwayInfo[0]);
                house.setSubwayName(subwayInfo[1]);
                house.setSubwayDistance(subwayInfo[2]);
            }
        }
        //楼层、建造信息、所属区域
        String buildContent = item.select("div.positionInfo").first().text();
        String[] buildInfo = LianJiaHelper.parseBuildInfo(buildContent);
        if (buildInfo != null && buildInfo.length == 4) {
            house.setStorey(buildInfo[0]);
            house.setStoreyTotal(buildInfo[1]);
            house.setYearBuilt(buildInfo[2]);
            house.setPosition(buildInfo[3]);
        }
        //解析关注人数、看房人数、发布日期
        String[] followInfo = LianJiaHelper.parseFollowInfo(item.select("div.followInfo").first().text());
        if (followInfo != null && followInfo.length == 3) {
            house.setFollow(followInfo[0]);
            house.setShowings(followInfo[1]);
            house.setReleaseTime(followInfo[2]);
        }
        //是否可以看房
        Elements haskeySpan = item.select("span.haskey");
        if (haskeySpan.size() > 0) {
            house.setHaskey(haskeySpan.first().text());
        }
        //房产证满的年数
        Elements five = item.select("span.five");
        Elements taxfree = item.select("span.taxfree");
        if (five.size() > 0 || taxfree.size() > 0) {
            house.setFullYears(five.size() > 0 ? 2 : 5);
        }
        return house;
    }

    /**
     * 测试以及运行
     *
     * @param args
     */
    public static void main(String[] args) {
        String domain = "https://cs.lianjia.com";
        LianJiaProcessor processor = new LianJiaProcessor();
        processor.setDomain(domain);
        Spider spider = Spider.create(processor);
        for (int i = 1; i <= 85; i++) {
            String url = UrlHelper.combine(domain, "ershoufang/pg" + i + "/");
            spider.addUrl(url);
        }
        spider.thread(1).run();

        List<LianJiaHouse> houses = processor.getHouses();
        String json = SerializerFactory.getJSONInstance().toString(houses);
        try {
            FileHelper.write(json, "D:\\cs2.json");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
