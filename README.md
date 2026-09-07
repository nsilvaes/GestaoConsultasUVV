# Sistema de Gestão de Consultas UVV

Projeto desenvolvido para a disciplina de **Desenvolvimento Web - Back End** da Universidade Vila Velha (UVV).

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

O projeto utiliza **Entity Framework Core** com abordagem **Code First**.

A conexão com o banco de dados é configurada no arquivo `appsettings.json`.

A aplicação utiliza **SQL Server LocalDB**.

## Configuração do projeto

Após clonar o repositório, execute:

```bash
dotnet restore
```

Depois, crie ou atualize o banco de dados utilizando as migrations existentes:

```bash
dotnet ef database update
```

No Package Manager Console do Visual Studio, o comando equivalente é:

```powershell
Update-Database
```

Para executar a aplicação:

```bash
dotnet run
```

## Migrations

A migration inicial do projeto foi criada com:

```bash
dotnet ef migrations add InitialCreate
```

E aplicada através de:

```bash
dotnet ef database update
```

## Segurança

O sistema utiliza autenticação baseada em **Cookies**.

As rotas de gerenciamento de consultas são protegidas pelo atributo:

```csharp
[Authorize]
```

O pipeline da aplicação utiliza:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

A autenticação é executada antes da autorização, conforme recomendado pelo ASP.NET Core.

As senhas dos usuários não são armazenadas em texto puro, sendo protegidas através de hash.

Além disso, cada usuário possui acesso apenas às suas próprias consultas.

## Validações

Os Models e ViewModels utilizam **Data Annotations**, incluindo:

- Required
- EmailAddress
- StringLength
- Compare
- DataType

## Vídeo demonstrativo

O vídeo demonstra as principais funcionalidades do sistema, incluindo cadastro de usuário, autenticação e gerenciamento de consultas.

**Vídeo:** https://youtu.be/1iT447glp4Y

## Repositório

https://github.com/nsilvaes/GestaoConsultasUVV

## Disciplina

**Desenvolvimento Web - Back End**

Universidade Vila Velha - UVV