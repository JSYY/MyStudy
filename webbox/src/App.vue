<template>
    <div class="main">
            <div class="box" :style="location">
                <div class="line top-line"></div>
                <div class="line left-line"></div>
                <div class="line right-line"></div>
                <div class="line bottom-line"></div>
                <canvas class="canvas" :style="rectangle" :height="canvasData.height" :width="canvasData.width"></canvas>
            </div>
    </div>
</template>

<script lang="ts">
    import { onMounted,ref } from "vue";
    import * as Hammer from 'hammerjs';

    export default {
        setup() {
            let location = ref();
            let rectangle = ref();
            let line;
            let boxData = new BoxData();
            let boxDataCache = new BoxData();
            let context: CanvasRenderingContext2D;
            let canvasEle;
            let canvasData = ref({ height: 0, width: 0 });

            onMounted(() => {
                line = document.querySelectorAll('.line');
                canvasEle = document.querySelector('.canvas');
                initbox();
                register();
            });

            function initbox() {
                boxData.width = 200;
                boxData.height = 200;
                boxData.positionY = 0;
                boxData.positionX = 0;
                boxData.angle = 0;
                updateCache(boxData);

                context = canvasEle.getContext('2d');
                context.strokeStyle = 'black';
                context.lineWidth = 2;
                context.strokeRect(1, 1, boxData.width, boxData.height);
                canvasData.value.height = boxData.height;
                canvasData.value.width = boxData.width;
            }

            function register() {
                if (line) {
                    line.forEach(item => {
                        registerPanEvent(item, (ev: Hammer.Input) => { handleLineEvent(ev) });
                    });
                }
                if (canvasEle) {
                    registerPanEvent(canvasEle, (ev: Hammer.Input) => { handleCanvasMoveEvent(ev) });
                }
            }

            function registerPanEvent(element: HTMLElement, handle: Function): void {
                let hammer = new Hammer(element)
                hammer.get('pan').set({ direction: Hammer.DIRECTION_ALL });
                hammer.on('panstart', (ev: Hammer.Input) => { handle(ev) });
                hammer.on('panmove', (ev: Hammer.Input) => handle(ev));
                hammer.on('panend', (ev: Hammer.Input) => { completeAction(); });
            }

            function handleCanvasMoveEvent(e: Hammer.Input): void {
                boxData.positionX = boxDataCache.positionX + e.deltaX;
                boxData.positionY = boxDataCache.positionY + e.deltaY;
                boxData.angle = boxDataCache.angle + e.angle;
                relocate();
                e.srcEvent.stopImmediatePropagation();
            }

            //stopImmediatePropagation 防止调用同一事件的其他侦听器

            function handleLineEvent(e: Hammer.Input): void {
                console.log(e);
                if (e.target.className.indexOf('right-line') > -1) {
                    boxData.width = boxDataCache.width + e.deltaX;
                }
                if (e.target.className.indexOf('left-line')>-1) {
                    boxData.width = boxDataCache.width - e.deltaX;
                    boxData.positionX = boxDataCache.positionX + e.deltaX;
                }
                if (e.target.className.indexOf('top-line') > -1) {
                    boxData.height = boxDataCache.height - e.deltaY;
                    boxData.positionY = boxDataCache.positionY + e.deltaY;
                }
                if (e.target.className.indexOf('bottom-line') > -1) {
                    boxData.height = boxDataCache.height + e.deltaY;
                }
                relocate();
                e.srcEvent.stopImmediatePropagation();
            }

            function completeAction() {
                console.log("complete");
                updateCache(boxData);
            }

            function relocate() {
                location.value = { 'transform': `translate(${boxData.positionX}px,${boxData.positionY}px) rotate(${boxData.angle}deg)` };
                rectangle.value = { 'height': `${boxData?.height}px`, 'width': `${boxData?.width}px` };
                canvasData.value.height = boxData?.height;
                canvasData.value.width = boxData?.width;
            }

            function updateCache(data: BoxData) {
                boxDataCache.height = data.height;
                boxDataCache.width = data.width;
                boxDataCache.positionX = data.positionX;
                boxDataCache.positionY = data.positionY;
                boxDataCache.angle = data.angle;
            }

            return {
                location, line, canvasData, rectangle
            }
        }
    }

    export class BoxData {
        width: number=0;
        height: number = 0;
        positionX: number = 0;//box的坐标
        positionY: number = 0;
        angle: number = 0;
    }
</script>

<style lang="scss">
    body {
        padding: 0px;
        margin: 0;
        user-select: none;
    }
    .box {
        position: absolute;
        height: min-content;
        width: min-content;
        margin: 100px;
        background-color: #bbf5ef;
    }
    .main {
        width: 100%;
        height: 100%;
        position: absolute;
        background-color: antiquewhite;
        overflow:hidden;
    }
    .line {
        background-color: seagreen;
        position:absolute;
    }
    .line.bottom-line{
        height:5px;
        width:100%;
        bottom:0;
        cursor:ns-resize;
    }
    .line.top-line {
        height: 5px;
        width: 100%;
        top: 0;
        cursor: ns-resize;
    }

    .line.left-line {
        height: 100%;
        width: 5px;
        left:0;
        cursor:ew-resize;
    }
    .line.right-line {
        height: 100%;
        width: 5px;
        right:0;
        cursor:ew-resize;
    }
    .canvas {
        z-index: 999;
        display: block;
        cursor: all-scroll;
    }
</style>
