# INTRODUÇÃO

Sistema de pedidos.

# ARQUITETURA

# Informações do Sistema

- Cada microsserviço é isolado, têm o seu próprio banco de dados.
- Arquitetura das APIs seguia a definição da [Onion Architecture](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/) de Jeffrey Palermo. 

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

## Modelagem

- [C4 model](https://c4model.com/): notação para desenho da arquitetura de sistemas.
- [Mermaid](https://mermaid.live/): Ferramenta de diagramação e gráficos, baseado em código.
- [Exemplo Trigger Auditoria](https://www.mysqltutorial.org/mysql-triggers/mysql-after-update-trigger/)