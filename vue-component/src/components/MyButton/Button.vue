<template>
    <button class="mybutton">{{name}}</button>
</template>

<script lang="ts">
    import { defineComponent, onMounted } from 'vue';

export default defineComponent({
    name: 'HelloWorld',
    props: {
        name: String
    },
    setup(props: any) {
        
        onMounted(() => {
            console.log(props.name);
            console.log("button init");
        });
    }
});</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="less">
   .mybutton{
       width:100px;
       height:30px;
   }
</style>
