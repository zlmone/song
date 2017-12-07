package com.song.config;import com.song.io.StreamHelper;import com.song.lang.ConvertHelper;import java.io.File;import java.io.IOException;import java.io.InputStream;import java.net.URL;import java.util.Properties;/** * description: * author:          song * createDate:      2017/10/23 */public class Configuration extends Properties {    private static final long serialVersionUID = -8293498948215627765L;    public Configuration() {        super();    }    public Configuration(ClassLoader classLoader, String propFile) throws IOException {        URL url = classLoader.getResource(propFile);        configure(url);    }    public Configuration(String propFile) throws IOException {        URL url = this.getClass().getResource(propFile);        configure(url);    }    public Configuration(File propFile) throws IOException {        this(propFile.toURI().toURL());    }    public Configuration(URL url) throws IOException {        configure(url);    }    public Configuration(Properties defaults) {        super(defaults);    }    private void configure(URL url) throws IOException {        InputStream stream = null;        try {            stream=url.openStream();            load(stream);        } finally {            StreamHelper.close(stream);        }    }    public boolean getPropertyBool(String key, boolean defaultValue) {        return ConvertHelper.toBool(getProperty(key), defaultValue);    }    public boolean getPropertyBool(String key) {        return getPropertyBool(key, false);    }    public int getPropertyInt(String key, int defaultValue) {        return ConvertHelper.toInt(getProperty(key), defaultValue);    }    public int getPropertyInt(String key) {        return getPropertyInt(key, 0);    }    public double getPropertyDouble(String key, double defaultValue) {        return ConvertHelper.toDouble(getProperty(key), defaultValue);    }    public double getPropertyDouble(String key) {        return getPropertyInt(key, 0);    }    public float getPropertyFloat(String key, float defaultValue) {        return ConvertHelper.toFloat(getProperty(key), defaultValue);    }    public float getPropertyFloat(String key) {        return getPropertyFloat(key, 0);    }}