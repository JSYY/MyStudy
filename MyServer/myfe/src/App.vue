<template>
  <div class="main">
    <button @click="sendTo">test api send to server</button>
  </div>
</template>

<script lang="ts">
import {HttpServices} from "./services/http-wrapper.service"
import * as signalR from '@microsoft/signalr';
import { onMounted } from 'vue';

export default{
    setup(props:any) {
      let connection: signalR.HubConnection;

      onMounted(()=>{
        startSignalrConnection();
      });

      function sendTo(){
        const url = 'api/services/app/Test/TestMethod';
        HttpServices.get(url);
      }

      function startSignalrConnection(){
        connection = new signalR.HubConnectionBuilder().withUrl('/webconsolehub').build();
        connection.start();
        connection.on("TestMessage",()=>{
          console.log("receive signalr message");
        });
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
