# Investment Portfolio Management

Esta aplicação é um sistema de gestão de portfólio de investimentos desenvolvido para uma empresa de consultoria financeira. O sistema permite que os usuários da operação gerenciem os investimentos disponíveis e que os clientes comprem, vendam e acompanhem seus investimentos.

## Funcionalidades

- **Gestão de Produtos Financeiros:** Permite que a equipe de operação realize a manutenção dos produtos de investimentos.
- **Notificação por E-mail:** Disparo de e-mail diário para notificar os administradores sobre os produtos com vencimento próximo.
- **Negociação de Investimentos:** Permite que o cliente compre, venda e consulte seus investimentos.
- **Consultas e Extratos:** Funcionalidades de consulta de produtos disponíveis e extrato de investimentos.

## Documentação

A documentação completa da aplicação está disponível nos links abaixo:

- [Como Executar a Aplicação](Documentação/Como_Executar_a_Aplicacao.md)
- [Como Utilizar a Aplicação](Documentação/Como_Utilizar_a_Aplicacao.md)

## Estrutura do Projeto

- `Controllers`: Contém os controladores da API.
- `Data`: Contém a configuração do contexto do banco de dados e a classe de Seed Data.
- `Dtos`: Contém os Data Transfer Objects utilizados pela aplicação.
- `Entities`: Contém as entidades do modelo de dados.
- `Mappings`: Contém a configuração do AutoMapper.
- `Repositories`: Contém as interfaces e implementações dos repositórios.
- `Services`: Contém as interfaces e implementações dos serviços.
- `Startup.cs`: Contém a configuração de inicialização da aplicação.

## Tecnologias Utilizadas

- **Linguagem de Programação**: C#
- **Framework**: .NET 8
- **Banco de Dados**: Entity Framework Core (InMemory)
- **Mapeamento de Objetos**: AutoMapper
- **Scheduler**: Quartz
- **Envio de E-mails**: System.Net.Mail
- **Documentação da API**: Swashbuckle (Swagger)

## Como Contribuir

Para contribuir com este projeto, siga os passos abaixo:

1. Fork o repositório.
2. Crie uma branch para a sua feature (`git checkout -b feature/nome-da-feature`).
3. Commit suas mudanças (`git commit -am 'Adiciona nova feature'`).
4. Push para a branch (`git push origin feature/nome-da-feature`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
