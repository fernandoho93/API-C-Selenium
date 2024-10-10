# Projeto de estudos de Teste de API utilizando C# e Selenium

Este projeto foi desenvolvido para realizar estudos de testes de API utilizando a biblioteca RestSharp em C#. O objetivo é facilitar a criação de testes automatizados para validar o comportamento e a funcionalidade das APIs, incluindo operações GET, POST, PUT, DELETE, HEAD, PATCH, OPTIONS e autenticação.

## Pré-requisitos

Antes de começar, verifique se você possui os seguintes pré-requisitos instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 5.0 ou superior)
- [Visual Studio Code](https://code.visualstudio.com/)
- Extensão C# para Visual Studio Code

## Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/fernandoho93/API-C-Selenium.git

2. Navegue até o diretório do projeto:

    ```bash
    cd API-C-Selenium

3. Instale as dependências necessárias:
    ```bash
    dotnet add package RestSharp

    
## Estrutura do Projeto

        /ApiTestProject
    |-- /bin
    |-- /obj
    |-- ApiTestProject.csproj
    |-- Program.cs
    ApiTestProject.sln


Program.cs: Contém a lógica principal do projeto, incluindo os testes de API.

## Executando os Testes
Para executar os testes, utilize o seguinte comando no terminal:


      dotnet run

Os resultados dos testes serão exibidos no terminal, indicando se as requisições foram bem-sucedidas e apresentando as respostas das APIs.

## Métodos Testados
Este projeto inclui testes para os seguintes métodos de requisição:

GET: Recupera recursos da API.

POST: Cria um novo recurso.

PUT: Atualiza um recurso existente.

DELETE: Deleta um recurso.

HEAD: Recupera cabeçalhos de resposta.

PATCH: Atualiza parcialmente um recurso.

OPTIONS: Recupera métodos permitidos para um recurso.

GET com Autenticação: Realiza uma requisição GET com autenticação.

## Exemplo de Código
Aqui está um exemplo básico de como realizar uma requisição GET:

    static void GetTest()
    {
        var client = new RestClient("https://jsonplaceholder.typicode.com");
        var request = new RestRequest("/posts", Method.Get);
        RestResponse response = client.Execute(request);
        Console.WriteLine(response.Content);
    }


## Contribuição
Se você deseja contribuir para este projeto, sinta-se à vontade para abrir um Pull Request ou reportar um problema.
