using System;

namespace lab4t2
{
    interface Student
    {
        string Name{get;set;}
        string LastName{get;set;}
        int Number_of_StudentBook{get;set;}
        int Math{get;set;}
        int Physic{get;set;}
        int Web{get;set;}
        int Networking{get;set;}
        int Computer_Sys{get;set;}
    }
    class Lessons:Student
    {
        //variabless with default values
        private string name;
        private string lastname;
        private int number_of_studentbook;
        int math;
        int computer_sys;
        int networking;
        int web;
        int physic;
        public Lessons(){
            this.name="None";
            this.lastname="None";
            this.number_of_studentbook=0;
            this.math=0;
            this.physic=0;
            this.web=0;
            this.computer_sys=0;
            this.networking=0;
        }
        public Lessons(string name,string lastname,int number_of_studentbook, int math,int physic,int computer_sys,int web,int networking)
        {
            this.name=name;
            this.lastname=lastname;
            this.number_of_studentbook=number_of_studentbook;
            this.math=math;
            this.physic=physic;
            this.web=web;
            this.computer_sys=computer_sys;
            this.networking=networking;
        }

        public string Name{set {name=value;}get{return name;}}
        public string LastName{set{lastname=value;}get{return lastname;}}
        public int Number_of_StudentBook{get{return number_of_studentbook;}set{number_of_studentbook=value;}}
        public int Math{get{return math;}set{math=Validation_num(value);}}
        public int Physic{get{return physic;}set{physic=Validation_num(value);}}
        public int Networking{get{return networking;}set{networking=Validation_num(value);}}
        public int Web{get{return web;}set{web=Validation_num(value);}}
        public int Computer_Sys{get{return computer_sys;}set{computer_sys=Validation_num(value);}}
        public int AverageMark()
        {       
            if((math+physic+computer_sys+web+networking)==0){return 0;}
            return (math+physic+computer_sys+web+networking)/5;
        }
        private int Validation_num(int num)
        {
            int resault=0;
            if(resault<=100&&resault>=0){return resault;}
            else{throw new Exception("Your Enter invalid mark: "+resault.ToString());}
        }
        public void Print_Info()
        {
            Console.WriteLine("\nStudent:"+name+" "+lastname+"\nStudent book: "+number_of_studentbook.ToString()+"\nMath: "+math.ToString()+"\nPhysic: "+physic.ToString()+"\nComputer System: "+computer_sys.ToString()+"\nWeb: "+web.ToString()+"\nNetworking: "+networking.ToString()+"\nAverage mark: "+AverageMark().ToString()+"\n\n\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lessons []group=new Lessons[5];
            group[0]=new Lessons("Andriy","Petro",1,99,100,98,100,100);       
            group[1]=new Lessons("Nazar","Shpeck",2,89,90,88,90,90);
            group[2]=new Lessons("Yura","Kshuk",3,79,80,78,80,80);
            group[3]=new Lessons("Vasul","Kebus",4,69,70,68,70,70);
            group[4]=new Lessons("Vlad","Kozak",5,89,90,88,90,90);

            int sum=0,count=0;
            foreach(Lessons i in group)
            {
                i.Print_Info();
                sum+=i.AverageMark();
                count++;
            }
            Console.WriteLine("The average group mark is: "+(sum/count).ToString());
        }
    }
}
