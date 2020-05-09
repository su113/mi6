using System;

namespace lab4t1
{
    class Student
    {
        private string name="None";
        private string lastname="None";
        private int age=0;
        private string group="None";
        private int year=0;
        private string adress="None";
        private string telephone="None";
        private int rating=0;
        public Student(){}//constructor without parametrs
        public bool StudentRating(int R)
        {
            if(R<=100&&R>=0)
            {
                if(R>=90){Console.WriteLine("Вітаємо відмінника");}
                if(R>75){Console.WriteLine("можна вчитися краще");}
                if(R>=75){Console.WriteLine("Варто більше уваги приділяти навчанню");}
                this.rating=R;
                return true;
            }
            else{throw new Exception("Your enter Rating that is bigger than:100 or lower than 0!");}
        }
        //Bластивості:
        public string Name
        {
            get{return name;}
            set{name=value;}
        }
        public string LastName
        {
            get{return lastname;}
            set{lastname=value;}
        }
        public int Year
        {
            get{return year;}
            set{year=value;}
        } 
        public string Adress
        {
            get{return adress;}
            set{adress=value;}
        }
        public string Telephone
        {
            get{return telephone;}
            set{telephone=value;}
        }
        public int Age
        {
            get{return age;}
            set{age=value;}
        }
        public string Group
        {
            get{return group;}
            set{group=value;}
        }
        public int Rating
        {
            get{return rating;}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student s =new Student();
            s.Name="Tom";
            s.LastName="Student";
            s.Adress="platon34";
            s.Group="NewApp98";
            s.Age=34;
            s.Telephone="234354334";
        }
    }
}
