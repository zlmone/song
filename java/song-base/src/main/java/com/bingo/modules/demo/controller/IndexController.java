package com.bingo.modules.demo.controller;

import com.bingo.modules.demo.service.DemoService;
import org.apache.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import javax.servlet.http.HttpServletRequest;

@RequestMapping("/index")
@Controller
public class IndexController {

    @Autowired
    private DemoService demoService;

    private static Logger logger = Logger.getLogger(IndexController.class);

    @RequestMapping(value = "/upload", method = RequestMethod.POST)
    public String upload(HttpServletRequest request) {
      /*  try {
            HttpFileRequest fileRequest = new HttpFileRequest(request);
            String savePath = fileRequest.getRealPath("WEB-INF/upload");
            fileRequest.batchSave(savePath);
        } catch (IOException e) {
            e.printStackTrace();
        } catch (FileUploadException e) {
            e.printStackTrace();
        }*/

        return "index";
    }

    @RequestMapping("/test")
    public String test(HttpServletRequest request) {

        try {
//			Demo demo = new Demo();
//			demo.setName("test");
//			demo.setMsg("test");
//			demoService.insert(demo);

//			Demo d = demoService.selectById("t1");
//			System.out.println(d.getId() + "---" + d.getName() + "---" + d.getMsg());



        } catch (Exception e) {
            e.printStackTrace();
        }

        return "success";
    }


}
