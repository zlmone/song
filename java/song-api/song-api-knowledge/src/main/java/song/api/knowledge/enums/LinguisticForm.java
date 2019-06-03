package song.api.knowledge.enums;

/**
 * description:
 * author:          song
 * createDate:      2019/6/3
 */

public enum LinguisticForm {
    oldstyle("古体",1),
    newstyle("新体",2),
    abroad("国外",3);

    private int value;
    private String text;

    LinguisticForm(String text,int value) {
        this.value = value;
        this.text = text;
    }
}
