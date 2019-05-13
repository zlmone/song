package song.api.studio.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import song.api.studio.model.Connection;
import song.api.studio.model.Table;
import song.api.studio.model.Template;
import song.api.studio.service.ITemplateService;
import song.common.result.ActionResult;
import song.common.toolkit.base.BaseController;
import song.common.ui.iview.IVTreeNode;
import song.common.util.ListHelper;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/tpl")
public class TemplateController extends BaseController {
    @Autowired
    private ITemplateService templateService;

    @GetMapping(value = "/list")
    public ActionResult getList() {
        return success(templateService.list());
    }

    @GetMapping(value = "/read")
    public ActionResult read(){
        List<IVTreeNode> tree = new ArrayList<>();
        IVTreeNode root = new IVTreeNode("root", "代码模板","-1", true);
        //读取所有模板
        List<Template> tpls = templateService.list();
        tpls.forEach(item->{
            if(item.getParentId().equals(root.getData())) {
                IVTreeNode typeNode = new IVTreeNode(item.getId(), item.getTemplateName(), item.getParentId(),true);
                readChildren(typeNode,tpls);
                root.addChildren(typeNode);
            }
        });
        tree.add(root);
        return success(tree);
    }

    private void readChildren(IVTreeNode node, List<Template> tpls) {
        //递归查找子模块
        List<Template> subTpls=tpls.stream().filter(x-> x.getParentId().equals(node.getId())).collect(Collectors.toList());
        if(!ListHelper.isEmpty(subTpls)) {
            subTpls.forEach(item -> {
                IVTreeNode subNode = new IVTreeNode(item.getId(), item.getTemplateName(), item.getParentId(), true);
                readChildren(subNode,tpls);
                node.addChildren(subNode);
            });
        }
    }

    @GetMapping(value = "/info")
    public ActionResult getInfo(String id) {
        return success(templateService.getById(id));
    }

    @PostMapping(value = "/save")
    public ActionResult save(@RequestBody Template entity) {
        return saveSuccess(templateService.saveOrUpdate(entity));
    }

    @DeleteMapping(value = "/remove")
    public ActionResult remove(String id) {
        return success(templateService.removeById(id));
    }
}
