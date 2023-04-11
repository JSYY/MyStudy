<template>
    <div class="main">
        <div class="line" :style="locationLine"></div>
    </div>
   
</template>

<script lang="ts">
    import { onMounted,ref } from "vue";
    import * as Hammer from 'hammerjs';

    export default {
        setup() {
            let lineElement: any;
            let locationLine = ref();
            let locationX = 0;
            let locationY = 0;
            let angle = 0;

            onMounted(() => {
                lineElement = document.querySelector('.line');
                initPlanbox();
            });

            function initPlanbox() {
                if (lineElement) {
                    registerPanEvent(lineElement, (ev: Hammer.Input) => { handleLineEvent(ev) });
                }
            }

            function registerPanEvent(element: HTMLElement, handle: Function): void {
                let hammer = new Hammer(element)

                hammer.get('pan').set({ direction: Hammer.DIRECTION_ALL });
                hammer.on('panstart', (ev: Hammer.Input) => { handle(ev) });
                hammer.on('panmove', (ev: Hammer.Input) => handle(ev));
                hammer.on('rotatestart', (ev: Hammer.Input) => handle(ev));
                hammer.on('rotatemove', (ev: Hammer.Input) => handle(ev));
            }

            function handleLineEvent(e: Hammer.Input): void {
                locationX = e.deltaX;
                locationY = e.deltaY;
                angle = e.angle;
                console.log(e);
                locationLine.value = { 'transform': `translate(${locationX}px,${locationY}px) rotate(${angle}deg)` };
            }

            return {
                locationLine
            }
        }
    }
</script>

<style lang="scss">
    body {
        padding: 0px;
        margin: 0;
        user-select: none;
    }
    .main {
        width: 100%;
        height: 100%;
        position: absolute;
        background-color: antiquewhite;
        overflow:hidden;
    }
    .line {
        width: 100px;
        height: 5px;
        background-color: black;
        cursor: ns-resize;
        margin-top:100px;
        margin-left:100px;
    }
    .rectangle
    {
        width:80px;
        height:50px;
        background-color:coral;
    }
</style>
