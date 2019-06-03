package song.api.knowledge.enums;

/**
 * description:
 * author:          song
 * createDate:      2019/6/3
 */

public enum LiteraryType {
    poetry("诗歌",1),
    word("词",2),
    song("曲",3),
    article("古文",4),
    couplet("对联",5),
    sentence("句子",6),
    terms("词语",7);

    private String text;
    private int value;

    LiteraryType(String text,int value) {
        this.text = text;
        this.value=value;
    }
}
