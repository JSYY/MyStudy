<template>
    <div class="main">
        <h1 style="color:red">{{ name }}</h1>
        <MyButton :name="'Test Button'"></MyButton>
    </div>
   
</template>


<script lang="ts">

    import { defineComponent } from "vue";
    import { MyButton } from '../node_modules/my-component';

    export default defineComponent({
        components: {
            MyButton
        },
        setup() {
            const name = "123";

            return {
                name,
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
