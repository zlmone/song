package song.service.user.service;import song.service.user.model.Demo;import java.util.List;/** * description: * author:          song * createDate:      2018/4/13 */public interface DemoService {    List<Demo> getByName(String name);}