using Xunit;
public class Test
{
    [Fact]
    public void TestExample()
    {
     Assert.Equal(11, ConsoleApp1.Program.Example(5,6));
     Assert.NotEqual(7,ConsoleApp1.Program.Example(2,4));
    }





}