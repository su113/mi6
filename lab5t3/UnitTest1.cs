using System;
using Xunit;

namespace lab5t3
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Monday")]
        [InlineData("Tuesday")]
        [InlineData("Wednesday")]
        [InlineData("Thursday")]
        [InlineData("Friday")]
        [InlineData("Saturday")]
        [InlineData("Sunday")]
        [InlineData("adssdasdas")]
        [InlineData("")]
        public void Test1(string tmp)
        {
            lab5t3.DataBase b=new DataBase();
            if(tmp=="Monday"){Assert.True( DayOfWeek.Monday==b.Get_SesionDay(tmp));return;}
            if(tmp=="Tuesday"){Assert.True( DayOfWeek.Tuesday==b.Get_SesionDay(tmp));return;}
            if(tmp=="Wednesday"){Assert.True( DayOfWeek.Wednesday==b.Get_SesionDay(tmp));return;}
            if(tmp=="Thursday"){Assert.True( DayOfWeek.Thursday==b.Get_SesionDay(tmp));return;}
            if(tmp=="Friday"){Assert.True( DayOfWeek.Friday==b.Get_SesionDay(tmp));return;}
            if(tmp=="Saturday"){Assert.True( DayOfWeek.Saturday==b.Get_SesionDay(tmp));return;}
            else{Assert.True( DayOfWeek.Sunday==b.Get_SesionDay(tmp));return;}
        }
    }
}
