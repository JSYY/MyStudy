<template>
  <div class="main">
    <button @click="sendTo">test api send to server</button>
  </div>
</template>

<script lang="ts">
import {HttpServices} from "../src/http-wrapper.service"

export default{
    setup(props:any) {
      
      function sendTo(){
        const url = 'api/services/app/Test/TestMethod';
        HttpServices.get(url);
      }

      return{
        sendTo,
      }
    },
}
</script>

<style scoped lang="scss">
.main{
  width: 100%;
  height: 100%;
  background-color: cadetblue;
}

body{
  width: 100%;
  height: 100%;
}
</style>
