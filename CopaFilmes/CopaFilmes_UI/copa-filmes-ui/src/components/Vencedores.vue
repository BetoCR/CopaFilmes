<template>
  <div>
    <div class="row">
      <div class="col-sm-12 pg_header">
        <h5 class="title">CAMPEONATO DE FILMES</h5>
        <h1>Resultado Final</h1>
        <p>__</p>Veja o resultado final do Campeonato de filmes de forma simples e rápida
      </div>
    </div>
    <div id="dv-error-message" style="display:none" class="row">
      <div class="col-sm-12 error-message form-group">{{errorMessage}}</div>
    </div>
    <div v-if="winners.winner" class="row">
      <div class="col-sm-1 posicao-vencedor">
        <h1>1º</h1>
      </div>
      <div class="col-sm-11 titulo-vencedor">
        <h2>{{winners.winner}}</h2>
      </div>
    </div>
    <div v-if="winners.vice" class="row">
      <div class="col-sm-1 posicao-vencedor">
        <h1>2º</h1>
      </div>
      <div class="col-sm-11 titulo-vencedor">
        <h2>{{winners.vice}}</h2>
      </div>
    </div>
  </div>
</template>

<script>

import jQuery from "jquery";
import Campeonato from "../services/campeonato";

export default {
  name: "Vencedores",
  data() {
    return {
      winners: {},
      errorMessage:''
    };
  },
  mounted() {
    Campeonato.obterVencedores()
    .then(response => {
      this.winners = response.data;
    })
    .catch(error => {
          this.errorMessage = error.response.data;
          jQuery("#dv-error-message").hide().show(500);
        });
  }
};
</script>

<style>
.posicao-vencedor {
  text-align: center;
  background-color: blueviolet;
  border: solid 3px gray
}
.titulo-vencedor {
  background-color: white;
  color: black;
  border: solid 3px gray
}
</style>

