<template>
    <div class="main">
        <h1 style="color:red">{{ name }}</h1>
        <MyButton :name="'Test Button'" @click="func"></MyButton>
        <MyInput :name="'Test Input'"></MyInput>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from "vue";

    export default defineComponent({
        setup() {
            const name = "123";

            function func() {
                console.log("function");
            }

            return {
                name, func
            };
        },
    });
</script>

<style lang="css">
    body{
        padding:0;
        margin:0;
    }
    .main {
        width: 100%;
        height: 100%;
        background: url(../public/image/image.jpeg);
        position: absolute;
        overflow: hidden;
    }
</style>
