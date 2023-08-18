<template>
    <div class="background rowCenterCenter">
        <video id="video-canvas" autoplay playsinline></video>
    </div>
</template>

<script lang="ts">
    import { onMounted, onBeforeUnmount } from "@vue/runtime-core";

    export default {
        name: 'Camera',
        setup() {
            let mediaStream:MediaStream;

            onMounted(() => {
                openCamera();
            });

            onBeforeUnmount(() => {
                stop();
            });

            function openCamera(){
                navigator.mediaDevices.getUserMedia({ audio: false,video: {width:800,height:800} }).then((res:MediaStream)=>{
                const videoEle = document.querySelector('video');
                mediaStream=res;
                if(videoEle){
                videoEle.srcObject = res;
                }
                });
            }

            function stop(){
                const videoEle = document.querySelector('video');
                if(videoEle== null){
                    return;
                }
                const tracks = mediaStream.getTracks();

                tracks.forEach((track:any)=> {
                    track.stop();
                });
                videoEle.srcObject = null;
            }

            return {

            }
        },
    }
</script>

<style scoped>
    #video-canvas {
    }

    .background {
        background-color: black;
        width: 100%;
        height: 100%;
        border-radius: 4px;
        overflow: hidden;
    }
</style>
