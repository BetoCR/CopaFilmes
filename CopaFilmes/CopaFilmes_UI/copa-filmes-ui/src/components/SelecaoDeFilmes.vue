<template>
  <div>
    <div class="row">
      <div class="col-sm-12 pg_header">
        <h5 class="title">CAMPEONATO DE FILMES</h5>
        <h1>Fase de Seleção</h1>
        <p>__</p>Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.
      </div>
    </div>
    <div id="dv-error-message" style="display:none" class="row">
      <div class="col-sm-12 error-message form-group">{{errorMessage}}</div>
    </div>
    <div class="row">
      <div class="col-sm-9 descr">
        <p>Selecionados {{filmesSelecionados.length}} de 8 filmes</p>        
      </div>
      <div class="col-sm-3 form-group" style="text-align:right">
        <button :disabled="filmesSelecionados.length!=8" @click="iniciarCampeonato()" class="btn btn-success">GERAR MEU CAMPEONATO</button>
      </div>
    </div>
    <div class="row">
      <div v-for="filme in filmes" :key="filme.id" class="col-sm-3 filme">
        <div class="row">
          <div class="col-sm-2 filme-select form-group">
            <input
              :id="filme.id"
              :value="filme.id"
              v-model="filmesSelecionados"
              :disabled="filmesSelecionados.length > 7 && filmesSelecionados.indexOf(filme.id) === -1"
              class="filme-check"
              type="checkbox"
            />
          </div>
          <div class="col-sm-10 filme-titulo form-group">
            <label :for="filme.id">{{filme.titulo}}</label>
            <p class="filme-ano">{{filme.ano}}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Filme from "../services/filmes";
import Campeonato from "../services/campeonato";
import jQuery from "jquery";

export default {
  name: "SelecaoDeFilmes",
  data() {
    return {
      filmes: [],
      filmesSelecionados: [],
      errorMessage: ""
    };
  },
  methods: {
    iniciarCampeonato() {
      Campeonato.iniciarCampeonato(this.filmesSelecionados)
        .then(() => {
          this.$router.push({ name: "Vencedores" });
        })
        .catch(error => {
          this.errorMessage = error.response.data;
          jQuery("#dv-error-message").hide().show(500);
        });
    }
  },
  mounted() {
    Filme.listar().then(response => {
      this.filmes = response.data;
    });
  }
};
</script>

<style>
p {
  margin: 0px;
}
.title {
  color: #dddddd;
}
h1 {
  padding: 0px;
  margin: 0px;
}
.descr {
  font-size: 20px;
}
.filme {
  background-color: orange;
  min-height: 80px;
  border: solid gray 3px;
}
.filme-select {
  margin-top: 20px;
}
.filme-titulo {
  margin-top: 20px;
  color: black;
  font-weight: bolder;
}
.filme-ano {
  color: gray;
}
.filme-check {
  /* Double-sized Checkboxes */
  -ms-transform: scale(2); /* IE */
  -moz-transform: scale(2); /* FF */
  -webkit-transform: scale(2); /* Safari and Chrome */
  -o-transform: scale(2); /* Opera */
}
.hide {
  display: none;
}
</style>

