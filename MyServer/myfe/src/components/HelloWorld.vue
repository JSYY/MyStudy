<template>
  <div class="main">
    <button @click="close">Close this window</button>
    <div>{{message}}</div>
  </div>
</template>

<script lang="ts">
import {DialogServices} from "../../src/utils/dialog.service";

export default{
    props:{
      message:String
    },
    setup(props:any) {
        
      function close(){
        DialogServices.RemoveDialogComponent();
      }

      return{
        close
      }
    },
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

.main{
  width: 300px;
  height: 300px;
  background-color: darkkhaki;
}

</style>
