<template>
  <div class="button-group">
    <input v-model="filePath" />
    <button @click="load(0)">loadByWADOUri</button>
    <button @click="load(1)">loadByHttpRequest</button>
    <button @click="dispose">Dispose</button>
  </div>

  <div id="dicomImage"></div>
</template>

<script lang="ts" src="./Test.ts">

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
#dicomImage{
  width: 600px;
  height: 800px;
}

.button-group{
  display: flex;
  flex-direction: row;
}

button{
  margin-left: 10px;
}
</style>
