namespace GildedRose.Tests;

public class BackstagePassTests
{
    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 15, 16)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 20, 25, 26)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 30, 35, 36)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 40, 45, 46)]
    public void Given_Backstage_Pass_Increase_Quality_By_One_When_Updating(string item, int sellIn, int quality, int expected)
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

    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 15, 17)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 9, 25, 27)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 8, 35, 37)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 7, 45, 47)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 45, 47)]
    public void Given_Backstage_Pass_Increase_Quality_By_Two_When_SellIn_Is_Between_Five_And_Ten(string item, int sellIn, int quality, int expected)
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

    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 15, 18)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 4, 25, 28)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 3, 35, 38)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 45, 48)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 45, 48)]
    public void Given_Backstage_Pass_Increase_Quality_By_Three_When_SellIn_Is_Between_Zero_And_Five(string item, int sellIn, int quality, int expected)
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

    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 15, 0)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", -1, 25, 0)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", -2, 35, 0)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", -3, 45, 0)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", -4, 45, 0)]
    public void Given_Backstage_Pass_Quality_Drops_To_Zero_When_SellIn_Is_Zero_Or_Less(string item, int sellIn, int quality, int expected)
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

    [Theory]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 3, 48, 50)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 49, 50)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 9, 49, 50)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 12, 49, 50)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 50, 50)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 20, 55, 55)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 25, 100, 100)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 150, 150)]
    public void Given_Backstage_Pass_Quality_Wont_Increase_After_Fifty(string item, int sellIn, int quality, int expected)
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