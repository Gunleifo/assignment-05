namespace GildedRose.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("Sulfuras, Hand of Ragnaros", -45, 1, 1)]
    [InlineData("Sulfuras, Hand of Ragnaros", -5, 5, 5)]
    [InlineData("Sulfuras, Hand of Ragnaros", 0, 10, 10)]
    [InlineData("Sulfuras, Hand of Ragnaros", 1, 20, 20)]
    [InlineData("Sulfuras, Hand of Ragnaros", 10, 25, 25)]
    [InlineData("Sulfuras, Hand of Ragnaros", 15, 40, 40)]
    public void Given_Sulfuras_Quality_Never_Changes_When_Updating(string item, int sellIn, int quality, int expected)
    {
        // Arrange
        Program program = new Program();

        List<Item> items = new ()
        {
            new Item{ Name = item, SellIn = sellIn, Quality = quality }
        };
        
        // Act
        program.UpdateQuality(items);

        // Assert
        Assert.Equal(expected, items[0].Quality);
    }
}