# Backend Challenge - Pokémons

## Introdução

Este é um teste para que possamos ver as suas habilidades como Backend Developer.

Nesse teste você deverá desenvolver um projeto para listar pokémons, utilizando como base a API [https://pokeapi.co/](https://pokeapi.co/ "https://pokeapi.co/").

[SPOILER] As instruções de entrega e apresentação do teste estão no final deste Readme (=

### Antes de começar
 
- O projeto deve utilizar a Linguagem específica na avaliação. Por exempo: C#
- Considere como deadline da avaliação a partir do início do teste. Caso tenha sido convidado a realizar o teste e não seja possível concluir dentro deste período, avise a pessoa que o convidou para receber instruções sobre o que fazer.
- Documentar todo o processo de investigação para o desenvolvimento da atividade (README.md no seu repositório); os resultados destas tarefas são tão importantes do que o seu processo de pensamento e decisões à medida que as completa, por isso tente documentar e apresentar os seus hipóteses e decisões na medida do possível.

## Backend-end

- Get para 10 Pokémon aleatórios
- GetByID para 1 Pokémon específico
- Cadastro do mestre pokemon (dados básicos como nome, idade e cpf) em SQLite
- Post para informar que um Pokémon foi capturado.
- Listagem dos Pokémon já capturados.
  

### Requisitos

1 - Todos os endpoints devem retornar os dados básicos do Pokémon, suas evoluções e o base64 de sprite default de cada Pokémon.

## Readme do Repositório

- Deve conter o título do projeto
- Uma descrição sobre o projeto em frase
- Deve conter uma lista com linguagem, framework e/ou tecnologias usadas
- Como instalar e usar o projeto (instruções)
- Não esqueça o [.gitignore](https://www.toptal.com/developers/gitignore)
- Se está usando github pessoal, referencie que é um challenge by coodesh:  

>  This is a challenge by [Coodesh](https://coodesh.com/)

## Finalização e Instruções para a Apresentação

1. Adicione o link do repositório com a sua solução no teste
2. Verifique se o Readme está bom e faça o commit final em seu repositório;
3. Envie e aguarde as instruções para seguir. Caso o teste tenha apresentação de vídeo, dentro da tela de entrega será possível gravar após adicionar o link do repositório. Sucesso e boa sorte. =)


## Suporte

Para tirar dúvidas sobre o processo envie uma mensagem diretamente a um especialista no chat da plataforma. 

--------------------------------------------------------------------

# Readme desafio técnico kotas

## Introdução

Este projeto foi desenvolvido como parte de um desafio técnico, utilizando uma arquitetura baseada em Clean Architecture para exemplificar técnicas avançadas de arquitetura de software.

## Motivação

### MediatR

O MediatR foi utilizado para isolar o comportamento das queries e commands, seguindo o padrão CQRS (Command Query Responsibility Segregation). Isso facilita a injeção de dependências e mantém o código mais organizado e modular.

### Migrations do EF Core

As migrations do Entity Framework Core são executadas automaticamente para facilitar a inserção das entidades (Pokémon) e suas dependências no projeto. Isso permite que o banco de dados seja atualizado de forma incremental e controlada.

## Seed Inicial do Banco de Dados

Para o seed inicial do banco de dados SQLite, foi utilizado um JSON disponibilizado no GitHub no link [pokemon.json](https://github.com/robert-z/simple-pokemon-json-api/blob/master/data/pokemon.json). As imagens dos Pokémon também foram buscadas do mesmo repositório. Foi feita uma abordagem para extrair o base64 dessas imagens, que não estão salvas no banco de dados, pois não é aconselhável armazenar arquivos diretamente no banco. Para essa abordagem, utilizei uma pasta da infraestrutura de acordo com a Clean Architecture, mas poderia ser um S3 ou uma pasta no servidor.

## Arquitetura

A arquitetura escolhida foi a Clean Architecture. Para este projeto, pode parecer um pouco de over engineering, já que é um projeto de pequeno porte, porém foi utilizada para exemplificar minhas técnicas em arquitetura de software.

## Tecnologias Utilizadas

- .NET 8
- C# 12.0
- MediatR
- Entity Framework Core
- SQLite
- Docker
- Automapper

## Como Executar

### Executar no Visual Studio

1. Clone o repositório.
2. Abra o projeto no Visual Studio.
3. Execute o projeto pressionando `F5` ou clicando em `Iniciar`.

### Executar no Docker

1. Instale o docker desktop
1. Clone o repositório.
2. Navegue com o CMD até o diretório do projeto (KotasPokemon).
3. Execute o comando `docker build -t pokemonwebapi -f PokemonWebApi/Dockerfile .` para construir a imagem Docker.
4. Execute o comando `docker run -p 8080:8080 pokemonwebapi` para iniciar o container.

## Observações

Algumas coisas foram alteradas para uma melhor demonstração em outros ambientes fora da produção. Como o swagger foi abilitado, https, desabilitado para evitar erros de certificados, e o projeto foi redirecionado para a porta 8080.

URL do swagger (será redirecionado automaticamente para o index): http://localhost:8080/
URL da API: http://localhost:8080/

## Conclusão

Este projeto demonstra a utilização de padrões avançados de arquitetura e boas práticas de desenvolvimento, como o uso do MediatR para CQRS, EF Core para gerenciamento de banco de dados e uma abordagem modular e escalável com Clean Architecture.

