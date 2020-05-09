using System;
using Xunit;

namespace lab4t1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(-11)]
        [InlineData(88)]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(95)]
        [InlineData(77)]
        [InlineData(3)]
        [InlineData(101)]
        public void Test1(int t)
        {
            lab4t1.Student st1=new lab4t1.Student();
            if(t>=0&&t<=100)
            {
                Assert.True( st1.StudentRating(t));
            }
            else
            {
                try
                {
                    st1.StudentRating(t);
                }
                catch (System.Exception)
                {
                    Assert.True(true);
                }
            }
        }
    }
}
