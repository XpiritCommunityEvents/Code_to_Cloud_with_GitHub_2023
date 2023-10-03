using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.Frontend.Controllers
{
    public class LeakMemoryController : Controller
    {
        static readonly List<byte[]> memoryLeak = new();
        public IActionResult Index()
        {

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 25]; // allocate 25M
                    memoryLeak.Add(buffer);
                    Thread.Sleep(1000);
                }
            });
            return Accepted();
        }
    }
}