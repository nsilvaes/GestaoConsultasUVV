# Sistema de Gestão de Consultas UVV

Projeto desenvolvido para a disciplina de Desenvolvimento Web Back-End.

## Objetivo

Desenvolver uma aplicação Web utilizando C# e ASP.NET Core MVC para gerenciamento de usuários e consultas, aplicando conceitos de arquitetura MVC, Entity Framework Core, persistência de dados, autenticação, autorização e validação.

## Tecnologias utilizadas

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap
- HTML
- CSS

## Arquitetura

O projeto utiliza o padrão MVC, separando a aplicação em:

- Models
- Views
- Controllers
- Data
- ViewModels

## Funcionalidades

- Cadastro de usuários
- Login
- Logout
- Cadastro de consultas
- Listagem de consultas
- Edição de consultas
- Exclusão de consultas
- Proteção de rotas autenticadas
- Validação de dados com Data Annotations
- Relacionamento entre usuário e consultas

## Banco de Dados

O projeto utiliza Entity Framework Core com abordagem Code First.

A conexão é configurada no arquivo:

appsettings.json

A aplicação utiliza SQL Server LocalDB.

## Configuração do projeto

Após clonar o repositório, execute:

```bash
dotnet restore