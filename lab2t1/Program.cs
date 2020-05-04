using System;

namespace lab2t1
{
    class Program
    {
                static void Main(string[] args)
        {
            int Emonth;
            Console.Write("Enter number mounth: ");
            if(int.TryParse(Console.ReadLine(),out Emonth ))
            {
                switch (Emonth)
                {
                    case 1:
                        Console.Write("winter");
                        break;
                    case 2:
                        Console.Write("winter");
                        break;
                    case 3:
                        Console.Write("spring");
                        break;
                    case 4:
                        Console.Write("spring");
                        break;
                    case 5:
                        Console.Write("spring");
                        break;
                    case 6:
                        Console.Write("summer");
                        break;
                    case 7:
                        Console.Write("summer");
                        break;
                    case 8:
                        Console.Write("summer");
                        break;
                    case 9:
                        Console.Write("autumn");
                        break;
                    case 10:
                        Console.Write("autumn");
                        break;
                    case 11:
                        Console.Write("autumn");
                        break;
                    case 12:
                        Console.Write("winter");
                        break;
                    default :
                        Console.Write("Invalid input.");
                        break;
                }
            }
            else
            {
                Console.Write ("Invalid input");
            }
        }
    }
}
