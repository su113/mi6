using System;

namespace lab2t3
{
    class Program
    {
        public static int MaxElement(ref int [] mymass,ref bool triger_negativeAray)
        {
            int MaxV=0;
            for (int j=0; j < mymass.Length;j++)
            {   if(triger_negativeAray){if(j!=0&&mymass[j-1]>0){triger_negativeAray=false;}}
                if(Math.Abs(mymass[j])>Math.Abs(mymass[MaxV]) ){MaxV=j;}
            }
            return mymass[MaxV];
        }
        public static int GETfrom_console(string str)
        {
            int len;
            if(int.TryParse(str,out len ))
            {              
                return len;
            }
            else
            {
                Console.WriteLine("Input error!");
                return 0;
            }
        }
        public static bool fillArray(ref int[]mymass,bool method)
        {
            if(!method)
            {
                Random aRand12=new Random();//create object of class Random
                for (int i=0;i<mymass.Length;i++){mymass[i]=aRand12.Next(-100,100); }
                return true;
            }
           //if you want input value in massiv by yourself "true"in method
           for(int i=0;i<mymass.Length;i++)
           {
               Console.Write("value #"+i.ToString()+"\tis: ");
               mymass[i]=GETfrom_console(Console.ReadLine());
           }
            return true ;            
        }
        public static int dobytok (ref int[]massiv)
        {
            int result=1;
            bool first=false;//first element must bee >0
            foreach (int i in massiv)
            {
                if(first)
                {
                    result*=i;                    
                }
                else
                {
                    if(i>0){first=true;}
                }
            }
            return result;
        }
        public static void Main(string[] args)
        {
            Console.Write("Enter massiv length all negative values will bee reverse to posityv value:\t");
            int n=Math.Abs( GETfrom_console(Console.ReadLine()));  //get value of size massiv="true"          
            if(n!=0)
            {
                bool triger_negativeAray=true;//we can get incorect value in situation when all massive has all negative values
                int [] massiv=new int[n];
                if(fillArray(ref massiv,true))//if yourself "true" =3thd parametr
                {
                    Console.WriteLine( "Max element is:\t"+MaxElement(ref massiv,ref triger_negativeAray ).ToString());
                    if (!triger_negativeAray)
                    {
                        Console.WriteLine("multiple of all elements after first positive element"+dobytok(ref massiv).ToString());
                    }
                    for(int i=0;i<n;i++)
                    {
                        Console.WriteLine(massiv.GetValue(i) .ToString());
                    }
                }
            }
        }
    }
}