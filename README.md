# Atividade Fiap .NET - Instruções de Execução

## Requisitos

- **Visual Studio Community**
- **Docker Desktop** instalado e aberto

## Executando o Projeto no Visual Studio

1. Abra o projeto no **Visual Studio Community**.
2. Selecione o arquivo `Program.cs` no editor, que está nessa rota '.\Fiap.Atividade\Fiap.Atividade\Program.cs'. 
3. No topo da janela do Visual Studio, clique no botão **verde** de "Rodar" ou pressione `F5`. Assim que alguma dessas ações for realizada, o projeto estará rodando diretamente no ambiente de desenvolvimento.

## Executando o Projeto com Docker

O projeto também pode ser executado através do Docker, usando o `docker-compose`.

### Passos: 

1. Confira se o **Docker** está instalado e está aberto.
2. No diretório '.\Fiap.Atividade\Fiap.Atividade\' do projeto, onde tem o arquivo `docker-compose.yml`, abra o terminal, e rode o seguinte comando:

   ``` docker-compose up --build ```

	Este comando vai realizar essas ações:

	- **`--build`**: Gera a imagem Docker necessária para o projeto, caso não exista ainda.
	- **`docker-compose up`**: Sobe os contêineres necessários e inicializa a aplicação.

3. Após isso, a aplicação estará disponível no endereço especificado no arquivo `docker-compose.yml` (por exemplo, `http://localhost:5000`, dependendo da configuração).
4. Para parar a execução dos contêineres, é só usar o comando: 

	``` docker-compose down ```

