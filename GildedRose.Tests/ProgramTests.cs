namespace GildedRose.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("Sword", 3, 4, 3)]
    [InlineData("Potion", 6, 8, 7)]
    [InlineData("Spoon", 9, 12, 11)]
    [InlineData("Glass", 12, 16, 15)]
    [InlineData("Axe", 15, 20, 19)]
    public void Given_New_Item_Quality_Drops_By_One_When_Updating(string item, int sellIn, int quality, int expected)
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
    [InlineData("Sword", 3, 4, 2)]
    [InlineData("Potion", 6, 8, 5)]
    [InlineData("Spoon", 9, 12, 8)]
    [InlineData("Glass", 12, 16, 11)]
    [InlineData("Axe", 15, 20, 14)]
    public void Given_New_Item_SellIn_Drops_By_One_When_Updating(string item, int sellIn, int quality, int expected)
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
    [InlineData("Sword", 3, 0, 0)]
    [InlineData("Potion", 6, 0, 0)]
    [InlineData("Spoon", 9, 0, 0)]
    [InlineData("Glass", 12, 0, 0)]
    [InlineData("Axe", 15, 0, 0)]
    public void Given_New_Item_Quality_Wont_Drop_Below_Zero(string item, int sellIn, int quality, int expected)
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
    [InlineData("Sword", 0, 4, 2)]
    [InlineData("Potion", -6, 8, 6)]
    [InlineData("Spoon", -9, 12, 10)]
    [InlineData("Glass", -12, 16, 14)]
    [InlineData("Axe", -15, 20, 18)]
    public void Given_New_Item_Quality_Drops_Twice_As_Fast_When_SellIn_Is_Zero_Or_Less(string item, int sellIn, int quality, int expected)
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