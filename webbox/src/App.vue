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
            let actionData = new ActionData();
            let movePositionData = new ActionData();
            let context: CanvasRenderingContext2D;
            let canvasEle;
            let canvasData = ref({ height: 0, width: 0 });

            onMounted(() => {
                line = document.querySelectorAll('.line');
                initbox();
                register();
            });

            function initbox() {
                boxData.lengthX = 200;
                boxData.lengthY = 200;

                updateCache(boxData);

                canvasEle = document.querySelector('.canvas');

                context = canvasEle.getContext('2d');
                context.strokeStyle = 'black';
                context.lineWidth = 2;
                context.strokeRect(1, 1, boxData.lengthX, boxData.lengthY);
                canvasData.value.height = boxData.lengthY;
                canvasData.value.width = boxData.lengthX;
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
                if (e.type == 'panmove') {
                    movePositionData.actionX = e.deltaX;
                    movePositionData.actionY = e.deltaY;
                    movePositionData.angle = e.angle;
                    console.log(movePositionData);
                }
                relocate();
                e.srcEvent.stopImmediatePropagation();
            }

            //stopImmediatePropagation 防止调用同一事件的其他侦听器

            function handleLineEvent(e: Hammer.Input): void {
                console.log(e);
                if (e.additionalEvent == 'panright' || e.additionalEvent == 'panleft') {
                    actionData.actionX = e.deltaX;
                    calculateBoxDataX();
                }
                if (e.additionalEvent == 'panup' || e.additionalEvent == 'pandown') {
                    actionData.actionY = e.deltaY;
                    calculateBoxDataY();
                }
                relocate();

                e.srcEvent.stopImmediatePropagation();
            }

            function calculateBoxDataX() {
                boxData.lengthX = boxDataCache.lengthX + actionData.actionX;
            }

            function calculateBoxDataY() {
                boxData.lengthY = boxDataCache.lengthY + actionData.actionY;
            }

            function completeAction() {
                console.log("complete");
                updateCache(boxData);
            }

            function relocate() {
                canvasData.value.height = boxData.lengthY;
                canvasData.value.width = boxData.lengthX;
                location.value = { 'transform': `translate(${movePositionData.actionX}px,${movePositionData.actionY}px) rotate(${movePositionData.angle}deg)` };
            }

            function updateCache(data: BoxData) {
                boxDataCache.lengthX = data.lengthX;
                boxDataCache.lengthY = data.lengthY;
            }

            return {
                location, line, canvasData, rectangle
            }
        }
    }

    export class BoxData {
        lengthX: number=0;
        lengthY: number=0;
    }
    export class ActionData {
        actionX: number = 0;
        actionY: number = 0;
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
