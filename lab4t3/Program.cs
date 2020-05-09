using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
namespace lab4t3
{
    class DataBase
    {   
        List<programBD>BD=new List<programBD>();
        public DataBase(bool triger=false,string way="out_ProgramArhive")
        {
            if(triger)
            {
                StreamReader f=new StreamReader(way);
                f.ReadLine();//first line is number of programs in arhive
                while(f.Peek()!='%')//last line is %
                {
                    try{
                    BD.Add(new programBD(f.ReadLine(),f.ReadLine(),f.ReadLine(), int.Parse( f.ReadLine())));//put element into list;
                    }
                    catch
                    {
                        Console.WriteLine("Your file dont have \"%\" in the end of file or other error appear!!!\n Way to file:"+way);
                    }
                }
            }       
        }
        public bool AddProgram(programBD prog)
        {
            if(ExistProg(prog.Name)){Console.WriteLine("Program already exist! Addition canceled!");return false;}
            BD.Add(prog);   
            return true;
        }
        public bool RemoveProgram(string prog)
        {
            if(ExistProg(prog)){BD.Remove( BD.Find(x =>x.Name==prog));return true;}
            else{Console.WriteLine("Program not exist in Arhive");return false;}

        }
        
        public void PrintArhive()
        {
            foreach(programBD i in BD)
            {
                i.PrintInfo();
            }
        }
        private bool ExistProg(string s){
            if(BD.Exists(x => x.Name==s)){return true;}
            return false;
        }
        public void SaveArhive(string way="./out_ProgramArhive")
        {
            StreamWriter f=new StreamWriter(way);
            f.WriteLine((BD.Count).ToString());
            foreach(programBD i in BD)
            {
                i.WriteR(f);
            }
            f.WriteLine('%');
            f.Close();
        }
    }
    class programBD
    {
        private string name;
        private string OS;
        private DateTime date_writing;//2/16/2009 12:00:00 PM;
        private int size;//in bytes:)
        public programBD()
        {
            this.name="None";
            this.OS="None";
            this.date_writing=DateTime.Now;
            this.size=0;
            //default
        }
        public programBD(programBD value)
        {
            this.name=value.Name;
            this.OS=value.OpSys;
            this.date_writing=value.date_writing;
            this.size=value.size;
            //default
        }
        public programBD(string name,string OS,string time,int size)
        {
            this.name=name;
            this.OS=OS;
            this.size=size;
            try{
            this.date_writing= DateTime.Parse(time);}
            catch
            {
                Console.WriteLine("Warning! Program get exseption when constructor try to convert string in DateTime format! Time was changed to curent!");
                this.date_writing= DateTime.Now;
            }
        }
        public string Name{get{return name;}set{this.name=value;}}
        public string OpSys{get{return OS;}set{this.OS=value;}}
        public string time{get{return date_writing.ToString();}set{try{this.date_writing= DateTime.Parse(time);}catch{
                Console.WriteLine("Warning! Program get exseption when constructor try to convert string in DateTime format! Time was changed to curent!");
                this.date_writing= DateTime.Now;}}}
        public int Size{get{return size;}set{if(value>=0){this.size=value;}else{throw new Exception("Value SIZE of program is negative");}}}

        private void Tab_help(string s)
        {
            if(s.Length<6)
            {
                Console.WriteLine("\t\t\t|");
            }
            else{
                if(s.Length<12){Console.WriteLine("\t\t|");}
                else{Console.WriteLine("\t|");}
            }

        }
        public void PrintInfo()
        {
            Console.Write(" ________________________\n|"+Name);
            Tab_help(Name);
            Console.Write("|"+OS);
            Tab_help(OS);
            Console.Write("|"+time);
            Tab_help(time);
            Console.Write("|"+Size.ToString());
            Tab_help(Size.ToString());
            Console.Write("|_______________________/\n");

        }
        public void WriteR(StreamWriter w)
        {
            w.WriteLine(Name);
            w.WriteLine(OS);
            w.WriteLine(time);
            w.WriteLine(Size.ToString());
        }
        
    }
    class Program
    {
        static public int Menu()
        {
            int V=0;
            Console.WriteLine("Enter 1 to ADD program to Arhive;");
            Console.WriteLine("Enter 2 to REMOVE program from Arhive;");
            Console.WriteLine("Enter 3 to PRINT all Arhive;");
            Console.WriteLine("Enter 4 to SAVE Arhive (default=./out_ProgramArhive);");
            Console.WriteLine("Enter 5 to end this program");
            while(V==0)
            {
                int.TryParse(Console.ReadLine(),out V);
                if(V>0&&V<7){return V;}
                V=0;
            }
            return 0;
        }
        static public void Interface(ref DataBase t)
        {
            
            bool triger_end=true;
            while(triger_end)
            {
                int tmp=Menu();
                switch (tmp)
                {
                    case 1:
                    {
                        string s1,s2,s3;int s4;
                        Console.Write("Program name: ");
                        s1=Console.ReadLine();
                        Console.Write("Program OS: ");
                        s2=Console.ReadLine();
                        Console.Write("Enter date: ");
                        s3= Console.ReadLine();
                        Console.Write("Program size: ");
                        int.TryParse(Console.ReadLine(),out s4);
                        t.AddProgram(new programBD(s1,s2,s3,s4));
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Write name of program that you want to delete");
                        t.RemoveProgram(Console.ReadLine());
                        break;
                    }
                    case 3:
                    {
                        t.PrintArhive();
                        break;
                    }
                    case 4:
                    {
                        t.SaveArhive();
                        break;
                    }
                    case 5:
                    {
                        triger_end=false;
                        break;
                    }
                }



            }
        }
        static void Main(string[] args)
        {
            const string s="./out_ProgramArhive";
            DataBase Arch= new DataBase(true,s);
            Interface(ref Arch);
            
        }
    }
}
