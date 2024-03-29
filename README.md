- [INTRODUÇÃO](#introdução)
- [A FAZER](#a-fazer)
- [ARQUITETURA](#arquitetura)
- [Desenho](#desenho)
  - [Informações do Sistema](#informações-do-sistema)
  - [Camadas](#camadas)
    - [Domain](#domain)
    - [Application](#application)
    - [Infrastructure](#infrastructure)
    - [Presentation](#presentation)
- [COMO EXECUTAR O PROJETO](#como-executar-o-projeto)
- [REFERÊNCIAS](#referências)
  - [Versionamento](#versionamento)
  - [Modelagem](#modelagem)

# INTRODUÇÃO

Sistema de controle de estoque.

# A FAZER

Este projeto está em desenvolvimento. As seguintes tarefas precisam ser feitas para a conclusão.

- Validações de negócio na API Products e testes de unidade.
- Publicação de eventos de atualização de produtos no RabbitMQ.
- Implementação do microsserviço Stock Alert: consumir fila do RabbitMQ e disparar e-mail para o Gestor de Produtos através do SendGrid, caso o estoque esteja abaixo do configurado no alerta.
- Implementação do API Gateway.

# ARQUITETURA

# Desenho

![Desenho da Arquitetura](./docs/assets/images/desenho-arquitetura.png)

## Informações do Sistema

- Cada microsserviço é isolado, têm o seu próprio banco de dados.
- Arquitetura das APIs seguia a definição da [Onion Architecture](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/) de Jeffrey Palermo.
    - As camadas foram separadas em projetos (`.csproj`) diferentes, para que as dependências pudessem ficar isoladas por contexto.

## Camadas

### Domain

Camada que inclui os objetos de negócio e suas regras, é a principal camada da aplicação.

### Application

A camada Application aplica o fluxo de regras que a sua aplicação precisa para trabalhar. Isso não são necessariamente regras de negócio; mas regras comportamentais do fluxo que a aplicação vai trabalhar.

Por exemplo, podemos criar um *application service* para orquestrar um fluxo de cadastro de cliente onde: primeiro salva uma entidade em um repositório; em seguida, escreve um log; publica uma mensagem em uma fila para que outros sistemas saibam do cadastro dessa nova entidade; e, por último, envia um e-mail confirmando o cadastro.

### Infrastructure

Fornece recursos técnicos para as demais camadas, principalmente usando bibliotecas de terceiros (3rd-party libraries).

### Presentation

Contém a lógica de apresentação e interação com o usuário. Usa a camada Application para atender as solicitações do cliente.

# COMO EXECUTAR O PROJETO

- Na pasta `/src` execute o comando para fazer o *build* do Docker Compose.

```shell
docker-compose build
```

- Ainda na pasta `/src`, ultilize o comando a seguir para executar o container.

```shell
docker-compose -p commerce-container up
```


# REFERÊNCIAS

## Versionamento

- [Conventional Commits](https://www.conventionalcommits.org/pt-br/v1.0.0-beta.4/): padronização dos *commits*.

## Modelagem

- [C4 model](https://c4model.com/): notação para desenho da arquitetura de sistemas.
- [Mermaid](https://mermaid.live/): Ferramenta de diagramação e gráficos, baseado em código.
- [Exemplo Trigger Auditoria](https://www.mysqltutorial.org/mysql-triggers/mysql-after-update-trigger/)