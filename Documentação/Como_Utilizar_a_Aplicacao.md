
# Documentação de Como Utilizar a Aplicação

## Introdução

Esta documentação fornece uma visão detalhada de como utilizar a aplicação de gestão de portfólio de investimentos. A aplicação permite gerenciar investimentos, criar, alterar e excluir produtos financeiros, bem como gerenciar clientes.

## Endpoints Disponíveis

### 1. Investimentos

#### Obter Investimentos por ID do Cliente

**Descrição**: Retorna todos os investimentos de um cliente, com a opção de filtrar por investimentos ativos ou inativos.

**URL**: `GET /api/investment/GetAllInvestmentsByCustomerId/{id}`

**Parâmetros**:
- `id` (int): ID do cliente.
- `isActive` (bool, opcional): Filtro para investimentos ativos/inativos.

**Exemplo de Requisição**:
```sh
GET /api/investment/GetAllInvestmentsByCustomerId/1?isActive=true
```

#### Criar um Novo Investimento

**Descrição**: Cria um novo investimento para um cliente.

**URL**: `POST /api/investment`

**Corpo da Requisição**:
```json
{
  "name": "Investment 3",
  "amount": 3000.00,
  "date": "2023-06-10T00:00:00",
  "customerId": 2,
  "type": "Type 3",
  "maturityDate": "2025-12-31T00:00:00",
  "interestRate": 5.0,
  "productId": 2
}
```

#### Vender um Investimento

**Descrição**: Marca um investimento como vendido, definindo o campo `IsActive` como `false`.

**URL**: `POST /api/investment/sell/{id}`

**Parâmetros**:
- `id` (int): ID do investimento.

**Exemplo de Requisição**:
```sh
POST /api/investment/sell/1
```

### 2. Produtos

#### Obter Todos os Produtos

**Descrição**: Retorna todos os produtos financeiros disponíveis.

**URL**: `GET /api/product`

**Exemplo de Requisição**:
```sh
GET /api/product
```

#### Criar um Novo Produto

**Descrição**: Cria um novo produto financeiro.

**URL**: `POST /api/product`

**Corpo da Requisição**:
```json
{
  "name": "Product C",
  "price": 150.00,
  "expirationDate": "2025-12-31T00:00:00"
}
```

#### Atualizar um Produto

**Descrição**: Atualiza os dados de um produto financeiro existente.

**URL**: `PUT /api/product/{id}`

**Parâmetros**:
- `id` (int): ID do produto a ser atualizado.

**Corpo da Requisição**:
```json
{
  "name": "Product C Updated",
  "price": 175.00,
  "expirationDate": "2025-12-31T00:00:00"
}
```

#### Excluir um Produto

**Descrição**: Exclui um produto financeiro.

**URL**: `DELETE /api/product/{id}`

**Parâmetros**:
- `id` (int): ID do produto a ser excluído.

**Exemplo de Requisição**:
```sh
DELETE /api/product/3
```

### 3. Clientes

#### Obter Todos os Clientes

**Descrição**: Retorna todos os clientes cadastrados.

**URL**: `GET /api/customer`

**Exemplo de Requisição**:
```sh
GET /api/customer
```

#### Criar um Novo Cliente

**Descrição**: Cria um novo cliente.

**URL**: `POST /api/customer`

**Corpo da Requisição**:
```json
{
  "firstName": "Alice",
  "lastName": "Brown",
  "cpf": "11122233344",
  "email": "alice.brown@example.com",
  "telefone": "555666777",
  "dataNascimento": "1992-02-02T00:00:00"
}
```

#### Atualizar um Cliente

**Descrição**: Atualiza os dados de um cliente existente.

**URL**: `PUT /api/customer/{id}`

**Parâmetros**:
- `id` (int): ID do cliente a ser atualizado.

**Corpo da Requisição**:
```json
{
  "firstName": "Alice Updated",
  "lastName": "Brown Updated",
  "cpf": "11122233344",
  "email": "alice.brown@example.com",
  "telefone": "555666777",
  "dataNascimento": "1992-02-02T00:00:00",
  "active": true
}
```

#### Excluir um Cliente

**Descrição**: Exclui um cliente.

**URL**: `DELETE /api/customer/{id}`

**Parâmetros**:
- `id` (int): ID do cliente a ser excluído.

**Exemplo de Requisição**:
```sh
DELETE /api/customer/3
```

## Serviço de E-mail

O serviço de e-mail é responsável por enviar notificações diárias aos administradores sobre os produtos com vencimento próximo. Ele é configurado para ser executado a cada 5 minutos.

### Configuração do Serviço de E-mail

O serviço de e-mail é configurado no arquivo `appsettings.json`:

```json
"EmailSettings": {
  "SmtpServer": "smtp.example.com",
  "SmtpPort": 587,
  "SmtpUsername": "your-email@example.com",
  "SmtpPassword": "your-email-password",
  "FromEmail": "your-email@example.com"
}
```


### Exemplo de Configuração

No `Startup.cs`, o serviço de e-mail é configurado da seguinte forma:

```csharp
services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
services.AddTransient<IEmailService, EmailService>();
```

O job de notificação por e-mail é configurado utilizando Quartz.NET:

```csharp
services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();

    var jobKey = new JobKey("EmailNotificationJob");
    q.AddJob<EmailNotificationJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("EmailNotificationJob-trigger")
        .WithCronSchedule("0 */5 * * * ?")); // Executa a cada 5 minutos
});

services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
```

### Explicação da Cron Job

A cron job configurada acima utiliza uma expressão cron para definir a frequência de execução do job de notificação por e-mail. A expressão cron `0 */5 * * * ?` pode ser lida da seguinte maneira:

- `0`: Segundo (sempre no segundo zero).
- `*/5`: Minuto (a cada 5 minutos).
- `*`: Hora (qualquer hora).
- `*`: Dia do mês (qualquer dia).
- `*`: Mês (qualquer mês).
- `?`: Dia da semana (ignorado).

Ou seja, a expressão `0 */5 * * * ?` indica que o job deve ser executado a cada 5 minutos.

### Exemplo para Executar a Cada 1 Minuto

Para configurar o job para ser executado a cada 1 minuto, você deve usar a seguinte expressão cron:

```csharp
.WithCronSchedule("0 * * * * ?")
```

Explicação:
- `0`: Segundo (sempre no segundo zero).
- `*`: Minuto (a cada minuto).
- `*`: Hora (qualquer hora).
- `*`: Dia do mês (qualquer dia).
- `*`: Mês (qualquer mês).
- `?`: Dia da semana (ignorado).

### Exemplo para Executar a Cada 24 Horas

Para configurar o job para ser executado a cada 24 horas, você deve usar a seguinte expressão cron:

```csharp
.WithCronSchedule("0 0 0 * * ?")
```

Explicação:
- `0`: Segundo (sempre no segundo zero).
- `0`: Minuto (sempre no minuto zero).
- `0`: Hora (meia-noite).
- `*`: Dia do mês (qualquer dia).
- `*`: Mês (qualquer mês).
- `?`: Dia da semana (ignorado).

Com essas configurações, você pode ajustar a frequência de execução do job de notificação por e-mail conforme necessário.


## Erros Comuns

- **400 Bad Request**: Quando há um erro de validação nos dados da requisição.
- **404 Not Found**: Quando um recurso solicitado não é encontrado.
- **500 Internal Server Error**: Quando ocorre um erro inesperado no servidor.

## Conclusão

Esta documentação fornece uma visão geral de como executar e utilizar a aplicação de gestão de portfólio de investimentos. A aplicação permite gerenciar investimentos, criar novos investimentos, vender investimentos existentes, além de gerenciar produtos financeiros e clientes. A documentação da API gerada pelo Swagger está disponível para ajudar na exploração e teste dos endpoints disponíveis.
