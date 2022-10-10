namespace GildedRose.Tests;

public class AgedBrieTests
{
    [Theory]
    [InlineData("Aged Brie", 0, 1, 3)]
    [InlineData("Aged Brie", 1, 1, 2)]
    [InlineData("Aged Brie", 10, 1, 2)]
    [InlineData("Aged Brie", 15, 1, 2)]
    public void Given_Aged_Brie_Increase_Quality_By_One_When_Updating_Once(string item, int sellIn, int quality, int expected)
    {
        // Arrange
        Program program = new Program();

        List<Item> agedBrie = new ()
        {
            new Item{ Name = item, SellIn = sellIn, Quality = quality }
        };
        
        // Act
        program.UpdateQuality(agedBrie);

        // Assert
        Assert.Equal(expected, agedBrie[0].Quality);
    }

    [Theory]
    [InlineData("Aged Brie", 0, 1, 9)]
    [InlineData("Aged Brie", 1, 1, 8)]
    [InlineData("Aged Brie", 10, 1, 5)]
    [InlineData("Aged Brie", 15, 1, 5)]
    public void Given_Aged_Brie_Increase_Quality_By_Four_When_Updating_Four_Times(string item, int sellIn, int quality, int expected)
    {
        // Arrange
        Program program = new Program();

        List<Item> agedBrie = new ()
        {
            new Item{ Name = item, SellIn = sellIn, Quality = quality }
        };
        
        // Act
        program.UpdateQuality(agedBrie);
        program.UpdateQuality(agedBrie);
        program.UpdateQuality(agedBrie);
        program.UpdateQuality(agedBrie);

        // Assert
        Assert.Equal(expected, agedBrie[0].Quality);
    }

    [Theory]
    [InlineData("Aged Brie", 0, 49, 50)]
    [InlineData("Aged Brie", 0, 50, 50)]
    [InlineData("Aged Brie", 0, 51, 51)]
    public void Given_Aged_Brie_Quality_Wont_Increase_Past_Fifty_When_Updating(string item, int sellIn, int quality, int expected)
    {
        // Arrange
        Program program = new Program();

        List<Item> agedBrie = new ()
        {
            new Item{ Name = item, SellIn = sellIn, Quality = quality }
        };
        
        // Act
        program.UpdateQuality(agedBrie);

        // Assert
        Assert.Equal(expected, agedBrie[0].Quality);
    }
}