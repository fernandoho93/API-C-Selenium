using RestSharp;
using System;

namespace ApiTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Descomente a função que deseja executar
            GetTest();
            //PostTest();
            //PutTest();
            // DeleteTest();
            // HeadTest();
            // GetWithQueryTest();
        }

        /// <summary>
        /// Exemplo de como fazer um GET para pegar todos os posts
        /// </summary>
        static void GetTest()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        static void PostTest()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts", Method.Post);
            request.AddJsonBody(new
            {
                title = "foo",
                body = "bar",
                userId = 1
            });

            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Recurso criado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao criar recurso: " + response.StatusDescription);
            }
        }

        static void PutTest(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Put);

            request.AddJsonBody(new
            {
                id = 1, 
                title = "updated title",
                body = "updated body",
                userId = 1
            });

            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Recurso atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao atualizar recurso: " + response.StatusDescription);
            }
        }
        // Adicione as outras funções aqui...
    }
}
