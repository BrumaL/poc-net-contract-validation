using PocContractValidation.Consumer.Server.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocNetPactConsumer.Server
{
    class Program
    {
        public static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var mockedOrderLockedJsonString = File.ReadAllText($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}PocContractValidation.Consumer.Tests{Path.DirectorySeparatorChar}contract-validation/myorder/order_locked_1.mock.json");
            var mockedOrderLockedEvent = JsonSerializer.Deserialize<OrderLockedEvent>(mockedOrderLockedJsonString);
            Console.Write(mockedOrderLockedEvent);
        }
    }
}
