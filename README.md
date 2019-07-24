PROJETO CAMPEONATO DE FILMES

Tecnologias utilizadas:
	Back-end
		DotNet Core 2.1
		C#
		Asp.Net Core WebApi
	Front-end
		SPA com Vue Cli


	A camada de back-end foi criada a partir de um projeto .net core utilizando o visual studio 2017.
	Foram criados 3 testes para garantir as regras do campeonato.

	APIs:
		Api/Filmes 			- Retorna todos os filmes
		Api/ChampionShip/Start 		- Inicia um campeonato
		Api/ChampionShip/Winners 	- Retorna o Vencedor e o Vice

	Diretório: CopaFilmes


	O front-end foi criado com o vscode utilizando vue cli, axios e VueRouter.
	O layout foi criado utilizando o bootstrap e com um pouco de css próprio.
	A baseUrl para requisições com o backend está sendo apontado para o seguinte endereço: https://localhost:44330/api/ localizado no arquivo config.js

	Diretório: CopaFilmes_UI
	
