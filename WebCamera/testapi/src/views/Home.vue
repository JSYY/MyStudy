<template>
 <button @click="openCamera">CameraController</button>
  <div class="home" v-show="flag">
    <canvas
      id="video-canvas"
      style="height: 600px; width: 800px; background-color: black"
    ></canvas>
  </div>
</template>

<script lang="js">
    import { onMounted, ref } from "@vue/runtime-core";
    import JSMpeg from './jsmpeg.min.js';
export default {
  setup() {
    let flag = ref(false);
    onMounted(() => {
        let canvas = document.getElementById("video-canvas");
        let url = "ws://localhost:18002";
        //audio设置为false可以取消掉页面的 audiocontext警告
        let video = new JSMpeg.Player(url, { canvas: canvas, audio: false, preserveDrawingBuffer: true });
      
    });

    function openCamera() {
      flag.value=!flag.value;
    }

    return{
      openCamera,
      flag
    }
  },
};
</script>
