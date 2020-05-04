using System;
using System.Collections.Generic;
namespace lab2t5
{
    class Program
    {
        public static bool InputRC(ref int rows,ref int cols)
        {
            Console.Write("Enter rows: ");
            if(int.TryParse(Console.ReadLine(),out rows))
            {
                Console.Write("Enter cols: ");
                if(int.TryParse(Console.ReadLine(),out cols))
                {
                    Console.WriteLine("rows: "+rows.ToString()+"  cols: "+cols.ToString());
                    return true;
                }
                else 
                {
                    Console.WriteLine("Error input in cols!!!");
                    return false;
                }
            }
            else 
            {
                Console.WriteLine("Error input in rows!!!");
                return false;
            }
        }
        public static void Fill_Arr(ref int[,]Arr,int rows,int cols,bool triger_Input)
        {
            
            Random r12=new Random();
            
            for(int i=0;i<rows;i++)
                {
                    if(triger_Input){Console.Write("\n");}
                    for(int j=0;j<cols;j++)
                    {
                        if (triger_Input)//by yourself or by Randon
                        {
                            Console.Write("row: "+i.ToString()+"\tcol: "+j.ToString()+"\tvalue: ");
                            int.TryParse(Console.ReadLine(),out Arr[i,j]);
                            //if wrong input we put zero in array
                        }
                        else
                        {
                            Arr[i,j]=r12.Next(-1,1);
                        }

                    }
                }
        }
        public static bool Print_zeroROws(ref int[,]Arr,int cols,ref System.Collections.Generic.List <System.Int32>to_Print)
        {
            foreach(int i in to_Print)
            {
                Console.Write("zero element is in row: "+i.ToString()+"\t");
                for(int j=0;j<cols;j++)
                {
                    Console.Write( Arr[i,j].ToString()+"\t");
                }
                Console.Write("\n");
            }
            return true;
        }
        public static bool Find_zeroElement(ref int[,]Arr,int rows,int cols)
        {
            List <int> to_Print=new List<Int32>();
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if(Arr[i,j]==0)
                    {
                        to_Print.Add(i);
                        j=cols;
                    }

                }
            }
            if (to_Print.Count==0){return false;}
            else
            {
                if(Print_zeroROws(ref Arr,cols,ref to_Print)){return true;}
                else{return false;}
                //to_Print.Clear();
            }
            
        }
        static void Main(string[] args)
        {
            int rows=5,cols=5;//by default 5x5 
            if(InputRC(ref rows,ref cols))//right input in rows and cols both of them!=0
            {
                int[,]Arr=new int [rows,cols];//create 2-dimensions array
                Fill_Arr(ref Arr,rows,cols,false);//if fill_arr by random "false"
                Find_zeroElement(ref Arr,rows,cols);
            }
        }
    }
}
