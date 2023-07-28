<template>
  <div class="main">
    <button @click="sendTo">test api send to server</button>
    <button @click="addDialog">add dialog</button>
  </div>
</template>

<script lang="ts">
import {HttpServices} from "./services/http-wrapper.service";
import { DialogServices } from "./utils/dialog.service";
import * as signalR from '@microsoft/signalr';
import HelloWorld from "./components/HelloWorld.vue";
import { getCurrentInstance, onMounted } from 'vue';

export default{
    setup(props:any) {
      let connection: signalR.HubConnection;
      let ins = getCurrentInstance();
      let count=0;
      
      onMounted(()=>{
        startSignalrConnection();
      });

      function addDialog(){
        DialogServices.AddDialogComponent(ins,HelloWorld,{message:count.toString()});
        count++;
      }

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
        sendTo,addDialog
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
