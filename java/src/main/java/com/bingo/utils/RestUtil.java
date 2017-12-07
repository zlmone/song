package com.bingo.utils;

import com.alibaba.fastjson.JSONObject;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

/**
 * 
 * <ul>
 * <li>项目名：信息运维服务管理系统</li>
 * <li>版本信息：ITSM v4.0</li>
 * <li>日期：2017-3-6-上午9:27:44</li>
 * <li>版权所有(C)2017广东轩辕网络科技股份有限公司-版权所有</li>
 * <li>创建人:林秀子</li>
 * <li>创建时间：2017-3-6-上午9:27:44</li>
 * <li>内容摘要：Rest标准接口调用工具类</li>
 * <li>修改时间1：</li>
 * <li>修改内容1：</li>
 * </ul>
 */
public class RestUtil {

	/**
	 * 
	 * restPOST 方法
	 * @descript：POST方式调用(返回JSON字符串)
	 * @param strurl
	 * 			String url字符串
	 * @param query 
	 * 			JSONObject 对象
	 * @return
	 * @throws Exception
	 * @return String
	 * @author 林秀子
	 * @date 2017-3-6-上午9:28:32
	 */
	public static String restPOST(String strurl, Object query) {
		
		try{
		URL url = new URL(strurl);
		HttpURLConnection connection = (HttpURLConnection)url.openConnection();
		/**/
		connection.setDoInput(true);
		connection.setDoOutput(true);
		connection.setRequestMethod("POST");
		connection.setUseCaches(false);


		connection.setRequestProperty("Content-type", "application/json;charset=UTF-8"); 
		connection.setConnectTimeout(30000);
		connection.setReadTimeout(30000);
		connection.connect();

		DataOutputStream out = new DataOutputStream(connection.getOutputStream());
		out.write(query.toString().getBytes("UTF-8"));

		out.flush();
		out.close();
		BufferedReader bReader = new BufferedReader(new InputStreamReader(connection.getInputStream(), "UTF-8"));
		String line, resultStr = "";
		while (null != (line = bReader.readLine())){
			resultStr += line;
		}
		bReader.close();
		return resultStr;
		
		
		} catch (Exception e) {
		e.printStackTrace();
		}
		return "";
	}
	
	/**
	 * 
	 * restGET 方法
	 * @descript：restGET方法调用接口(返回JSON字符串)
	 * @param url
	 * @return
	 * @return String
	 * @author 林秀子
	 * @date 2017-3-8-下午5:46:04
	 */
	public static String restGET(String url) {
		
		try{
			URL restURL = new URL(url);
			HttpURLConnection conn = (HttpURLConnection) restURL.openConnection();
			conn.setRequestMethod("GET");
			conn.setDoOutput(true);
			conn.setAllowUserInteraction(false);
			BufferedReader bReader = new BufferedReader(new InputStreamReader(conn.getInputStream()));
			String line, resultStr = "";
			while (null != (line = bReader.readLine())){
				resultStr += line;
			}
			bReader.close();
			return resultStr;
		}catch (Exception e) {
			e.printStackTrace();
		}
		return "";
	}
	
	/**
	 * 
	 * restPOSTReturnJSON 方法
	 * @descript：POST方式调用(返回JSONObject对象)
	 * @param url
	 * @param query
	 * @return
	 * @return JSONObject
	 * @author 林秀子
	 * @date 2017-3-6-上午9:38:36
	 */
	public static JSONObject restPOSTReturnJSON(String url, Object query) {
		
		JSONObject returnJsonData = new JSONObject();
		try{
			String resultString = RestUtil.restPOST(url, query);
			returnJsonData = JSONObject.parseObject(resultString);
		}catch (Exception e) {
			e.printStackTrace();
		}
		return returnJsonData;
	}
	
	public static Object restPOSTReturnStr(String url, Object query) {
		
		try{
			String resultString = RestUtil.restPOST(url, query);
			return resultString;
		}catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}
	
	/**
	 * 
	 * restPOSTReturnJSON 方法
	 * @descript：GET方式调用(返回JSONObject对象)
	 * @param url
	 * @return
	 * @return JSONObject
	 * @author 林秀子
	 * @date 2017-3-8-上午9:38:36
	 */
	public static JSONObject restGETReturnJSON(String url) {
		
		String resultString = RestUtil.restGET(url);
		JSONObject returnJsonData = new JSONObject();
		try{
			returnJsonData = JSONObject.parseObject(resultString);
		}catch (Exception e) {
			e.printStackTrace();
		}
		return returnJsonData;
	}


//	public static void main(String[] args) {
//	}

}