package com.song.util;import com.song.lang.StringHelper;import java.util.*;/** * description:     MapHelper * author:          song * createDate:      2017/9/25 */public class MapHelper {    /**     * 判断map对象是否为空     * @param map     * @return     */    public static boolean isEmpty(Map map){        if(map==null || map.size()<=0){            return true;        }        return false;    }    public static String join(HashMap<String, String> map, String join1, String join2,String fix) {        List list = new ArrayList();        for (Map.Entry<String, String> entry : map.entrySet()) {            if (StringHelper.isEmpty(fix)) {                list.add(entry.getKey() + join1 + entry.getValue());            }else {                list.add(fix+entry.getKey()+fix + join1 + entry.getValue());            }        }        return StringHelper.join(join2, list);    }    public static String join(HashMap<String, String> map, String join1, String join2) {        return join(map, join1, join2, null);    }    /**     * 将map对象转为queryString     * @param map     * @return     */    public static String toUrlParamter(HashMap<String, String> map) {        return MapHelper.join(map, "=", "&");    }    public static HashMap<String, String> split(String s,String split1,String split2) {        HashMap<String, String> map = new HashMap<String, String>();        if(StringHelper.isEmpty(s)){            return map;        }        String[] array = s.split(split1);        for (String item : array) {            if(!StringHelper.isEmpty(item)){                String[] subArray = item.split(split2);                if(subArray.length==2){                    map.put(subArray[0].trim(), subArray[1].trim());                }            }        }        return map;    }}