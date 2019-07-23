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
    <div class="row">
      <div class="col-sm-9 descr">
        <p>Selecionados</p>
        <p> {{filmesSelecionados.length}} de 8 filmes</p>
      </div>
      <div class="col-sm-3">
          <button @click="iniciarCampeonato()" class="btn btn-info">GERAR MEU CAMPEONATO</button>
      </div>
    </div>
    <div v-if="errorMessage" class="row">
      <div class="col-sm-12">
        <div class="alert alert-danger" role="alert">{{errorMessage}}</div>
      </div>
    </div>
    <div class="row">
      <div v-for="filme in filmes" :key="filme.id" class="col-sm-3 filme">
        <div class="row">
          <div class="col-sm-2 filme-select form-group">
            <input :value="filme.id"
              v-model="filmesSelecionados" 
              :disabled="filmesSelecionados.length > 7 && filmesSelecionados.indexOf(filme.id) === -1"
              class="filme-check" 
              type="checkbox"/>
          </div>
          <div class="col-sm-10 filme-titulo form-group">
            {{filme.titulo}}
            <p class="filme-ano">{{filme.ano}}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>

import Filme from './services/filmes'
import Campeonato from './services/campeonato'
import Router from 'vue-router'

export default {
  name: 'app',
  data(){
    return {
      filmes:[],
      filmesSelecionados:[],
      errorMessage:''
    }
  },
  methods:{
    iniciarCampeonato : function(){
      var self = this;
        Campeonato
          .iniciarCampeonato(this.filmesSelecionados)
          .then(response  =>  {
            alert("foi")
          }).catch(
            function(error){
                self.errorMessage = error.response.data
            }
          )
    }
  },
  mounted(){
      Filme.listar().then(response => {
        this.filmes = response.data
      })
  }
}
</script>

<style>
body{
  background-color:gray;
  color:white
}
p{
  margin:0px;
}
.title{
  color:#DDDDDD;
}
h1{
  padding:0px;
  margin:0px;
}
.pg_header{
  margin-top: 10px;
  margin-bottom:10px;
  background-color:teal;
  text-align: center;
  color:white;
  padding:50px;
}
.descr{
  font-size:20px
}
.filme{
  background-color:orange;
  min-height: 80px;
  border: solid gray 3px;
}

.filme-select{
  margin-top:20px;
}
.filme-titulo{
  margin-top:20px;
  color:black;
  font-weight:bolder;
}
.filme-ano{
  color:gray;
}
.filme-check
{
  /* Double-sized Checkboxes */
  -ms-transform: scale(2); /* IE */
  -moz-transform: scale(2); /* FF */
  -webkit-transform: scale(2); /* Safari and Chrome */
  -o-transform: scale(2); /* Opera */
}
</style>
