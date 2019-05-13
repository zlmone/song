package song.api.studio.controller;import org.springframework.beans.factory.annotation.Autowired;import org.springframework.stereotype.Controller;import org.springframework.web.bind.annotation.*;import song.api.studio.model.Connection;import song.api.studio.model.Project;import song.api.studio.service.IProjectService;import song.common.result.ActionResult;import song.common.toolkit.base.BaseController;import java.util.List;/** * description: * author:          song * createDate:      2017/12/28 */@RequestMapping("/project")@RestControllerpublic class ProjectController extends BaseController {    @Autowired    private IProjectService projectService;    @GetMapping(value = "/list")    public ActionResult getList() {        return success(projectService.getList());    }    @GetMapping(value = "/info")    public ActionResult getInfo(String id) {        return success(projectService.getById(id));    }    @PostMapping(value = "/save")    public ActionResult save(@RequestBody Project entity) {        return saveSuccess(projectService.saveOrUpdate(entity));    }    @DeleteMapping(value = "/remove")    public ActionResult remove(String id) {        return success(projectService.removeById(id));    }}