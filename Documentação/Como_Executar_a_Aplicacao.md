
# Documentação de Como Executar a Aplicação

## Pré-requisitos

Antes de executar a aplicação, certifique-se de ter instalado:

- [.NET SDK 8](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

## Passos para Executar a Aplicação

1. **Clone o Repositório**

   Clone o repositório do projeto para o seu ambiente local:

   ```sh
   git clone <https://github.com/MatheusMedeiros07/InvestmentPortfolioManagement.git>
   cd <NOME_DO_DIRETORIO>
   ```

2. **Restaurar Dependências**

   No diretório raiz do projeto, execute o comando para restaurar as dependências do projeto:

   ```sh
   dotnet restore
   ```

3. **Compilar a Aplicação**

   Compile a aplicação para garantir que tudo está configurado corretamente:

   ```sh
   dotnet build
   ```

4. **Executar a Aplicação**

   Execute a aplicação utilizando o comando:

   ```sh
   dotnet run
   ```

   Por padrão, a aplicação estará disponível em `http://localhost:5000` ou `https://localhost:5001`.

5. **Acessar a Documentação da API**

   Ao executar a aplicação acesse a documentação da API gerada automaticamente pelo Swagger em:

   ```
   http://localhost:5000/swagger
   ```

6. **Banco de dados e dados iniciais**

   Essa aplicação foi criada usando Entity Framework InMemory, ou seja não possui um banco de dados(SQL SERVER, MySQL, etc) ficará tudo em Memoria, ao finalizar a aplicação, os dados cadastrados não estão disponiveis novamente, sendo assim será necessário cadastrar novamente.

   Na classe SeedData.cs, tem alguns registros ficticios que coloquei para testes iniciais, caso não queira, pode comentar a chamada do método no Startup.cs.
