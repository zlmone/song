package song.api.studio.controller;import org.springframework.beans.factory.annotation.Autowired;import org.springframework.web.bind.annotation.PostMapping;import org.springframework.web.bind.annotation.RequestMapping;import org.springframework.web.bind.annotation.RestController;import song.api.studio.builder.transform.DbModelTransform;import song.api.studio.builder.transform.PdmModelTransform;import song.api.studio.model.Connection;import song.api.studio.model.Table;import song.api.studio.service.impl.ConnectionService;import song.api.studio.service.impl.TableService;import song.common.io.FileHelper;import song.common.result.ActionResult;import java.util.List;/** * description: * author:          song * createDate:      2018/11/26 */@RestController@RequestMapping("/modelfill")public class ModelFillController {    @Autowired    private ConnectionService connectionService;    @Autowired    private TableService tableService;    @PostMapping(value = "/dbtables")    public ActionResult dbTables(String projectId, String connectionId) throws Exception {        Connection connection = connectionService.findById(connectionId);        DbModelTransform transform = new DbModelTransform(connection);        List<Table> tables = transform.getTables();        tableService.fillTables(projectId, tables);        return new ActionResult(true);    }    @PostMapping(value = "/dbcolumns")    public ActionResult dbColumns(String projectId, String connectionId, String tableId, String tableName) throws Exception {        Connection connection = connectionService.findById(connectionId);        DbModelTransform transform = new DbModelTransform(connection);        Table table = transform.getTable(tableName);        tableService.fillColumns(projectId, tableId, table.getColumns());        return new ActionResult(true);    }    @PostMapping(value = "/pdmtables")    public ActionResult pdmTables(String projectId, String filePath) throws Exception {        if (FileHelper.exists(filePath)) {            PdmModelTransform transform = new PdmModelTransform(filePath);            List<Table> tables = transform.getTables();            tableService.fillTables(projectId, tables);            //解析完成，删除pdm文件            FileHelper.delete(filePath);            return new ActionResult(true);        }        return new ActionResult(false);    }    @PostMapping(value = "/pdmcolumns")    public ActionResult pdmColumns(String projectId, String filePath, String tableId, String tableName) throws Exception {        if (FileHelper.exists(filePath)) {            PdmModelTransform transform = new PdmModelTransform(filePath);            Table table = transform.getTable(tableName);            tableService.fillColumns(projectId, tableId, table.getColumns());            //解析完成，删除pdm文件            FileHelper.delete(filePath);            return new ActionResult(true);        }        return new ActionResult(false);    }}