# Desafio Final - C#
## Esse projeto tem como objetivo o cadastro de clientes e o gerenciamento de contas desses clientes cadastrados.

Tabela de conteúdos
=================
<!--ts-->
   * [Pré-requisitos](#pré-requisitos)
   * [Rodando o script](#rodando-o-projeto)
   * [Tecnologias](#tecnologias)
   * [Endpoints](#endpoints)
<!--te-->

### Pré-requisitos
Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

### Rodando o projeto
```bash
# Clone este repositório
$ git clone https://github.com/Deidimila/DesafioFinalCSharp.git

# Comando para restaurar os pacotes
dotnet restore

# Comando para rodar o app
dotnet run

# Comando para rodar os testes
dotnet test

```
### Tecnologias
As seguintes linguagens e ferramentas foram usadas na construção do projeto:
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)

### Endpoints
O projeto possui os seguintes endpoints:

#### Customer

| Endpoint                                                             | Verb    | Description             |
|----------------------------------------------------------------------|:-------:|-------------------------|
| [/customer](https://localhost:5001/api/customer)                         | GET     | Get all customers       | 
| [/customer/{id}](https://localhost:5001/api/customer/{id})               | GET     | Get customer by id      | 
| [/customer](https://localhost:5001/api/customer)                         | POST    | Add customer            | 
| [/customer/{id}](https://localhost:5001/api/customer/{id})               | PUT     | Update customer         | 
| [/customer/{id}](https://localhost:5001/api/customer/{id})               | PATCH   | Update customer status  | 
| [/customer/{id}](https://localhost:5001/api/customer/{id})               | DELETE  | Delete customer         | 

#### Account

| Endpoint                                                             | Verb    | Description             |
|----------------------------------------------------------------------|:-------:|-------------------------|
| [/account](https://localhost:5001/api/account)                           | GET     | Get all accounts        | 
| [/account/{id}](https://localhost:5001/api/account/{id})                 | GET     | Get account by id       | 
| [/account](https://localhost:5001/api/account)                           | POST    | Add account             | 
| [/account/{id}](https://localhost:5001/api/account/{id})                 | PUT     | Update account          | 
| [/account/{id}](https://localhost:5001/api/account/{id})                 | PATCH   | Update account status   | 
| [/account/{id}](https://localhost:5001/api/account/{id})                 | DELETE  | Delete account          | 
| [/account/operation](https://localhost:5001/api/account/operation)   | POST    | Create operation      |
| [/account/operation](https://localhost:5001/api/account/operation)   | GET     | List operations       |

