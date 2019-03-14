/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2017/12/8 16:18:38                           */
/*==============================================================*/


drop table if exists studio_column;

drop table if exists studio_connection;

drop table if exists studio_project;

drop table if exists studio_table;

drop table if exists studio_template;

drop table if exists studio_userInfo;

/*==============================================================*/
/* Table: studio_Column                                         */
/*==============================================================*/
create table studio_column
(
   Id                   varchar(36) not null,
   TableID              varchar(40) not null,
   `Field`              varchar(50) not null,
   Display               varchar(30) not null,
   DBDataType           varchar(30),
   `DataType`              varchar(30) not null,
   IsPrimaryKey         bool,
   Length               int,
   `Precision`            int,
   Editable				bool,
   EditorType           varchar(30),
   Sortable             bool,
   Queryable            bool,
   IsExport               bool,
   IsImport               bool,
   IsFrozen               bool,
   IsHidden               bool,
   Required             bool,
   Width                int,
   FormatString          varchar(50),
   DefaultValue          varchar(200),
   Align                 varchar(10),
   Rowspan              tinyint,
   Colspan              tinyint,
   OrderID              int,
   Enabled              bool,
   `Comment`				varchar(500),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (Id)
);

/*==============================================================*/
/* Table: studio_Connection                                     */
/*==============================================================*/
create table studio_connection
(
   Id                   varchar(40) not null,
   ConnectionName        varchar(20) not null,
   DBType                varchar(10) not null,
   Url                   varchar(300) not null,
   UserName              varchar(50),
   Password              varchar(100),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (Id)
);

/*==============================================================*/
/* Table: studio_Project                                        */
/*==============================================================*/
create table studio_project
(
   Id                   varchar(40) not null,
   ProjectCode           varchar(100),
   ProjectName           varchar(50) not null,
   NameSpace             varchar(100) not null,
   TemplateID           varchar(40),
   ConnectionID         varchar(40),
   `Comment`               varchar(200),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (Id)
);

/*==============================================================*/
/* Table: studio_Table                                          */
/*==============================================================*/
create table studio_table
(
   Id                   varchar(40) not null,
   ProjectID            varchar(40) not null,
   TableCode             varchar(100),
   TableName             varchar(50) not null,
   PrimaryKey            varchar(30) not null,
   PrimaryKeyType           varchar(10),
   DefaultSortName       varchar(30),
   DefaultSortType       varchar(5),
   `Comment`               varchar(200),
   Enabled              bool,
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (Id)
);

/*==============================================================*/
/* Table: studio_Template                                       */
/*==============================================================*/
create table studio_template
(
   Id                   varchar(40) not null,
   ParentID             varchar(40) not null,
   TemplateName          varchar(30) not null,
   FilePrefix            varchar(10),
   FileExtensions        varchar(20),
   FileName              varchar(30),
   Content              longtext,
   `Comment`               varchar(100),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (Id)
);

/*==============================================================*/
/* Table: studio_UserInfo                                       */
/*==============================================================*/
create table studio_user
(
   Id                   varchar(40) not null,
   UserName              varchar(30) not null,
   RealName              varchar(10) not null,
   Password              varchar(50) not null,
   IsAdmin              bool not null,
   IPAddress             varchar(20) not null,
   MacAddress            varchar(30) not null,
   Enabled              bool,
   Email                 varchar(50),
   CreateUser           varchar(40),
   CreateTime           datetime not null,
   LastUpdateUser       varchar(40),
   LastUpdateTime       datetime,
   primary key (Id)
);

