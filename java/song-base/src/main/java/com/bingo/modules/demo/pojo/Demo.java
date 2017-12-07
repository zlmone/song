package com.bingo.modules.demo.pojo;

import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Table(name = "demo")
public class Demo {

    @Id
    @Column(name = "id")
    @GeneratedValue(generator = "UUID")
    private String id;
    @Column(name = "name")
    private String name;
    @Column(name = "msg")
    private String msg;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getMsg() {
        return msg;
    }

    public void setMsg(String msg) {
        this.msg = msg;
    }
}