<template>
  <div style="height:100%;">
    <Tree :data="treeData"></Tree>
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
      api.get("tpl/read", {}).then(data => {
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
