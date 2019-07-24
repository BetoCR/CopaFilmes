<template>
  <div id="app" class="container">    
    <router-view></router-view>
  </div>
</template>
<script>


export default {
  name: "app",

};
</script>
<style>
body {
  background-color: gray;
  color: white;
}
.pg_header {
  margin-top: 10px;
  margin-bottom: 10px;
  background-color: teal;
  text-align: center;
  color: white;
  padding: 50px;
}
.error-message{
  background-color:tomato;  
  color:white;
  font-size: 20px;  
  text-align: center;
  line-height: 50px;  
}
</style>

