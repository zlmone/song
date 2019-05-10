<template>
  <div style="height:100%;">
    <Layout style="height:100%">
      <Sider hide-trigger width="300" style="height:100%">
    
            <Input  style="width:auto"/><Button type="primary" >添加项目</Button>
      
        <Tree :data="treeData"></Tree>
      </Sider>
      <Layout>
        <Header>header</Header>
        <Content>
          <Input type="textarea"/>
        </Content>
      </Layout>
    </Layout>
  </div>
</template>

<script>
import api from "@/libs/api.request";
export default {
  components: {},
  data() {
    return {
      treeData: []
    };
  },
  methods: {
    getTreeData() {
      api
        .get("model/read", {
          projectId: "",
          projectName: "项目"
        })
        .then(data => {
          if (data) {
            this.treeData = data;
          }
        });
    }
  },
  mounted() {
    this.getTreeData();
  }
};
</script>

<style>
</style>
