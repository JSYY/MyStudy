<template>
  <div class="main" @mousedown="startDrag">
    <button @click="close">Close this window</button>
    <div>{{message}}</div>
    <div>{{positionX}}:{{positionY}}</div>
  </div>
</template>

<script lang="ts">
import { onMounted, ref } from 'vue';
import {DialogServices} from "../../src/utils/dialog.service";

export default{
    props:{
      message:String
    },
    setup(props:any) {
      let positionX = ref(0);
      let positionY =ref(0);

      onMounted(()=>{
        console.log(111)
      });

      function close(){
        DialogServices.RemoveDialogComponent();
      }

      function startDrag(e:any) {
            let odiv = e.target.parentNode;        //获取目标元素
            
            //算出鼠标相对元素的位置
            let disX = e.clientX - odiv.offsetLeft;
            let disY = e.clientY - odiv.offsetTop;
            document.onmousemove = (e)=>{       //鼠标按下并移动的事件
                //用鼠标的位置减去鼠标相对元素的位置，得到元素的位置
                let left = e.clientX - disX;    
                let top = e.clientY - disY;
                
                //绑定元素位置到positionX和positionY上面
                positionX.value = top;
                positionY.value = left;
                
                //移动当前元素
                odiv.style.left = left + 'px';
                odiv.style.top = top + 'px';
            };
            document.onmouseup = (e) => {
                document.onmousemove = null;
                document.onmouseup = null;
            };
      }

      return{
        close,startDrag,positionX,positionY
      }
    },
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

.main{
  width: 300px;
  height: 300px;
  background-color: darkkhaki;
  position: relative;
}

</style>
