using System;
using System.Linq;
namespace lad3t1
{
    class Program
    {
        public static int Count_senNonPair(ref string str)
        {
            int resault=0;
            string []massiv=str.Split('.');//split str on smaller string by demiter '.';
            
            foreach(string i in massiv)
            {
                
                i.Trim(' ');//cut first and last ' ';
                int counter_space=0;
                for(int j=0;j<i.Length;j++)
                {
                    if(i[j]==' '&&i[0]!=' '){counter_space++;}


                }
                if(!i.Contains(' ')&&i!=""||counter_space%2==0){resault++;}
               // if(counter_space%2==0){resault++;}
            }
            //if(str.Contains('.')){if(massiv.Last().Length==0){resault--;}}
            //if(str.Contains('.')&&!str.Contains(' ')){resault--;}
            return resault;
        }
        public static string OutPut_after_sym(ref string str,char sym)
        {
            if(str.Contains(sym))
            {
                return str.Substring(str.IndexOf(sym));
            }
            return str;
        }
        static void Main(string[] args)
        {
            string RAW=Console.ReadLine();
            Console.WriteLine(OutPut_after_sym(ref RAW,':'));
            Console.WriteLine(Count_senNonPair(ref RAW));
        }
    }
}
