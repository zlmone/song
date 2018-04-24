<template>
  <div>
    <song-table :url="url" :columns="columns"></song-table>
  </div>
</template>

<script>
import  SongTable  from '@/components/song/SongTable'
 
export default {
  components:{
    SongTable
  },
  data() {
    return {
      url:"/demo/list",
      columns:[
        {prop:"id",label:"ID"},
        {prop:"name",label:"姓名"}
      ]
    }
  }
}
</script>
