package com.song.orm.config;import com.song.common.TagNode;import com.song.db.DBType;import com.song.io.FileHelper;import com.song.io.PathHelper;import com.song.net.UrlHelper;import com.song.reflect.ClassHelper;import com.song.toolkit.xml.XMLHelper;import java.io.File;import java.net.URL;import java.util.ArrayList;import java.util.List;/** * description: * author:          song * createDate:      2017/10/29 */public class DBConfigManager {    private static String dbConfigFileName = "config/db.xml";    private static String locations;    private static List<String> mappers=new ArrayList<String>();    private static DBType dbType;    public static String getLocations() {        return locations;    }    public static void setLocations(String locations) {        DBConfigManager.locations = locations;    }    public static List<String> getMappers() {        return mappers;    }    public static void setMappers(List<String> mappers) {        DBConfigManager.mappers = mappers;    }    public static DBType getDbType() {        return dbType;    }    public static void setDbType(DBType dbType) {        DBConfigManager.dbType = dbType;    }    public static  void init() throws Exception {        String claspath =ClassHelper.getLocalPath(DBConfigManager.class);        TagNode node = XMLHelper.parseTagNode(PathHelper.combine(claspath,dbConfigFileName));        for (TagNode tagNode : node.getChildNodes()) {            for (TagNode property : tagNode.getChildNodes()) {                String name = property.getAttribute("name");                String value = property.getAttribute("value");                if (name.equalsIgnoreCase("locations")) {                    locations=value;                }                if (name.equalsIgnoreCase("dbType")) {                    dbType = DBType.parse(value);                }                if (name.equalsIgnoreCase("mapper")) {                    value = value.replace("classpath:", "");                    String mapperPath = UrlHelper.toLocalPath(UrlHelper.getPath(value));                    String mapperFile = UrlHelper.getFileName(value);                    String[] fileInfo = mapperFile.split("\\.");                    if (fileInfo[0].equals("*")) {                        //读取文件夹下面的所有mapper文件                        String filePath=PathHelper.combine(claspath,mapperPath);                        File file = new File(filePath);                        String[] files=file.list();                        if(files!=null) {                            for (String s : files) {                                mappers.add(PathHelper.combine(claspath,mapperPath,s));                            }                        }                    }else {                        mappers.add(PathHelper.combine(claspath, value));                    }                }            }        }    }    /*public static void main(String[] args) {        try {            DBConfigManager.init();            List<String> mappers=DBConfigManager.getMappers();            System.out.println(mappers);        } catch (Exception e) {            e.printStackTrace();        }    }*/}