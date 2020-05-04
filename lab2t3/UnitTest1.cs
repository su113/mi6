using System;
using Xunit;

namespace lab2t3
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("5")]
        [InlineData("-5")]
        [InlineData("qwe")]
        [InlineData("0")]
        
        public void Test_GETfrom_console(string str)
        { 
            //prepare to test
            int temp=0;
            
            int.TryParse(str,out temp);
            
            //test input masive size 
            
            Assert.Equal(lab2t3.Program.GETfrom_console(str),temp);
        }

        [Fact]
        public void TestFact_dobytok()
        {
            int[]massiv=new int[]{2,3,4,5};
            //bool triger_negativeMasiive=true;
            //we will multiply after first positive value;first positive missed
            Assert.Equal(lab2t3.Program.dobytok(ref massiv),60);
            massiv[0]=-2;
            massiv[1]=-3;
            Assert.Equal(lab2t3.Program.dobytok(ref massiv),5);
            //we cant put in massiv all negaives value or last positive value;
        }
        [Fact]
        public void testFact_MaxElement()
        {
            int[]massiv=new int[]{2,3,4,5};
            bool triger_negativeMasiive=true;
            Assert.Equal(lab2t3.Program.MaxElement(ref massiv,ref triger_negativeMasiive),5);
            massiv[0]=-10;
            Assert.Equal(lab2t3.Program.MaxElement(ref massiv,ref triger_negativeMasiive),-10);
            massiv[1]=-10;
            massiv[2]=-11;
            //we cant put in method dobytok  all negaives value in massiv or last positive value;
            lab2t3.Program.MaxElement(ref massiv,ref triger_negativeMasiive);
            Assert.False(triger_negativeMasiive);
        }
        
    }

}
