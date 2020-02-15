using System;

namespace myprog2
{
    class Program
    {
        static public int Operation(int number)
        {
            int x,y,z;
            z=number%10;
            y=((number-z)/10)%10;
            x=((number-y-z)/100)%10;
            int answer=z*100+y*10+x;
            return answer;
        }
        static public bool Check(string str, ref int N)
        {
            try
            {
               N=Convert.ToInt32(str);
            }
            catch(Exception)
            {
                return false;
            }
            if(N<1000&&N>99)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Please input 3 digits number:");
            string tmp=Console.ReadLine();
            int number=0;
            
            if(Check(tmp,ref number))
            {
                Console.Write("your number is:"+Operation(number));
            }
            else
            {
                Console.WriteLine("Invalid input number");
            }
        }
    }
}
