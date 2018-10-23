using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01.AsyncAwait
{
    public class Program
    {
        static void Main(string[] args)
        {

            Program p = new Program();
            p.getFromApi();
            Console.ReadKey();

        }
        public async Task<string> getFromApi()
        {
         var result2 = DownloadNumbersAsyc();

            HttpClient http = new HttpClient();
            var result = await http.GetAsync("https://jsonplaceholder.typicode.com/comments");


            Console.WriteLine(result.StatusCode);

            var rel2 = await result.Content.ReadAsStringAsync();
            return rel2;
                

        }

        public Task DownloadNumbersAsyc()
        {

            return Task.Factory.StartNew(() => DownloadNumbers());
             
        }
        public void DownloadNumbers()
        {
            Console.WriteLine("start");
            Thread.Sleep(5000);
            Console.WriteLine("end");
        }
    }
}
