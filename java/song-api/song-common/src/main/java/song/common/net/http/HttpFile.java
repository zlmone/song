package song.common.net.http;import song.common.io.FileInfo;import song.common.io.StreamHelper;import java.io.Closeable;import java.io.IOException;import java.io.InputStream;/** * description:     HttpFile * author:          song * createDate:      2017/9/28 */public class HttpFile extends FileInfo implements Closeable{    private String fieldName;    public String getFieldName() {        return fieldName;    }    public void setFieldName(String fieldName) {        this.fieldName = fieldName;    }    private InputStream inputStream;    public InputStream getInputStream() {        return inputStream;    }    public void setInputStream(InputStream inputStream) {        this.inputStream = inputStream;    }    @Override    public void close() throws IOException {        StreamHelper.close(this.inputStream);    }}