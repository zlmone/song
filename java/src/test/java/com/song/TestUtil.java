package com.song;import com.song.util.FormatHelper;import com.song.util.RandomText;/** * Created by song on 2017/9/23. */public class TestUtil {    public static void main(String[] args) {        TestUtil testUtil = new TestUtil();        testUtil.runFormat();        testUtil.runRandomText();    }    private void runFormat() {        float filesize= 333f;        String size = FormatHelper.parseFileSize(filesize);        System.out.println(size);    }    private void runRandomText(){        RandomText random=new RandomText();        random.setAllowLowerCase(true);        random.setAllowSpecial(true);        random.setAllowUpperCase(true);        String text=random.next(50);        System.out.println(text);    }}