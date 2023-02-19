<template>
    <div class="main">
        <div class="test">this is a test</div>
        <div class="image-test"></div>
    </div>
    
</template>

<script lang="js">
    export default {

    }
</script>

<style lang="css" scoped>
    .main{
        width:100%;
        height:100%;
        background-color:antiquewhite;
        display:flex;
        flex-direction:column;
    }
    .test{
        width:200px;
        height:200px;
        background-color:blue;
    }
    .image-test{
        height:1000px;
        background:url(../public/catImage.jpg);
    }
</style>