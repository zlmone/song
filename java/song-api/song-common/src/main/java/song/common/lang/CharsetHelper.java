package song.common.lang;/** * description:     字符编码辅助类 * author:          song * createDate:      2017/9/25 */public class CharsetHelper {    public static String getDefault() {        return "UTF-8";    }    public static String emptyDefault(String charset) {        if (StringHelper.isEmpty(charset)) {            return getDefault();        }        return charset;    }}