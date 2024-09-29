<template>
  <div class="hello">
      <button @click="method">点击</button>
  </div>
</template>

<script lang="ts">
import { ref, watch,h,render, onMounted, createVNode } from 'vue';
import Test from '../components/Test.vue';

export default{
  name: 'HelloWorld',
  props: {
    
  },
  setup(){
  
    function method(){
      let div = document.querySelector('.hello');
      let vnode = createVNode(Test,{msg:'1231321',index:0});
      console.log(Test)
      render(vnode,div as HTMLDivElement);
    }

    return{
      method
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
