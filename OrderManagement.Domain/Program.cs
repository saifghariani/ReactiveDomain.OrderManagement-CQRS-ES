using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new ApplicationService();
            app.Bootstrap();
            app.Run();
            Console.ReadKey();
        }
    }
}
