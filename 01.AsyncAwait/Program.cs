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
            p.getFromApi().Wait();
            Console.ReadKey();

        }
        public async Task<string> getFromApi()
        {
            var result2 = DownloadNumbersAsyc2();

            var result1 = DownloadNumbersAsyc();
            HttpClient http = new HttpClient();
            var result = await http.GetAsync("https://jsonplaceholder.typicode.com/comments");


            Console.WriteLine(result.StatusCode);

            var rel2 = await result.Content.ReadAsStringAsync();
            Console.WriteLine(result2.Status);
            Console.WriteLine(result1.Status);
            result2.Wait();
            result1.Wait();
            Console.WriteLine(result2.Status);
            Console.WriteLine(result1.Status);
            return rel2;
                

        }

        public Task DownloadNumbersAsyc()
        {

            return Task.Factory.StartNew(() => DownloadNumbers());
             
        }
        public Task DownloadNumbersAsyc2()
        {

            return Task.Factory.StartNew(() => DownloadNumbers2());

        }
        public void DownloadNumbers()
        {
            Console.WriteLine("start DownloadNumbers");
            Thread.Sleep(5000);
            Console.WriteLine("end DownloadNumbers");
        }

        public void DownloadNumbers2()
        {
            Console.WriteLine("start DownloadNumbers2");
            Task.Delay(10000);

            Console.WriteLine("end DownloadNumbers2");
        }
    }
}
