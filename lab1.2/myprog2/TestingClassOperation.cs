using Xunit;
public class Test2
{
    [Theory]
    [InlineData(123)]
    [InlineData(321)]
    [InlineData(744)]
    [InlineData(999)]
    [InlineData(112)]
    public void TestInputRigth(int number1)
    {
        int x,y,z;
        z=number1%10;
        y=((number1-z)/10)%10;
        x=((number1-y-z)/100)%10;
        int number2=z*100+y*10+x;
        Assert.Equal(number2,myprog2.Program.Operation(number1) );
    }
}