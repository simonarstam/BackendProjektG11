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
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            while (true)
            {
                Console.WriteLine("1. List whole TodoList");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Remove");
                Console.Write(">> ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        foreach (string s in client.getTheListString())
                        {
                            Console.WriteLine(s);
                        }
                        break;
                    case "2":
                        client.removeToDo(10);
                        break;
                    case "3":
                        //client.
                        client.addToDo();
                        break;
                    default:
                        Console.WriteLine("Invalid choice...");
                        break;
                }
            }
            //client.Close();









           // Console.ReadKey();
        }
    }
}
