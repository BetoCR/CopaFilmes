import { http } from './config'

export default {
    iniciarCampeonato(filmesSelecionados) {
        return http.post('ChampionShip/Start',{
            selectedMovies: filmesSelecionados
        })
    },
    obterVencedores() {
        return http.get('ChampionShip/Winners')
    }
}