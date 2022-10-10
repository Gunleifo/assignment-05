namespace GildedRose.Tests;

public class MainTests
{
    [Fact]
    public void Bad_Main_Test()
    {
        Program.Main(new string[0]);
        
        Assert.True(true);
    }
}