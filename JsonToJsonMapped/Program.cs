using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonToJsonMapped
{
    internal static class Program
    {
        private static async Task Main()
        {
            var stopWatch = new Stopwatch();
            
            stopWatch.Start();
            
            // Teste para um array (lista)
            var (original, mapped) = await JsonArrayToMapped();

            Console.WriteLine(new string('*', 100));
            Console.WriteLine("**** Json Array Original");
            Console.WriteLine(original);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(new string('*', 100));
            Console.WriteLine("*** Json Array Mapeado");
            Console.WriteLine(mapped);
            Console.WriteLine("***");

            stopWatch.Stop();
            
            
            Console.WriteLine("");
            Console.WriteLine(
                $"Tempo de execução: {stopWatch.Elapsed.Seconds} segundos");

            stopWatch.Restart();
            
            // Teste para um objeto
            (original, mapped) = await JsonToMapped();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(new string('*', 100));
            Console.WriteLine("**** Json Original");
            Console.WriteLine(original);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(new string('*', 100));
            Console.WriteLine("*** Json Mapeado");
            Console.WriteLine(mapped);
            Console.WriteLine("***");

            stopWatch.Stop();
            
            
            Console.WriteLine("");
            Console.WriteLine(
                $"Tempo de execução: {stopWatch.Elapsed.Seconds} segundos");
            Console.ReadKey();
        }

        private static async Task<(string, string)> JsonArrayToMapped()
        {
            using var client = new HttpClient();

            var result = await client.GetAsync(
                "https://jsonplaceholder.typicode.com/todos");

            var json = await result.Content.ReadAsAsync<JObject[]>();

            var original = JsonConvert.SerializeObject(
                json, Formatting.Indented);

            var mapped = JMap.Bind(json, new Dictionary<string, string>
            {
                {"userId", "userIdMap"},
                {"title", "titleMap"}
            });

            return (original, mapped);
        }
        
        private static async Task<(string, string)> JsonToMapped()
        {
            using var client = new HttpClient();

            var result = await client.GetAsync(
                "https://jsonplaceholder.typicode.com/todos/1");

            var json = await result.Content.ReadAsAsync<JObject>();

            var original = JsonConvert.SerializeObject(
                json, Formatting.Indented);

            var mapped = JMap.Bind(json, new Dictionary<string, string>
            {
                {"userId", "userIdMap"},
                {"title", "titleMap"}
            });

            return (original, mapped);
        }
    }
}