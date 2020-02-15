using Xunit;
public class Test1
{
    [Theory]
    [InlineData("dasda")]   //only string
    [InlineData("1234")]    //>999
    [InlineData("98")]      //<100
    [InlineData("3.40wr")]  //string +numbers
    [InlineData("dsf$#@#")]
    [InlineData("123dsfs")]
    [InlineData("dsfs")]
    [InlineData("")]        //empty string
    public void TestInputWrong(string str)
    {
        int a=0;
        Assert.False(myprog2.Program.Check(str,ref a));
    }


    [Theory]
    [InlineData("123")]
    [InlineData("321")]
    [InlineData("654")]
    [InlineData("456")]
    public void TestInputRigth(string str)
    {
        int a=0;
        Assert.True(myprog2.Program.Check(str,ref a));
    }
}