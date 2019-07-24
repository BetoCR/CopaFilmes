<template>
  <div id="app" class="container">
    <div class="row">
      <div class="col-sm-12 pg_header">
          <h5 class="title">CAMPEONATO DE FILMES</h5>
          <h1>Fase de Seleção</h1>
          <p>__</p>
          Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.
      </div>
    </div>
    <selecao-de-filmes></selecao-de-filmes>
  </div>
</template>
<script>

import SelecaoDeFilmes from './components/SelecaoDeFilmes.vue'

 export default {
        name: 'app',
          components:{
            SelecaoDeFilmes 
          }
        }
</script>
<style>

  body{
    background-color:gray;
    color:white
  }
  .pg_header{
    margin-top: 10px;
    margin-bottom:10px;
    background-color:teal;
    text-align: center;
    color:white;
    padding:50px;
  }
  
</style>


