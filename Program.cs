using System.Threading.Tasks;

namespace Lesson7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new ConsoleHost();

            await host.Run();
        }
    }
}
