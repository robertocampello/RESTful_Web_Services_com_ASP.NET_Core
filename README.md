# RESTful Web Services com ASP.NET Core
Tutorial demonstrando como implementar uma RESTful Web API com **ASP.NET Core**.

Recentemente nos últimos anos, está cada vez mais claro que HTTP não é apenas para servir páginas [HTML](https://www.w3.org/TR/html52/). É também uma poderosa plataforma para construir **Web APIs**, que expõem serviços e dados, através da utilização de diversos métodos HTTP (GET, POST, DELETE, etc) além de conceitos simples como URIs e headers. [ASP.NET Web API](https://docs.microsoft.com/en-us/aspnet/web-api/) possui um conjunto de componentes que simplificam a programação HTTP.

**REST (Representational State Transfer)** é um modelo de arquitetura que foi especificado por Roy Fielding, um dos principais criadores do protocolo HTTP em sua tese de doutorado, e foi adotado como o modelo de arquitetura a ser utilizado na evolução do protocolo HTTP.  Consiste em princípios, padões e constraints que, quando implementadas, permitem a criação de um projeto com interfaces bem definidas.

O modelo proposto por Fielding permitiu uma forma muito simples e mais próxima da nossa realidade, dando sentido às requisições HTTP, conforme exemplos:

* GET http://www.mydomain.com/users
* POST http://www.mydomain.com/users/{name:jonh}
* DELETE http://www.mydomain.com/users/{id}

Logo a comunidade percebeu que o modelo de arquitetura REST poderia ser utilizado na implementação de Web Services, com o objetivo de se integrar aplicações pela Web, e passaram a utilizá-lo como uma alternativa ao [SOAP](https://www.w3.org/TR/2000/NOTE-SOAP-20000508/).

**RESTful** é quando um determinado projeto implementa os princípios/padrÕes do REST.

[ASP.NET Web API](https://docs.microsoft.com/en-us/aspnet/web-api/) é uma framework para construir Web APIs. Neste tutorial iremos construir uma aplicação RESTful para um Cadastro de Produtos (CRUD), utilizando ASP.NET Web API. Vamos demonstrar também os princípios na implementação de uma aplicação RESTful.

## Pré-Requisitos

1. Instalar o [Visual Studio 2017](https://www.visualstudio.com/downloads/) – Pode ser o community 

## Princípios de uma aplicação RESTful

A seguir vamos apresentar os princípios do RESTful e como utilizá-los de maneira correta na sua aplicação.

### Identificação dos Recursos

Toda aplicação gerencia algumas informações. Uma aplicação de um E-commerce, por exemplo, gerencia seus produtos, clientes, vendas, etc. Essas coisas que uma aplicação gerencia são chamadas de Recursos no modelo REST.

Um recurso em uma aplicação REST é uma abstração sobre um determinado tipo de informação que uma aplicação gerencia. Entretanto, um dos princípios do REST consiste que todo recurso deve possuir um identificador único.

Sendo assim, faz-se necessário a identificação do recurso através do conceito de URI (Uniform Resource Identifier). Seguem alguns exemplos de URI's:

```html
http://apirest.com/products;
http://apirest.com/customers;
http://apirest.com/customers/01;
http://apirest.com/sales.
```

As URI’s representam a interface dos seus serviços, definindo um contrato que será utilizado pelos clientes para acessá-los. Vejamos  algumas boas práticas na definição de URI’s:

* Utilize URI's legíveis
* Evite incluir na URI a operação a ser realizada no recurso. Utilize os métodos HTTP para manipulação dos recursos conforme quadro abaixo:
  ![API Methods](images/1.png)

* Defina um padrão de URI na identificação dos recursos
* Evite incluir na URI o formato desejado da representação do recurso.
```http://apirest.com/products/xml```
```http://apirest.com/customers/10?formato=json```
