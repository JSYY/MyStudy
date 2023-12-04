<template>
    <LocalRTC :name="name"  v-if="show"></LocalRTC>
    <input  v-model="name"/>
    <button @click="enterroom">enter room</button>
</template>

<script lang="ts">
    import LocalRTC from './components/LocalRTC.vue';
    import { onMounted, onUnmounted, ref } from 'vue';

    export default{
        name: 'App',
        components: {
            LocalRTC
        },
        setup() {
            let name = ref('default');
            let show = ref(false);

            function enterroom() {
                show.value = !show.value;
            }

            return {
                name, show, enterroom
            }
        }
}
</script>

<style lang="scss">

</style>
