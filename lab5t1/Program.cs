using System;
using System.IO;
using System.Collections.Generic;

namespace lab5t1
{
    
    public class Doctor
    {
        private
        string name="None";
        string lastname="None";
        int workstage=0;
        public
        Doctor( string name="",string lastname="",int stage=0)
        {
            
            this.name=name;
            this.lastname=lastname;
            this.workstage=stage;
        }
        public virtual void PrinterDoctor()
        {
            Console.WriteLine("Name "+name);
            Console.WriteLine("LastName "+lastname);
            Console.WriteLine("Stage "+workstage);
        }
        public string Name{get{return name;}set{this.name=value;}}
        public int Stage{get{return workstage;}set{this.workstage=value;}}
        public string LastName{get{return lastname;}set{this.lastname=value;}}
    };
    class Session:Doctor
    {
        private
        static int id_counter=0;
        int current_session_id=0;
        string pacient_name="None";
        string temp_str="";
        int visitors_counter=0;
        string comentar="No coments:(";
        public string Comentar{get{return comentar;}set{this.comentar=value;}}
        public Session()
        {
            //Constructor
        }        
        public Session(StreamReader f)
        {
            int ttt=0;
                this.Name=f.ReadLine();//Name
                this.LastName=f.ReadLine();//LastName
                
                int.TryParse(f.ReadLine(),out ttt );
                this.Stage=ttt;//Stage
                this.Session_day=Get_SesionDay(f.ReadLine());//Session_day
                int.TryParse(f.ReadLine(),out ttt);
                this.Visitors=ttt;//Visitors
                
                this.Pacient=f.ReadLine();//Pacient
                int.TryParse(f.ReadLine(),out ttt);//Sesion_ID
                this.ID=ttt;
                this.IDNUM=this.IDNUM+1;
                this.Comentar=f.ReadLine();//Comentar
        }
        public void Writer(StreamWriter f)
        {
            f.WriteLine(Name);
            f.WriteLine(LastName);
            f.WriteLine(Stage.ToString());
            f.WriteLine(Session_day.ToString());
            f.WriteLine(Visitors.ToString());
            f.WriteLine(Pacient);
            f.WriteLine(ID.ToString());
            f.WriteLine(comentar);
        }
        DayOfWeek day=DayOfWeek.Sunday;//default Sunday always
        public int ID{get {return current_session_id;}set{current_session_id=value;}}
        public int IDNUM{get {return id_counter;}set{id_counter=value;}}
        public string Pacient{get{return pacient_name;}set{this.pacient_name=value;}}
        public string String_GET{get{return temp_str;}}
        public int Visitors{set{this.visitors_counter=value;}get{return visitors_counter;}}
        public DayOfWeek Session_day{get{return this.day;}set{this.day=value;}}
        private DayOfWeek Get_SesionDay(string tmp)
        {
            DayOfWeek value=new DayOfWeek();
            if(tmp=="Monday"){value=DayOfWeek.Monday;return value;}
            if(tmp=="Tuesday"){value=DayOfWeek.Tuesday;return value;}
            if(tmp=="Wednesday"){value=DayOfWeek.Wednesday;return value;}
            if(tmp=="Thursday"){value=DayOfWeek.Thursday;return value;}
            if(tmp=="Friday"){value=DayOfWeek.Friday;return value;}
            if(tmp=="Saturday"){value=DayOfWeek.Saturday;return value;}
            else{value=DayOfWeek.Sunday;}
            return value;
        }
        public void Print()
        {
            Console.WriteLine("Doctors name:\t"+base.Name);
            Console.WriteLine("Doctors lastname:\t"+base.LastName);
            Console.WriteLine("Doctor workstage:\t"+base.Stage);
            Console.WriteLine("Session day:\t"+day.ToString());
            Console.WriteLine("Visitors:\t"+visitors_counter.ToString());
            Console.WriteLine("Pacient:\t"+this.pacient_name);
            Console.WriteLine("Session ID:\t"+this.current_session_id.ToString());
            Console.WriteLine("Comentar:\t"+this.comentar);
        }
        public void fillSession()
        {
            Console.Write("Doctors name:\t");
            this.Name=Console.ReadLine();
            Console.Write("Doctors lastname:\t");
            this.LastName=Console.ReadLine();
            Console.Write("Doctor workstage:\t");
            int tmp=0;
            int.TryParse(Console.ReadLine(),out tmp);
            this.Stage=tmp;
            Console.Write("Session day:\t");
            this.temp_str=Console.ReadLine();
            Console.Write("Visitors:\t");
            int.TryParse(Console.ReadLine(),out tmp);
            this.visitors_counter=tmp;
            Console.Write("Pacient:\t");
            this.pacient_name=Console.ReadLine();
            id_counter=id_counter+1;
            this.current_session_id=id_counter;
            Console.Write("Your Commentear:\t");
            this.comentar=Console.ReadLine();
        }
    }
    class DataBase
    {
        List<Session> data=new List<Session>();
        
        public void ReadDataBase(string path)
        {
            try{
             StreamReader f=new StreamReader(path);
             ReadingLoop(f);
             f.Close();
             }
             catch{Console.WriteLine("File to Read not found!OR Read!!!");}          
        }
        private void ReadingLoop(StreamReader f)
        {
            int tc=0;
            int.TryParse(f.ReadLine(),out tc);

            
            for(int i=0;i<tc;i++)
            {
                
                data.Add(new Session(f));
            }
        }
        private DayOfWeek Get_SesionDay(string tmp)
        {
            DayOfWeek value=new DayOfWeek();
            if(tmp=="Monday"){value=DayOfWeek.Monday;return value;}
            if(tmp=="Tuesday"){value=DayOfWeek.Tuesday;return value;}
            if(tmp=="Wednesday"){value=DayOfWeek.Wednesday;return value;}
            if(tmp=="Thursday"){value=DayOfWeek.Thursday;return value;}
            if(tmp=="Friday"){value=DayOfWeek.Friday;return value;}
            if(tmp=="Saturday"){value=DayOfWeek.Saturday;return value;}
            else{value=DayOfWeek.Sunday;}
            return value;
        }
        public void WriteDataBase(string path)
        {
            try{
             StreamWriter f=new StreamWriter(path);
             WritinigLoop(f);
             f.Close();
             }
             catch{Console.WriteLine("Something wrong:Write database!!!");}
        }
        private void WritinigLoop(StreamWriter f)
        {
            f.WriteLine(data.Count.ToString());
            Console.WriteLine(data.Count.ToString());
            foreach(Session i in data){
                
                i.Writer(f);
            }
            f.WriteLine("@");
            
        }
        public void AddSession(string s)
        {
            if(data.Exists(x=>x.Pacient==s)){Console.WriteLine("This pacient already registred!!! Do you want add him? y/n");if(Console.ReadLine()[0]=='n'){return;}}
            
            Session n=new Session();
            n.fillSession();
            n.Session_day=Get_SesionDay(n.String_GET);
            data.Add(n);
        }
        public void Remove(int id)
        {
            data.Remove(data.Find(x=>x.ID==id));
            
        }
        public char Menu()
        {
            Console.WriteLine("Enter your action a=add, r=remove, p=print, w=write; e=exit");
            string s=Console.ReadLine();
            if(s==""){s="noempty";}
            return s[0];
        }
        public void RUN(string path1,string path2)
        {
            char buff;
            ReadDataBase(path2);
            while(true){
                buff=Menu();
                if(buff=='a')
                {Console.WriteLine("Enter pacient name");AddSession(Console.ReadLine());}
                if(buff=='r'){Console.WriteLine("Enter id session to remove");int t=0;int.TryParse(Console.ReadLine(),out t);Remove(t);}
                if(buff=='p'){Console.WriteLine("\nDATABASE:");Printer();}
                if(buff=='w')
                {WriteDataBase(path1);}
                if(buff=='e'){return;}

            }
        }
        public void Printer()
        {
            foreach(Session i in data)
            {
                i.Print();
                Console.WriteLine('\n');
            }}
            public double AverageVisirors()
            {
                int resault=0;
                foreach(Session i in data){resault=i.Visitors+resault;}
                return resault/data.Count;
            }
            public int MaxlengthCommentar()
            {
                int resault=0;
                foreach(Session i in data){if(i.Comentar.Length>resault){resault=i.Comentar.Length;};}
                return resault;
            }
            public int MinVisirors()
            {
                int resault=0;
                foreach(Session i in data){if(i.Visitors<resault){resault=i.Visitors;};}
                return resault;
            }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string PATH="./DATABASE";
            Console.WriteLine("Hello World!");
            DataBase b=new DataBase();
            
            b.RUN(PATH,PATH);
            Console.WriteLine("Average visitor count is "+b.AverageVisirors().ToString());
            Console.WriteLine("Min visirors in one doctor is "+b.MinVisirors().ToString());
            Console.WriteLine("Lenght of the longest comentar:"+b.MaxlengthCommentar().ToString());

            
            
        }
    }
}
