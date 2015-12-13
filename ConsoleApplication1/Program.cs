using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");
            WfcService1.Service1Client client = new WfcService1.Service1Client();
            Console.WriteLine(client.GetData(4));
            client.Close();
            Console.ReadKey();
        }
    }
}
