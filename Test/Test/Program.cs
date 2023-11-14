using System;
using System.Reflection.Metadata;

namespace Test // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            //client.GetAsync("").Result.EnsureSuccessStatusCode();
            Console.WriteLine("Hello World!");


            var peoples = new List<People>
            {
                new People {Id =1,Name="Khaled"},
                new People {Id =2,Name="Motaz"},
                new People {Id =2,Name="Ali"},
            };

            var cities = new Dictionary<int, string>()
            {
                 {1, "+962"},
                 {2, "+942"}
            };

           

        }
    }
}