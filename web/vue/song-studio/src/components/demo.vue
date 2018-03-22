<template>
  <div>
    <el-button type="primary" icon="el-icon-search">查询</el-button>
    <el-progress :percentage="0"></el-progress>
    <el-progress :percentage="70"></el-progress>
    <el-progress :percentage="100" status="success"></el-progress>
    <el-progress :percentage="50" status="exception"></el-progress>
  </div>
</template>
