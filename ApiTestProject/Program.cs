using RestSharp;
using System;

namespace ApiTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Estudos de teste de API com c# e Selenium

            //GetTest();
            //PostTest();
            //PutTest();
            //DeleteTest();
            //HeadTest();
            //GetWithQueryTest();
            //PatchTest();
            //OptionsTest();
            //GetWithAuthtenticationTest();   
            //PostTestWithInvalidData(); 
            //PutTestWithInvalidId();
            //DeleteTestWithInvalidId();
            OptionsTestForMultipleEndpoints();
                //GetTestWithCustomHeaders();
                //GetWithMultipleQueryParameters();
                //GetWithInvalidAuthenticationTest();
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
    
        static void PatchTest(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Patch);

            request.AddJsonBody(new
            {
                title = "patched title"   
            });  

            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Requisição PATCH bem sucedida!");
            }       
            else
            {
                Console.WriteLine("Erro na requisição PATCH: " + response.StatusDescription); 
            }  
        }

        

        static void OptionsTest(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts", Method.Options);    

            RestResponse response = client.Execute(request);

            Console.WriteLine("Allowed Methods: " + response.Headers.FirstOrDefault(x => x.Name == "Allow")?.Value);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Requisição OPTIONS bem sucedida!");
            }
            else
            {
                Console.WriteLine("Erro na requisição OPTIONS: " + response.StatusDescription);
            }
        }    

        static void GetWithAuthtenticationTest(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Get);

            //add token de aut
            request.AddHeader("Authorization", "Bearer your_token_here");

            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Requisição GET com autenticação bem-sucedida!");
            }
            else
            {
                Console.WriteLine("Erro na requisição GET com autentição: " + response.StatusDescription);  
            }
        }

        static void PostTestWithInvalidData(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts", Method.Post);   

            request.AddJsonBody(new
            {
                title = " ", //invalid title
                body = "bar",
                userId = 1
            });

            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Requisição POST com dados inválidos rejeitada com sucesso: " + response.StatusDescription);
            }
        }

        static void PutTestWithInvalidId(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/99999999", Method.Put); // esse ID não existe

            request.AddJsonBody(new
            {
                id = 99999, 
                title = "updated title",
                body = "updated body",
                userId = 100
            });

            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("Requisição PUT com ID Inexistente foi rejeitada: " + response.StatusDescription);
            }
        }

        static void DeleteTestWithInvalidId(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/99999999", Method.Delete); //esse ID não existe

            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful) 
            {
                Console.WriteLine("Requisição DELETE com ID Inexistente foi rejeitada: " + response.StatusDescription);
            }
        }

        static void OptionsTestForMultipleEndpoints(){
            var client = new RestClient("https://jsonplaceholder.typicode.com");

            // Lista de endpoints para testar
            var endpoints = new List<string> { "/posts", "/comments", "/albums", "/photos", "/todos", "/users" };

            foreach (var endpoint in endpoints)
            {	
                Console.WriteLine("Testando OPTIONS para o endpoint: {endpoint}");

                var request = new RestRequest(endpoint, Method.Options);
                RestResponse response = client.Execute(request);

                if (response.Headers != null)
                {
                    var allowHeader = response.Headers.FirstOrDefault(x => x.Name == "Allow")?.Value;
                    Console.WriteLine("Metodos permitidos: " + allowHeader);
                }
                else
                {
                    Console.WriteLine("Erro: Os headers de resposta não foram encontrados.");
                }

                if (response.IsSuccessful) 
                {
                    Console.WriteLine("Requisição OPTIONS para o endpoint {endpoint} foi bem-sucedida: " + response.StatusDescription);
                }
                else
                {
                    Console.WriteLine("Requisição OPTIONS para o endpoint {endpoint} foi rejeitada: " + response.StatusDescription);
                } 
            }
        }
    }
}
