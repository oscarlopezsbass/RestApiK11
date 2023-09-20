using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;


namespace TaskConsole
{
    internal class Program
    {
        private static int page = 1;
       
        static void Main(string[] args)
        {
         
            Timer timer = new Timer(GetUsersApiAsync, null, 0, 20000);
            Console.WriteLine("Presiona Enter para salir");
            Console.ReadLine();
        }

        private static async void GetUsersApiAsync(object state) {

            Console.WriteLine("Consultar API");
            using (HttpClient client = new HttpClient()) {
               string urlApi = $"{ConfigurationSettings.AppSettings.Get("urlAPI")}users?page={page}";
              
                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlApi);

                    if (response.IsSuccessStatusCode)
                    {
                        ResponseData responseData = new ResponseData();
                        responseData = JsonSerializer.Deserialize<ResponseData>(await response.Content.ReadAsStringAsync());

                        if (responseData.data.Count > 0) {
                            page++;
                            SetUsers(responseData.data);
                        }
                    
                        
                    }
                    else
                    {
                        Console.WriteLine($"GET no data availble: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            


        }
        private static async void SetUsers(List<User> users)
        {

            
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    foreach (var user in users)
                    {
                        var newUser = new
                        {
                            first_name = user.first_name,
                            last_name = user.last_name,
                            email = user.email,
                            avatar = user.avatar
                        };

                        var jsonString = JsonSerializer.Serialize(newUser);
                        HttpContent content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync("https://localhost:7183/api/User", content);

                        if (response.IsSuccessStatusCode)
                        {
                            ResponseData responseData = new ResponseData();
                            responseData = JsonSerializer.Deserialize<ResponseData>(await response.Content.ReadAsStringAsync());

                            if (response.IsSuccessStatusCode)
                            {
                                
                                string responseContent = await response.Content.ReadAsStringAsync();

                                Console.WriteLine("POST request was successful.");
                                Console.WriteLine("Response content:");
                                Console.WriteLine(responseContent);
                            }
                            else
                            {
                                Console.WriteLine($"POST request failed with status code: {response.StatusCode}");
                            }
                        }

                    }                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }



        }
        public class ResponseData {
         public int page { get; set; }
         public List<User> data { get; set; }
        }

        public class User
        {
            public int id { get; set; } 
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string avatar { get; set; }

        }
    }
}
