﻿using System;

namespace OrderManagement
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
