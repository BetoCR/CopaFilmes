import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App.vue'
import SelecaoDeFilmes from './components/SelecaoDeFilmes'
import Vencedores from './components/Vencedores'




Vue.config.productionTip = false

Vue.use(VueRouter)

const router = new VueRouter({
    routes: [
          {
              path: "/",
              redirect: {
                  name: "SelecaoDeFilmes"
              }
          },
          {
              path: '/selecaodefilmes',
              name: 'SelecaoDeFilmes',
              component: SelecaoDeFilmes
          },
          {
              path: '/vencedores',
              name: 'Vencedores',
              component: Vencedores
          }
      ]
  }
)

new Vue({
  render: h => h(App),
  router,
  components: { App }
}).$mount('#app')

