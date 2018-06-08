using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese opcion:");
            Console.WriteLine("1 -> ChangeString");
            Console.WriteLine("2 -> OrderRange");
            Console.WriteLine("3 -> MoneyPart");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Opcion: ");
            var opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1":
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("1:  ChangeString");
                    Console.Write("Input: ");
                    ChangeString changeString = new ChangeString();
                    var cadenaResultado = changeString.Build(Console.ReadLine());
                    Console.WriteLine(string.Format("Resultado: {0}", cadenaResultado));
                    Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("2:  OrderRange");
                    Console.Write("Input: ");
                    OrderRange orderRange = new OrderRange();
                    var cadena = Console.ReadLine();
                    var lista = cadena.Split(',').ToList();
                    var cadenaResultado2 = orderRange.Build(lista);
                    Console.WriteLine(string.Format("Resultado: {0}", cadenaResultado2));
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("3:  MoneyPart");
                    Console.Write("Input: ");
                    MoneyParts money = new MoneyParts();
                    money.Build(Console.ReadLine());
                    break;

            }
            
        }


    }
}
