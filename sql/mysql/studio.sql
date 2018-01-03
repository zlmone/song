/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2017/12/8 16:18:38                           */
/*==============================================================*/


drop table if exists studio_Column;

drop table if exists studio_Connection;

drop table if exists studio_Project;

drop table if exists studio_Table;

drop table if exists studio_Template;

drop table if exists studio_UserInfo;

/*==============================================================*/
/* Table: studio_Column                                         */
/*==============================================================*/
create table studio_Column
(
   ID                   varchar(40) not null,
   TableID              varchar(40) not null,
   `Field`                national varchar(50) not null,
   Display              national varchar(30) not null,
   DBDataType           varchar(30),
   `DataType`             national varchar(30) not null,
   IsPrimaryKey         bool,
   Length               int,
   `Precision`            int,
   EditorType           varchar(30),
   Sortable             bool,
   Queryable            bool,
   Export               bool,
   Import               bool,
   Frozen               bool,
   Hidden               bool,
   Required             bool,
   Width                int,
   FormatString         national varchar(50),
   DefaultValue         national varchar(200),
   Align                national varchar(10),
   Rowspan              tinyint,
   Colspan              tinyint,
   OrderID              int,
   Enabled              bool,
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (ID)
);

/*==============================================================*/
/* Table: studio_Connection                                     */
/*==============================================================*/
create table studio_Connection
(
   ID                   varchar(40) not null,
   ConnectionName       national varchar(20) not null,
   DBType               national varchar(10) not null,
   Url                  national varchar(300) not null,
   UserName             national varchar(50),
   Password             national varchar(100),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (ID)
);

/*==============================================================*/
/* Table: studio_Project                                        */
/*==============================================================*/
create table studio_Project
(
   ID                   varchar(40) not null,
   ProjectCode          national varchar(100),
   ProjectName          national varchar(50) not null,
   NameSpace            national varchar(100) not null,
   TemplateID           varchar(40),
   ConnectionID         varchar(40),
   `Comment`              national varchar(200),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (ID)
);

/*==============================================================*/
/* Table: studio_Table                                          */
/*==============================================================*/
create table studio_Table
(
   ID                   varchar(40) not null,
   ProjectID            varchar(40) not null,
   TableCode            national varchar(100),
   TableName            national varchar(50) not null,
   PrimaryKey           national varchar(30) not null,
   PrimaryKeyType          national varchar(10),
   DefaultSortName      national varchar(30),
   DefaultSortType      national varchar(5),
   `Comment`              national varchar(200),
   Enabled              bool,
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (ID)
);

/*==============================================================*/
/* Table: studio_Template                                       */
/*==============================================================*/
create table studio_Template
(
   ID                   varchar(40) not null,
   ParentID             varchar(40) not null,
   TemplateName         national varchar(30) not null,
   FilePrefix           national varchar(10),
   FileExtensions       national varchar(20),
   FileName             national varchar(30),
   Content              longtext,
   `Comment`              national varchar(100),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (ID)
);

/*==============================================================*/
/* Table: studio_UserInfo                                       */
/*==============================================================*/
create table studio_UserInfo
(
   ID                   varchar(40) not null,
   UserName             national varchar(30) not null,
   RealName             national varchar(10) not null,
   Password             national varchar(50) not null,
   IsAdmin              bool not null,
   IPAddress            national varchar(20) not null,
   MacAddress           national varchar(30) not null,
   Enabled              bool,
   Email                national varchar(50),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (ID)
);

