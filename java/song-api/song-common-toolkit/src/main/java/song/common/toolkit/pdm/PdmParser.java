package song.common.toolkit.pdm;import org.dom4j.Document;import org.dom4j.Element;import org.dom4j.ProcessingInstruction;import org.dom4j.XPath;import song.common.db.DBType;import song.common.lang.ConvertHelper;import song.common.lang.StringHelper;import song.common.toolkit.xml.XMLHelper;import java.util.*;/** * description: * author:          song * createDate:      2017/10/25 */public class PdmParser {    private Document doc = null;    private List<PdmTable> tables = new ArrayList<PdmTable>();    private String target = null;    private String name;    private String version;    public PdmParser(String filePath) throws Exception {        doc = XMLHelper.readDocument(filePath);        parseProcessingInstruction();    }    public String getVersion() {        return version;    }    public String getName() {        return name;    }    public String getTarget() {        return target;    }    /**     * 解析pdm     */    public List<PdmTable> parse() {        //根据xpath方式得到所要得到xml文档的具体对象,根据分析解析xml文档可知，xml文档中含有前缀名        Map<String, String> map = new HashMap<String, String>();        map.put("c", "collection");        map.put("a", "attribute");        map.put("o", "object");        //根据xml文档，//c:Table 即为得到的文档对象        XPath path = doc.createXPath("//c:Tables");        path.setNamespaceURIs(map);        List<Element> list = path.selectNodes(doc);        //得到tables对象，该对象是该pdm文件中所有表的集合        for (Element element : list) {            for (Iterator<Element> iter = element.elementIterator("Table"); iter.hasNext(); ) {                Element table = iter.next();                parseAddTable(table);            }        }        return tables;    }    /**     * 获取数据库类型     *     * @return     */    public DBType parseDBType() {        if (!StringHelper.isEmpty(this.target)) {            String lowerTarget = this.target.toLowerCase();            //个性化数据库解析            if (lowerTarget.contains("sql server")) {                return DBType.sqlserver;            }            String[] types = {"oracle", "mysql", "access", "db2", "postgresql", "mongodb", "sqlite", "sqlserver"};            for (String type : types) {                if (lowerTarget.contains(type)) {                    return DBType.parse(type);                }            }            return DBType.other;        }        return null;    }    /**     * 解析文档指令     */    private void parseProcessingInstruction() {        ProcessingInstruction pi = doc.processingInstruction("PowerDesigner");        if (pi != null) {            target = pi.getValue("Target");            name = pi.getValue("Name");            version = pi.getValue("version");        }    }    /**     * 解析表     */    private void parseAddTable(Element element) {        if (element != null) {            PdmTable table = new PdmTable();            table.setId(element.attributeValue("Id"));            table.setObjectID(element.elementText("ObjectID"));            table.setName(element.elementText("Name"));            table.setCode(element.elementText("Code"));            table.setComment(element.elementText("Comment"));            Element columns = element.element("Columns");            Element keys = element.element("Keys");            Element parimaryKey = element.element("PrimaryKey");            table.setKeys(parseKeys(keys));            table.setPrimaryKey(parsePrimaryKey(parimaryKey, table.getKeys()));            table.setColumns(parseColumns(columns, table.getPrimaryKey()));            tables.add(table);        }    }    /**     * 解析列     */    private List<PdmColumn> parseColumns(Element element, PdmKey primaryKey) {        List<PdmColumn> columns = new ArrayList<PdmColumn>();        if (element != null) {            for (Iterator<Element> els = element.elementIterator("Column"); els.hasNext(); ) {                Element el = els.next();                PdmColumn column = new PdmColumn();                column.setId(el.attributeValue("Id"));                column.setObjectID(el.elementText("ObjectID"));                column.setName(el.elementText("Name"));                column.setCode(el.elementText("Code"));                column.setDataType(parseDataType(el.elementText("DataType")));                column.setLength(ConvertHelper.toInt(el.elementText("Length")));                //是否必填字段：兼容新老版本                String mandatory = el.elementText("Column.Mandatory");                column.setMandatory(ConvertHelper.similarBool(mandatory == null ? el.elementText("Mandatory") : mandatory));                column.setIdentity(ConvertHelper.similarBool(el.elementText("Identity")));                column.setComment(el.elementText("Comment"));                //设置是否为主键                column.setPrimaryKey(isPrimaryKeyColumn(column, primaryKey));                columns.add(column);            }        }        return columns;    }    private String parseDataType(String dataType) {        if (dataType != null) {            String regex = "\\(\\d*,?\\d*\\)";            return dataType.replaceAll(regex, "");        }        return dataType;    }    /**     * 判断列是否是主键     */    private boolean isPrimaryKeyColumn(PdmColumn column, PdmKey primaryKey) {        if (primaryKey != null) {            List<PdmKeyColumn> keyColumns = primaryKey.getColumns();            for (PdmKeyColumn keyColumn : keyColumns) {                if (keyColumn.getRef().equals(column.getId())) {                    return true;                }            }        }        return false;    }    /**     * 解析keys     */    private List<PdmKey> parseKeys(Element element) {        List<PdmKey> keys = new ArrayList<PdmKey>();        if (element != null) {            for (Iterator<Element> els = element.elementIterator("Key"); els.hasNext(); ) {                Element el = els.next();                PdmKey key = new PdmKey();                key.setId(el.attributeValue("Id"));                key.setObjectID(el.elementText("ObjectID"));                key.setName(el.elementText("Name"));                key.setCode(el.elementText("Code"));                //解析key.columns                Element keyColumns = el.element("Key.Columns");                key.setColumns(parseKeyColumns(keyColumns));                keys.add(key);            }        }        return keys;    }    /**     * 解析key.columns     */    private List<PdmKeyColumn> parseKeyColumns(Element element) {        List<PdmKeyColumn> keyColumns = new ArrayList<PdmKeyColumn>();        if (element != null) {            for (Iterator<Element> els = element.elementIterator("Column"); els.hasNext(); ) {                Element el = els.next();                PdmKeyColumn keyColumn = new PdmKeyColumn();                keyColumn.setRef(el.attributeValue("Ref"));                keyColumns.add(keyColumn);            }        }        return keyColumns;    }    /**     * 解析主键     */    private PdmKey parsePrimaryKey(Element element, List<PdmKey> keys) {        if (element != null) {            String ref = element.element("Key").attributeValue("Ref");            for (PdmKey key : keys) {                if (key.getId().equals(ref)) {                    return key;                }            }        }        return null;    }}