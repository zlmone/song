drop table if exists studio_column;

drop table if exists studio_connection;

drop table if exists studio_param;

drop table if exists studio_project;

drop table if exists studio_table;

drop table if exists studio_template;

drop table if exists studio_user;

/*==============================================================*/
/* Table: studio_column                                         */
/*==============================================================*/
create table studio_column
(
   id                   char(36) not null,
   table_id             char(36) not null,
   dield                varchar(50) not null,
   display              varchar(30) not null,
   db_data_type         varchar(30),
   data_type            varchar(30) not null,
   is_primary_key       bool,
   length               int,
   `precision`            int,
   editable             bool,
   editor_type          varchar(30),
   sortable             bool,
   queryable            bool,
   is_export            bool,
   is_import            bool,
   is_frozen            bool,
   is_hidden            bool,
   required             bool,
   width                int,
   format_string        varchar(50),
   default_value        varchar(200),
   align                varchar(10),
   rowspan              tinyint,
   colspan              tinyint,
   order_id             int,
   enable               bool,
   comment              varchar(500),
   create_user          varchar(40),
   create_time          timestamp not null,
   last_update_user     varchar(40),
   last_update_time     timestamp,
   primary key (id)
);

/*==============================================================*/
/* Table: studio_connection                                     */
/*==============================================================*/
create table studio_connection
(
   id                   char(36) not null,
   connection_name      varchar(20) not null,
   db_type              varchar(10) not null,
   url                  varchar(300) not null,
   user_name            varchar(50),
   password             varchar(100),
   create_user          varchar(40),
   create_time          timestamp not null,
   last_update_user     varchar(40),
   last_update_time     timestamp,
   primary key (id)
);

/*==============================================================*/
/* Table: studio_param                                          */
/*==============================================================*/
create table studio_param
(
   id                   char(36) not null,
   template_id          char(36),
   param_name           varchar(50) not null,
   param_code           varchar(20),
   param_value          varchar(200),
   comment              varchar(200),
   create_user          varchar(40),
   create_time          timestamp not null,
   last_update_user     varchar(40),
   last_update_time     timestamp,
   primary key (id)
);

/*==============================================================*/
/* Table: studio_project                                        */
/*==============================================================*/
create table studio_project
(
   id                   char(36) not null,
   project_code         varchar(100),
   project_name         varchar(50) not null,
   name_space           varchar(100) not null,
   template_id          char(36),
   connection_id        char(36),
   comment              varchar(200),
   create_user          varchar(40),
   create_time          timestamp not null,
   last_update_user     varchar(40),
   last_update_time     timestamp,
   primary key (id)
);

/*==============================================================*/
/* Table: studio_table                                          */
/*==============================================================*/
create table studio_table
(
   id                   char(36) not null,
   project_id           char(36) not null,
   table_code           varchar(100),
   table_name           varchar(50) not null,
   primary_key          varchar(30) not null,
   primary_key_type     varchar(10),
   default_sort_name    varchar(30),
   default_sort_type    varchar(5),
   comment              varchar(200),
   enable               bool,
   create_user          varchar(40),
   create_time          timestamp not null,
   last_update_user     varchar(40),
   last_update_time     timestamp,
   primary key (id)
);

/*==============================================================*/
/* Table: studio_template                                       */
/*==============================================================*/
create table studio_template
(
   id                   char(36) not null,
   parent_id            char(36) not null,
   template_name        varchar(30) not null,
   file_prefix          varchar(10),
   file_extensions      varchar(20),
   file_name            varchar(30),
   content              longtext,
   comment              varchar(100),
   create_user          varchar(40),
   create_time          timestamp not null,
   last_update_user     varchar(40),
   last_update_time     timestamp,
   primary key (id)
);

/*==============================================================*/
/* Table: studio_user                                           */
/*==============================================================*/
create table studio_user
(
   id                   char(36) not null,
   user_name            varchar(30) not null,
   real_name            varchar(10) not null,
   password             varchar(50) not null,
   is_admin             bool not null,
   ip_address           varchar(20) not null,
   mac_address          varchar(30) not null,
   enable               bool,
   email                varchar(50),
   create_user          varchar(40),
   create_time          timestamp not null,
   last_update_user     varchar(40),
   last_update_time     timestamp,
   primary key (id)
);
