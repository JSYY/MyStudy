<template>
    <div class="line" :style="location"></div>
</template>

<script lang="ts">
    import { onMounted,ref } from "vue";
    import * as Hammer from 'hammerjs';

    export default {
        setup() {
            let dragBlockElements: any;
            let location = ref();
            let locationX = 0;
            let locationY = 0;

            onMounted(() => {
                dragBlockElements = document.querySelectorAll('.line');
                initPlanbox();
            });

            function initPlanbox() {
                if (dragBlockElements)
                    dragBlockElements.forEach(block => {
                        registerPanEvent(block, (ev: Hammer.Input) => { handleDragBlockEvent(ev) });
                    })
            }
            function registerPanEvent(element: HTMLElement, handle: Function): void {
                let hammer = new Hammer(element)

                hammer.get('pan').set({ direction: Hammer.DIRECTION_ALL });
                hammer.on('panstart', (ev: Hammer.Input) => { handle(ev) });
                hammer.on('panmove', (ev: Hammer.Input) => handle(ev));
                console.log(hammer);
            }

            function handleDragBlockEvent(e: Hammer.Input): void {
                console.log(e);
                locationX = e.deltaX;
                locationY = e.deltaY;
                relocate();
            }

            function relocate() {
                location.value = { 'transform': `translate(${locationX}px,${locationY}px)` };
            }

            return {
                location
            }
        }
    }
</script>

<style lang="scss">
    .line {
        width: 100px;
        height: 2px;
        background-color: black;
        cursor: ns-resize;
        margin-top:100px;
        margin-left:100px;
    }
</style>
