# Atividade Fiap .NET - Instru��es de Execu��o

## Requisitos

- **Visual Studio Community**
- **Docker Desktop** instalado e aberto

## Executando o Projeto no Visual Studio

1. Abra o projeto no **Visual Studio Community**.
2. Selecione o arquivo `Program.cs` no editor, que est� nessa rota '.\Fiap.Atividade\Fiap.Atividade\Program.cs'. 
3. No topo da janela do Visual Studio, clique no bot�o **verde** de "Rodar" ou pressione `F5`. Assim que alguma dessas a��es for realizada, o projeto estar� rodando diretamente no ambiente de desenvolvimento.

## Executando o Projeto com Docker

O projeto tamb�m pode ser executado atrav�s do Docker, usando o `docker-compose`.

### Passos: 

1. Confira se o **Docker** est� instalado e est� aberto.
2. No diret�rio '.\Fiap.Atividade\Fiap.Atividade\' do projeto, onde tem o arquivo `docker-compose.yml`, abra o terminal, e rode o seguinte comando:

   ``` docker-compose up --build ```

	Este comando vai realizar essas a��es:

	- **`--build`**: Gera a imagem Docker necess�ria para o projeto, caso n�o exista ainda.
	- **`docker-compose up`**: Sobe os cont�ineres necess�rios e inicializa a aplica��o.

3. Ap�s isso, a aplica��o estar� dispon�vel no endere�o especificado no arquivo `docker-compose.yml` (por exemplo, `http://localhost:5000`, dependendo da configura��o).
4. Para parar a execu��o dos cont�ineres, � s� usar o comando: 

	``` docker-compose down ```

