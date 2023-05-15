<template>
    <div class="">
        <div>{{name}}</div>
        <input class="myInput" v-model="inputVal" />
    </div>
</template>

<script lang="ts">
    import { defineComponent, onMounted, ref } from 'vue';

export default defineComponent({
    //name必填，在导出时使用的就是这个名字
    name: 'MyInput',
    props: {
        name: String
    },
    setup(props: any) {
        let inputVal = ref();
        
        onMounted(() => {
            inputVal.value = props.name;
        });

        return {
            inputVal
        }
    }
});
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="less">
    .myInput {
        width: 100px;
        height: 30px;
        background-color:@test-color;
    }
</style>
