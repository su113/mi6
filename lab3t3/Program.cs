using System;
using System.IO;
using System.Collections.Generic;

namespace lab3t3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader inputFILE=new StreamReader("./input");
            string GymBuffer=inputFILE.ReadToEnd();
            string []GymArray=GymBuffer.Split(' ');
            List<string>UniqStr=new List<string>();

            foreach(string i in GymArray)
            {
                bool triger=true;
                foreach(string j in UniqStr)
                {
                    if(j.Contains(i)){triger=false;}
                }
                if(triger){UniqStr.Add(i);}
            }
            StreamWriter OutputFile=new StreamWriter("./output");
            foreach(string i in UniqStr)
            {
                Console.Write(i+' ');
                OutputFile.WriteLine(i);
            }
            OutputFile.Close();

        }
    }
}
