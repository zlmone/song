package com.song.mobile;

public class WXHelper {
    /*//开发APPID
	public final static String AppId ="wx795839736c0c3536";
	//开发密钥
	public final static String AppSecret   ="c06024ae22168eace90b6f9421c6e996";
	//auth_url
	public final static String auth_url="https://api.weixin.qq.com/sns/oauth2/access_token";
	//获取token
	public final static String token_url= "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid="+CommonWx.AppId+"&secret="+CommonWx.AppSecret;
	//获取jstoken 地址
	public final static String getticket_url="https://api.weixin.qq.com/cgi-bin/ticket/getticket";

	//access_token地址
	public final static String jsapiUrl="https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=ACCESS_TOKEN&type=jsapi";
	//微信调用jsp页面
	public final static String wxJsUseJsp="http://baoweijun.ngrok.xiaomiqiu.cn/lucky/lottry/lucky.jsp";
		
	//获取openId

	public static String getopenId(String code) 
	{
		
		//下面就到了获取openid,这个代表用户id.
		String openParam = "appid="+CommonWx.AppId+"&secret="+CommonWx.AppSecret+"&code="+code+"&grant_type=authorization_code";
		String openJsonStr = HttpClientUtil.SendGET(CommonWx.auth_url, openParam);
		JSONObject openMap = JSON.parseObject(openJsonStr);
		String openid = (String) openMap.get("openid");
		log.debug("\ngetopenId=\n[\n\topenid:"+openid+"\n\t]");
		return openid;
	}

	//获取公众微信号token

	public static WeChatPublic getUerToken(WeChatPublic userInfo) 
	{
		try{
			String appId=CommonWx.AppId;
			//获取token
			String token=HttpClientUtil.SendGET(CommonWx.token_url, "");
			JSONObject tokenMap = JSON.parseObject(token);
			if(null!=token&&null!=tokenMap.getString("access_token"))
			{
				userInfo.setAccenToken(tokenMap.getString("access_token"));
				log.debug("********[getUerToken]获取[ACCESS_TOKEN:"+tokenMap.getString("access_token")+"]");

				String _url=CommonWx.jsapiUrl.replaceAll("ACCESS_TOKEN", tokenMap.getString("access_token"));
				//获取accen_token
				String openJsonStr = HttpClientUtil.SendGET(_url, "");
				JSONObject openMap = JSON.parseObject(openJsonStr);
				String errcode=openMap.getString("errcode");
				String errmsg=openMap.getString("errmsg");
				String ticket=openMap.getString("ticket");
				if(errcode.equals("0")&&errmsg.equalsIgnoreCase("ok")&&null!=ticket)
				{

					//签名
					String   timestamp=Sha1Util.getTimeStamp(); // 必填，生成签名的时间戳
					String   nonceStr=Sha1Util.getNonceStr(); // 必填，生成签名的随机串
					String   paySign=createSign(timestamp,nonceStr,ticket);

					log.debug("********[getUerToken]获取[参数:"+paySign+"]");
					userInfo.setToken(ticket);
					userInfo.setAppId(appId);
					userInfo.setTimestamp(timestamp);
					userInfo.setNonceStr(nonceStr);
					userInfo.setSignature(paySign);
					log.debug("********[getUerToken]获取[ticket:"+ticket+"]");
				}
			}
			//缓存appid
			ServletContext sc = ServletContextUtil.get();
			sc.removeAttribute(CommonWx.AppId);
			sc.setAttribute(CommonWx.AppId, userInfo);
		}catch(Exception e){
			e.printStackTrace();
			log.debug("********HttpWxUtils.[getUerToken]异常:"+e.getMessage()+"]");
		}
		return userInfo;
	}
	//创建签名

	public static String createSign(String timestamp, String nonceStr, String ticket) throws Exception
	{
		//生成支付签名,这个签名 给 微信支付的调用使用
		SortedMap<String, String> signParams=new TreeMap<String, String>();
		signParams.put("jsapi_ticket", ticket);
		signParams.put("noncestr", nonceStr);
		signParams.put("timestamp", timestamp);
		signParams.put("url", CommonWx.wxJsUseJsp);
		String paySign =  Sha1Util.createSHA1Sign(signParams);
		log.info("\ncreateSign:\n[\n\tnoncestr:"+nonceStr+",\n\tjsapi_ticket:"+ticket+"" +
				",\n\ttimestamp:"+timestamp+",\n\turl:"+CommonWx.wxJsUseJsp+",\n\t" +
						"paySign:"+paySign+"\n]");
		return paySign;

	}*/
}
