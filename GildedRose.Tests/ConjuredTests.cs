namespace GildedRose.Tests;

public class ConjuredTests
{
    [Theory]
    [InlineData("Conjured potion", 3, 4, 2)]
    [InlineData("Conjured bread", 6, 8, 6)]
    [InlineData("Conjured sword", 9, 12, 10)]
    [InlineData("Conjured cake", 12, 16, 14)]
    public void Given_Conjured_Item_Quality_Drops_By_Two_When_Updating(string item, int sellIn, int quality, int expected)
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
    [InlineData("Conjured potion", 3, 4, 2)]
    [InlineData("Conjured bread", 6, 8, 5)]
    [InlineData("Conjured sword", 9, 12, 8)]
    [InlineData("Conjured cake", 12, 16, 11)]
    public void Given_Conjured_Item_SellIn_Drops_By_One_When_Updating(string item, int sellIn, int quality, int expected)
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
        Assert.Equal(expected, items[0].SellIn);
    }

    [Theory]
    [InlineData("Conjured potion", 3, 1, 0)]
    [InlineData("Conjured bread", 6, 0, 0)]
    [InlineData("Conjured sword", 9, 1, 0)]
    [InlineData("Conjured cake", 12, 0, 0)]
    public void Given_Conjured_Item_Quality_Wont_Drop_Below_Zero(string item, int sellIn, int quality, int expected)
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