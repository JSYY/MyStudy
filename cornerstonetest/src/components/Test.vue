<template>
    <div class="test">
      <div>{{msg}}</div>
      <button @click="click">qweqweq</button>
    </div>
  </template>
  
  <script lang="ts">
import { ref, watch,h,render, onMounted, createVNode, getCurrentInstance, VNodeTypes } from 'vue'; 
  export default{
    name: 'Test',
    props: {
      msg: String,
      index:Number
    },
    setup(props:any){
        let ins = getCurrentInstance();


        function click(){
            let divs = document.querySelectorAll('.test');
            let div = divs[props.index as number]
            let vnode = createVNode(ins?.type as VNodeTypes,{msg:Math.random(),index:props.index+1});
            render(vnode,div as HTMLDivElement);
        }
  
      return{
        click
      }
    }
  }
  </script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped lang="scss">
  
  </style>
  