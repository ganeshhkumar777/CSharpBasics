using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Scenario
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     try
        //     {
        //         AsyncDownload().GetAwaiter().GetResult();
        //         Console.ReadLine();
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         throw;
        //     }
        // }

        static async Task<string> AsyncDownload()
        {
            HttpClient client = new HttpClient();
            //Asynchronously download the contents of a web page
            return await client.GetStringAsync("https://msdn.microsoft.com");
        }

    }
}