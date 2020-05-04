using System;

namespace lab2t2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Function: y=cos(x)*sin(x) a=-PI b=PI dx=PI/10");
            double b=Math.PI,y;
            for(double a=b*-1;a<b;a+=b/10)
            {
                y=Math.Cos(a)*Math.Sin(a);
                Console.WriteLine("result:\t"+y.ToString()+"\ta=-"+b.ToString()+"  b="+b.ToString()+"  dx="+(b/10).ToString());
            }
        }
    }
}
