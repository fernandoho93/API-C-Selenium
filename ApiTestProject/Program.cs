using RestSharp;
using System;

namespace ApiTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Estudos de teste de API com c# e Selenium
            // Comente as funções que não serão utilizadas

            GetTest();
            PostTest();
            PutTest();
            DeleteTest();
            HeadTest();
            GetWithQueryTest();
            //PatchTest();
            //OptionsTest();
            //GetWithAuthtenticationTest();    
        }

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
            var request = new RestRequest("/posts/100", Method.Put);

            request.AddJsonBody(new
            {
                id = 10, 
                title = "updated title",
                body = "updated body",
                userId = 100
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
        
        static void DeleteTest(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1000", Method.Delete);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Recurso deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao deletar recurso: " + response.StatusDescription);
            }
        }

        static void HeadTest(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts", Method.Head);
            RestResponse response = client.Execute(request);

            foreach (var header in response.Headers)
            {
                Console.WriteLine($"{header.Name}: {header.Value}");
            }
            
            if (response.IsSuccessful)
            {
                Console.WriteLine("Requisição Head bem sucedida!");
            }
            else
            {
                Console.WriteLine("Erro na requisição Head: " + response.StatusDescription);
            }
        }    
        static void GetWithQueryTest(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts", Method.Get);
            request.AddParameter("userId", 1);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Requisição GET com parâmetros bem-sucedida!");
            }
            else
            {
                Console.WriteLine("Erro na requisição GET com parâmetros: " + response.StatusDescription);
            }
        }    
    }
}
