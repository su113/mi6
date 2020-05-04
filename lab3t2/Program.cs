using System;
using System.IO;
namespace lab3t2
{
    class Program
    {
        public static ref int[] Counter_method(ref int []arr,ref string mystr)
        {
            string []little_str=mystr.Split(' ');
            int j=0;
            foreach(string i in little_str)
            {
                arr.SetValue( i.Length,j);j++;
            }
            return ref arr;
        }
        static void Main(string[] args)
        {
            StreamReader f = new StreamReader("./mytxt");
            string buf=f.ReadToEnd();
            f.Close();
            int counter=0;
            for(int i=0;i<buf.Length;i++){if(buf[i]==' '){counter++;}}
            int []Num_ofCharInStrings=new int[counter+1] ;
            Counter_method(ref Num_ofCharInStrings,ref buf);
            foreach(int i in Num_ofCharInStrings){Console.Write(i.ToString()+" ");}
        }
    }
}
