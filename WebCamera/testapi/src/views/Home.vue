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
    import { onMounted, onUnmounted, ref } from "@vue/runtime-core";
    import JSMpeg from '../components/jsmpeg.min.js';
export default {
  setup() {
        let flag = ref(false);
        let video;

        onMounted(() => {
            let canvas = document.getElementById("video-canvas");
            let url = "ws://localhost:18002";
            video = new JSMpeg.Player(url, { canvas: canvas, audio: false, preserveDrawingBuffer: true });
        });

        onUnmounted(() => {
            //实例销毁时关闭socket连接
            video.source.shouldAttemptReconnect = false;
            video.source.socket.close();
            video = null;
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
