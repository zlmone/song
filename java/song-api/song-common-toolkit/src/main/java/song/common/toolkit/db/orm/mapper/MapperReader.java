package song.common.toolkit.db.orm.mapper;import song.common.toolkit.xml.XMLHelper;import song.common.ui.TagNode;import song.common.util.ListHelper;import org.dom4j.DocumentException;import java.util.HashMap;import java.util.List;import java.util.Map;/** * description: * author:          song * createDate:      2017/11/4 */public class MapperReader {    //定义select语句缓存    public static Map<String, Map<String, String>> selects;    private static List<String> filePaths;    public static void setFilePath(List<String> filePaths) {        filePaths = filePaths;    }    /**     * 获取mapper配置的查询语句     *     * @param mapperId     * @param selectId     * @return     */    public static String getSelect(String mapperId, String selectId) {        if (selects == null) {            readMappers();        }        if (selects.containsKey(mapperId)) {            Map<String, String> mapper = selects.get(mapperId);            if (mapper.containsKey(selectId)) {                return mapper.get(selectId);            }        }        return null;    }    private static void readMappers() {        selects = new HashMap<String, Map<String, String>>();        if (!ListHelper.isEmpty(filePaths)) {            for (String filePath : filePaths) {                readMapper(filePath);            }        }    }    private static void readMapper(String filePath) {        try {            TagNode node = XMLHelper.parseTagNode(filePath);            if (node != null) {                Map<String, String> map = new HashMap<String, String>();                String mapperId = node.getAttribute("id");                for (TagNode tagNode : node.getChildNodes()) {                    map.put(tagNode.getAttribute("id"), tagNode.getText());                }                selects.put(mapperId, map);            }        } catch (DocumentException e) {            e.printStackTrace();        }    }}