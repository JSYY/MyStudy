<template>
  <div class="hello">
    <button @click="sendMessageToMainProcess">send</button>
  </div>
</template>

<script lang="ts">
    import { ipcRenderer } from 'electron';

    export default {
        setup() {
            ipcRenderer.on('return', (e: any, data: any) => {
                console.log(data);
            });

            function sendMessageToMainProcess() {
                ipcRenderer.send('message', 'send message to MainProcess');
            }

            return {
                sendMessageToMainProcess,
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
    .hello{
        width:100px;
        height:100px;
        background-color:aquamarine;
    }
</style>
