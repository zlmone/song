package song.api.knowledge.controller;import org.apache.commons.fileupload.FileUploadException;import org.springframework.beans.factory.annotation.Autowired;import org.springframework.web.bind.annotation.PostMapping;import org.springframework.web.bind.annotation.RequestMapping;import org.springframework.web.bind.annotation.RestController;import org.springframework.web.multipart.MultipartFile;import song.api.knowledge.config.FtpConfig;import song.common.io.FileHelper;import song.common.net.http.HttpFile;import song.common.result.ActionResult;import song.common.result.UploaderFileResult;import song.common.toolkit.base.BaseController;import song.common.toolkit.net.ftp.FtpManager;import song.common.toolkit.net.http.HttpFileRequest;import javax.servlet.http.HttpServletRequest;import java.io.IOException;import java.util.ArrayList;import java.util.List;import java.util.Map;/** * description: * author:          song * createDate:      2018/1/24 */@RestController@RequestMapping("/uploader")public class LiteratureController extends BaseController {    protected final static String savaPathKey = "savePath";    @Autowired    private FtpConfig ftpConfig;    @PostMapping(value = "upload")    public ActionResult upload(MultipartFile[] file,String savePath,String saveType) {        for (MultipartFile multipartFile : file) {            //保存到服务器，或者ftp            if (saveType == "ftp") {            }else{            }        }        return success();    }    @PostMapping(value = "/server")    public ActionResult uploadServer(HttpServletRequest request) throws IOException, FileUploadException {        List<UploaderFileResult> fileResults = new ArrayList<>();        ActionResult result = new ActionResult();        HttpFileRequest fileRequest = new HttpFileRequest(request);        //获取文件保存的地址        String savePath = fileRequest.getData(savaPathKey);        Map<String, HttpFile> fileMap = fileRequest.batchSaveFile(savePath);        for (Map.Entry<String, HttpFile> entry : fileMap.entrySet()) {            HttpFile httpFile = entry.getValue();            UploaderFileResult uploaderFile = parseUploaderFile(httpFile);            uploaderFile.setName(entry.getKey());            fileResults.add(uploaderFile);        }        result.setData(fileResults);        return result;    }    @PostMapping(value = "/ftp")    public ActionResult uploadFtp(HttpServletRequest request) throws IOException, FileUploadException {        ActionResult result = new ActionResult();        List<UploaderFileResult> fileResults = new ArrayList<>();        HttpFileRequest fileRequest = new HttpFileRequest(request);        //获取文件保存的地址        String savePath = fileRequest.getData(savaPathKey);        List<HttpFile> files = fileRequest.getFileItems();        FtpManager ftpManager = new FtpManager(ftpConfig);        try {            ftpManager.open();            for (HttpFile file : files) {                UploaderFileResult uploaderFile = parseUploaderFile(file);                String newFileName = FileHelper.getNewFileName(file.getFileName());                //上传到ftp                ftpManager.upload(newFileName, savePath, file.getInputStream());                uploaderFile.setName(newFileName);                fileResults.add(uploaderFile);                file.close();            }        } finally {            ftpManager.close();        }        result.setData(fileResults);        return result;    }    private UploaderFileResult parseUploaderFile(HttpFile file) {        UploaderFileResult uploaderFile = new UploaderFileResult();        uploaderFile.setExt(file.getExtension());        uploaderFile.setPath(file.getFilePath());        uploaderFile.setRealName(file.getFileName());        uploaderFile.setSize(file.getSize());        return uploaderFile;    }}