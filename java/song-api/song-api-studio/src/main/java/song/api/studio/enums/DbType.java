package song.api.studio.enums;

import com.baomidou.mybatisplus.annotation.EnumValue;

/**
 * description:
 * author:          song
 * createDate:      2019/5/9
 */

public enum DbType {
    mysql("mysql"),
    sqlserver("sqlserver"),
    oracle("oracle"),
    other("other");

    @EnumValue
    private final String name;

    DbType(String name) {
        this.name=name;
    }

    public String getName() {
        return name;
    }
}
