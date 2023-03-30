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
export default {
  setup() {
    let flag = ref(false);
    onMounted(() => {
      //var canvas = document.getElementById("video-canvas");
      //var url = "ws://localhost:8992";
      ////audio设置为false可以取消掉页面的 audiocontext警告
      //  var video = new JSMpeg.Player(url, { canvas: canvas, audio: false, preserveDrawingBuffer: true });

        var canvas = document.getElementById("video-canvas");
                var url = "ws://localhost:18002";
                //audio设置为false可以取消掉页面的 audiocontext警告
                var video = new JSMpeg.Player(url, { canvas: canvas, audio: false, preserveDrawingBuffer: true });
      
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
