<template>
    <div class="line"></div>
</template>

<script lang="ts">
    import { onMounted } from "vue";
    import * as Hammer from 'hammerjs';

    export default {
        setup() {
            var dragBlockElements: any;

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
                //hammer.on('panend', (ev: Hammer.Input) => { completeAction(actionType); });
                console.log(hammer);
            }

            function handleDragBlockEvent(e: Hammer.Input): void {
                console.log(e);
            }


            return {

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
